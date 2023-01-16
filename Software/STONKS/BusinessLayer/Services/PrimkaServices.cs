using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessLayer.Services
{
    public class PrimkaServices
    {   

        public List<Primka> GetPrimke()
        { 
            using (var repo = new PrimkaRepository())
            {
                return repo.GetAll().ToList();
            }
        }

        public int GetIdForNewPrimka()
        {
            return GetPrimke().Count + 1;
        }

        public bool AddPrimka(Primka primka,List<StavkaPrimke> stavke)
        {
            using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
            {
                List<Artikl> artikli = new List<Artikl>();      //this list is need beacuse i need to set artikl to null to insert stavka without conflict
                stavke.ForEach(s => artikli.Add(s.Artikli));
                try 
                {   
                    int primkaId = 0;
                    using(var repo = new PrimkaRepository())
                    {
                        primkaId = repo.Add(primka); // to understand this check comments for Add override in PrimkaRepository
                    }
                    if (primkaId > 0)
                    {
                        // Add new purchase (primka) to the database
                        using (var repo = new StavkePrimkeRepository())
                        {
                            // Iterate through each item in the purchase
                            foreach (var stavka in stavke)
                            {
                                // Set Artikli property to null and primka_id foreign key
                                stavka.Artikli = null;
                                stavka.primka_id = primkaId;
                                // Add stavka to the database without saving changes
                                repo.Add(stavka,false);
                            }
                            repo.SaveChanges();
                        }
                        // Update stock levels for items in the purchase
                        using (var repo = new ArtikliRepository())
                        {
                            // Check that there is a matching item in the artikli list for each stavka
                            if (artikli.Count == stavke.Count)
                           {
                                // Iterate through each item in the purchase
                                for (int i = 0; i < artikli.Count; i++)
                                {
                                    // Update saldo (stock level) for the item
                                    artikli[i].saldo += stavke[i].kolicina;
                                    // Update item in the database without saving changes
                                    repo.Update(artikli[i],false);
                                }
                                repo.SaveChanges();
                           }
                           
                        }
                        // If all database operations were successful, commit the transaction
                        transaction.Complete();
                        // Return true to indicate that the transaction was successful
                        return true;
                    }
                    return false;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    // If an exception was thrown, roll back the transaction
                    transaction.Dispose();
                    return false;
                }
            
            }

        }

        public List<StavkaPrimke> GetStavkeFromPrimka(Primka primka)
        {
            using (var repo = new StavkePrimkeRepository())
            {
                return repo.GetByPrimkaId(primka.id).ToList();
            }
        }
    }
}
