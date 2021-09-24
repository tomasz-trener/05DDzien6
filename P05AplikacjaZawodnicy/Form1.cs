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
    }
}
