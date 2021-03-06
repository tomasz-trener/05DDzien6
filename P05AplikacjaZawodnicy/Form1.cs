using P05AplikacjaZawodnicy.Domain;
using P05AplikacjaZawodnicy.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P05AplikacjaZawodnicy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnWczytaj_Click(object sender, EventArgs e)
        {
            Odswiez();
        }

        private void Odswiez()
        {
            ZawodnicyRepo zr = new ZawodnicyRepo();
            lbDane.DataSource = zr.PodajZawodnikow();
            lbDane.DisplayMember = "ImieNazwiskoWzrost";

            txtWzrost.Text = 
                ((Zawodnik[])lbDane.DataSource).Sum(x => x.Wzrost).ToString();

            TrenerzyRepo tr = new TrenerzyRepo();

            List<Trener> trenerzy = tr.PodajTrenerow().ToList();
            trenerzy.Insert(0,new Trener());
            cbTrener.DataSource = trenerzy.ToArray();
            cbTrener.DisplayMember = "ImieNazwisko";
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            DialogResult dr=
            MessageBox.Show("Czy napewno chcesz usunać zaznaczony rekord?", "Pytanie",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr==DialogResult.Yes)
            {
                Zawodnik zaznaczony = (Zawodnik)lbDane.SelectedItem;

                ZawodnicyRepo zr = new ZawodnicyRepo();
                zr.UsunZawodnika(zaznaczony.Id_zawodnika);
                Odswiez();
            }
            
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            Zawodnik z = new Zawodnik(txtImie.Text, txtNazwisko.Text);
            z.Kraj = txtKraj.Text;
            z.DataUrodzenia = Convert.ToDateTime(txtDaraUr.Text);
            z.Wzrost = Convert.ToInt32(txtWzrostZ.Text);
            z.Waga = Convert.ToInt32(txtWaga.Text);

            ZawodnicyRepo zr = new ZawodnicyRepo();
            zr.DodajZawodnika(z);
            Odswiez();


        }

        private void btnEdytuj_Click(object sender, EventArgs e)
        {
            Zawodnik z = (Zawodnik)lbDane.SelectedItem;
            z.Imie = txtImie.Text;
            z.Nazwisko = txtNazwisko.Text;
            z.Kraj = txtKraj.Text;
            z.DataUrodzenia = Convert.ToDateTime(txtDaraUr.Text);
            z.Wzrost = Convert.ToInt32(txtWzrostZ.Text);
            z.Waga = Convert.ToInt32(txtWaga.Text);

            ZawodnicyRepo zr = new ZawodnicyRepo();
            zr.Edytuj(z);
            Odswiez();

        }

        private void lbDane_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zawodnik z = (Zawodnik)lbDane.SelectedItem;
            txtImie.Text = z.Imie;
            txtNazwisko.Text = z.Nazwisko;
            txtKraj.Text = z.Kraj;
            txtDaraUr.Text = z.DataUrodzenia.ToString();
            txtWaga.Text = z.Waga.ToString();
            txtWzrostZ.Text = z.Wzrost.ToString();

            Trener[] trenerzy = (Trener[])cbTrener.DataSource;
            // teraz szukamy trenera , który trenuje zawnika z 
            if (trenerzy != null)
            {
                if (z.Id_trenera != null)
                {
                    for (int i = 0; i < trenerzy.Length; i++)
                        if (trenerzy[i].Id == z.Id_trenera)
                        {
                            cbTrener.SelectedItem = trenerzy[i];
                            break;
                        }
                }
                else
                    cbTrener.SelectedIndex = 0;
            }
             
        }

        private void btnSzukaj_Click(object sender, EventArgs e)
        {
            ZawodnicyRepo zr = new ZawodnicyRepo();
            lbDane.DataSource = zr.PodajZawodnikow(txtSzukaj.Text);
            lbDane.DisplayMember = "ImieNazwiskoWzrost";
        }
    }
}
