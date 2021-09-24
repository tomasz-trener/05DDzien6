using P03BibliotekaPolaczenieZBaza;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P04AplikacjaOkienkowa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnWykonajPolecenie_Click(object sender, EventArgs e)
        {
            string connString = "Data Source=.;Initial Catalog=A_Zawodnicy;User ID=sa;Password=alx";

            PolaczenieZBaza pzb = new PolaczenieZBaza(connString);
            object[][] wynik = pzb.WykonajZapytanie(txtPolecenieSQL.Text);


            dgvDane.Rows.Clear();
            dgvDane.ColumnCount = wynik[0].Length;// najpierw trzeba ustawić liczbe kolumn w dgv

            for (int i = 0; i < wynik.Length; i++)
                dgvDane.Rows.Add(wynik[i]);

        }
    }
}
