using BusinessLayer.Services;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STONKS.Forms
{
    public partial class FrmIzradaRacuna : Form
    {
        public FrmIzradaRacuna()
        {
            InitializeComponent();
        }

        public RacuniServices servicesRacuni = new RacuniServices();
        public StavkeServices servicesStavke = new StavkeServices();
        //private BindingList<StavkaRacuna> stavkeRacuna = new BindingList<StavkaRacuna>();


        private void FrmIzradaRacuna_Load(object sender, EventArgs e)
        {
            var allNaciniPlacanja = new NaciniPlacanjaServices().GetNaciniPlacanja();
            cboOdabirNacinaPlacanja.DataSource = allNaciniPlacanja;
            cboOdabirNacinaPlacanja.SelectedIndex = 1;
            
            // TODO makni prvog "Sve" il ga sakrij nekak idk
        }

        private void btnIzradiRacun_Click(object sender, EventArgs e)
        {
            var selectedNacinPlacanja = cboOdabirNacinaPlacanja.SelectedItem as NacinPlacanja;
            MessageBox.Show("id nacina placanja= "+selectedNacinPlacanja.id.ToString());
            /* var racun = new Racun
             {
                 nacin_placanja_id = selectedNacinPlacanja.id,
                 korisnik_id = 1, // TODO logged user
                 vrijeme_izdavanja = DateTime.Now,
                 ukupno = FrmUnosRacuna.ukupnoUnos,
                 popust = 0, // TODO nez kaj s ovim
                 pdv = 25, // TODO nez kaj s ovim
                 cjena_bez_pdv = FrmUnosRacuna.ukupnoUnos-(FrmUnosRacuna.ukupnoUnos*0.25), // TODO nez jel ovo dobro
             };
             MessageBox.Show("kao dodan\nnacin_placanja" + racun.nacin_placanja_id.ToString() + "korisnik_id " + racun.korisnik_id.ToString() + "vrijeme_izdavanja " + racun.vrijeme_izdavanja.ToString() + "ukupno " + racun.ukupno.ToString()+" "  + FrmUnosRacuna.ukupnoUnos + " \n"+ "popust " + racun.popust.ToString() + "pdv " + racun.pdv.ToString() + "cjena_bez_pdv " + racun.cjena_bez_pdv.ToString()); // ovo je ok
             */
            // tu ko da opce ne kuzi da postoji racun neg baci error da nema instance objekta

            //int idRacuna = servicesRacuni.AddRacun(racun);
            //MessageBox.Show("ID RACUNA = " + idRacuna.ToString());

            /*
            using (var db = new DataAccessLayer.STONKS_DB())
            {
                var racunNovi = new Racun
                {
                    nacin_placanja_id = selectedNacinPlacanja.id,
                    korisnik_id = 1, // TODO logged user
                    vrijeme_izdavanja = DateTime.Now,
                    ukupno = FrmUnosRacuna.ukupnoUnos,
                    popust = 0, // TODO nez kaj s ovim
                    pdv = 25, // TODO nez kaj s ovim
                    cjena_bez_pdv = FrmUnosRacuna.ukupnoUnos - (FrmUnosRacuna.ukupnoUnos * 0.25), // TODO nez jel ovo dobro
                };
                db.Racuni.Add(racunNovi);
                db.SaveChanges();
            }*/

            // pokusaj tri
                var racunNovi = new Racun
                {
                    nacin_placanja_id = selectedNacinPlacanja.id,
                    korisnik_id = 1, // TODO logged user
                    vrijeme_izdavanja = DateTime.Now,
                    ukupno = FrmUnosRacuna.ukupnoUnos,
                    popust = 0, // TODO nez kaj s ovim
                    pdv = 25, // TODO nez kaj s ovim
                    //cjena_bez_pdv = FrmUnosRacuna.ukupnoUnos - (double.Parse(FrmUnosRacuna.ukupnoUnos) * 0.25), // TODO nez jel ovo dobro
                    cjena_bez_pdv = 25, // TODO nez jel ovo dobro
                    nacin_placanja = "GLUPANE"
                };
            //if(servicesRacuni.AddRacun(racunNovi, stavkeRacuna.ToList()))
            if(servicesRacuni.AddRacun(racunNovi, FrmUnosRacuna.listaStavki.ToList()))
            {
                MessageBox.Show("Unesen racun!");
                Close();
            }
            else
            {
                MessageBox.Show("Nekaj ni dobro!");
            }





            // TODO da prolazi kroz svaki artikl
            //servicesStavke.AddStavke(int.Parse(FrmUnosRacuna.listaStavki[0].ToString()), idRacuna, 5); // HARDKODIRANA KOLICINA I STAVKA



            FrmPocetniIzbornikVoditelj frmPocetniIzbornik = new FrmPocetniIzbornikVoditelj();
            Hide();
            frmPocetniIzbornik.ShowDialog();
            Close();
        }

        private void btnIzradiIGenerirajPdf_Click(object sender, EventArgs e)
        {

        }
        /*
        public void AddStavka(StavkaRacuna stavka)
        {
            if (!stavkeRacuna.Contains(stavka))
            {
                stavkeRacuna.Add(stavka);
            }
            else
            {
                MessageBox.Show("Ovaj ste vec dodali!");
            }
        }
        */
        private void btnPovratak_Click(object sender, EventArgs e)
        {
            FrmUnosRacuna frmUnosRacuna = new FrmUnosRacuna();
            Hide();
            frmUnosRacuna.ShowDialog();
            Close();
        }

    }
}
