using P03BibliotekaPolaczenieZBaza;
using P05AplikacjaZawodnicy.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05AplikacjaZawodnicy.Repositories
{
    class TrenerzyRepo
    {
        public Trener[] PodajTrenerow()
        {
            string connString = ConfigurationManager.ConnectionStrings["mojConnString"].ConnectionString;
            PolaczenieZBaza pzb = new PolaczenieZBaza(connString);
            object[][] wynik = pzb.WykonajZapytanie(
                @"SELECT 
                  [id_trenera]
                  ,[imie_t]
                  ,[nazwisko_t]
                  ,[data_ur_t]
                 FROM trenerzy");
            // teraz musimy przekształcić tablę object[][] na Trener[]
            Trener[] trenerzy = new Trener[wynik.Length];
            for (int i = 0; i < trenerzy.Length; i++)
            {
                Trener t = new Trener();
                t.Id = Convert.ToInt32(wynik[i][0]);
                t.Imie = wynik[i][1].ToString();
                t.Nazwisko = wynik[i][2].ToString();
                if (t.DataUr is DateTime)
                   t.DataUr = Convert.ToDateTime(wynik[i][3]);
                trenerzy[i] = t;
            }
            return trenerzy;

        }
    }
}
