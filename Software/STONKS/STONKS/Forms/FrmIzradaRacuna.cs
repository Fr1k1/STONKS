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

        private void FrmIzradaRacuna_Load(object sender, EventArgs e)
        {
            var allNaciniPlacanja = new NaciniPlacanjaServices().GetNaciniPlacanja();

            List<NacinPlacanja> novaListaNacinaPlacanja = allNaciniPlacanja;
            novaListaNacinaPlacanja.RemoveAt(0); // removed "All" from default NaciniPlacanja list
            cboOdabirNacinaPlacanja.DataSource = novaListaNacinaPlacanja;
        }

        private void btnIzradiRacun_Click(object sender, EventArgs e)
        {
            insertajRacun();
            povratakNaMeni();
        }

        private void btnIzradiIGenerirajPdf_Click(object sender, EventArgs e)
        {
            insertajRacun();
            generirajPdf();
            povratakNaMeni();
        }

        private void btnPovratak_Click(object sender, EventArgs e)
        {
            FrmUnosRacuna frmUnosRacuna = new FrmUnosRacuna();
            Hide();
            frmUnosRacuna.ShowDialog();
            Close();
        }

        private void povratakNaMeni() 
        {


            //FrmPocetniIzbornikVoditelj frmPocetniIzbornik = new FrmPocetniIzbornikVoditelj();
            Hide();
            FrmFaceRecNewApproach.CheckLogirani(FrmFaceRecNewApproach.logiraniKorisnik.uloga_id);

            //frmPocetniIzbornik.ShowDialog();
            Close();
        }

        private void insertajRacun()
        {
            var selectedNacinPlacanja = cboOdabirNacinaPlacanja.SelectedItem as NacinPlacanja;
            var racunNovi = new Racun
            {
                nacin_placanja_id = selectedNacinPlacanja.id,
                korisnik_id = 1, // TODO logged user
                vrijeme_izdavanja = DateTime.Now,
                ukupno = FrmUnosRacuna.ukupnoUnos,
                popust = FrmUnosRacuna.ukupanPopust, 
                pdv = FrmUnosRacuna.ukupnoUnos - (FrmUnosRacuna.ukupnoUnos * 0.75), // TODO nez kaj s ovim
                cjena_bez_pdv = FrmUnosRacuna.ukupnoUnos - (FrmUnosRacuna.ukupnoUnos * 0.25), // TODO nez kaj s ovim
            };
            if (servicesRacuni.AddRacun(racunNovi, FrmUnosRacuna.listaStavkiURacunu.ToList()))
            {
                MessageBox.Show("Unesen racun!");
                Close();
            }
            else
            {
                MessageBox.Show("Neuspjesno unosenje racuna!");
            }
        }

        private void generirajPdf()
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
