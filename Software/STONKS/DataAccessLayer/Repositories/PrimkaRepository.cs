using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccessLayer.Repositories
{
    public class PrimkaRepository : Repository<Primka>
    {
        public PrimkaRepository() : base(new STONKS_DB())
        {
        }
        public int AddTransactional(Primka primka, List<StavkaPrimke> stavke)
        {
            var StavkePrimke = Context.Set<StavkaPrimke>();
            var Primke = Context.Set<Primka>();

            // Create a TransactionScope to manage the transaction
            using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.RepeatableRead }))
            {
                try
                {
                    Primke.Attach(primka);

                    var entry =  Primke.Add(primka);
                    int affectedRows = Context.SaveChanges();
                    if (affectedRows > 0)
                    {
                        foreach (var stavka in stavke)
                        {
                            stavka.primka_id = entry.id;   
                            stavka.Artikli = null;
                            StavkePrimke.Attach(stavka);
                            StavkePrimke.Add(stavka);
                            Context.SaveChanges();
                        }                        
                        transaction.Complete(); // If all operations were successful, commit the transaction
                        return 1;
                    }
                    return 0;
                    

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    // If an exception was thrown, roll back the transaction
                    transaction.Dispose();
                    return 0;
                }
            }

        }
        public override int Update(Primka entity, bool save = true)
        {
            throw new NotImplementedException();
        }
    }
}
