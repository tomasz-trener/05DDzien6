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
    class ZawodnicyRepo
    {
        public Zawodnik[] PodajZawodnikow()
        {
            // string connString =           ConfigurationManager.ConnectionStrings["mojConnString"].ConnectionString;
            string connString =           ConfigurationManager.ConnectionStrings["mojConnString"].ConnectionString;


            PolaczenieZBaza pzb = new PolaczenieZBaza(connString);

            object[][] wynik= pzb.WykonajZapytanie(
                @"SELECT 
                   [id_zawodnika]
                  ,[id_trenera]
                  ,[imie]
                  ,[nazwisko]
                  ,[kraj]
                  ,[data_ur]
                  ,[wzrost]
                  ,[waga] 
                 FROM zawodnicy");

            // teraz musimy przekształcić tablę object[][] na Zawodnik[]

            Zawodnik[] zawodnicy = new Zawodnik[wynik.Length];
            for (int i = 0; i < zawodnicy.Length; i++)
            {
                Zawodnik z = new Zawodnik(wynik[i][2].ToString(), wynik[i][3].ToString());
                z.Id_zawodnika = Convert.ToInt32(wynik[i][0]);
                if (wynik[i][1] is int)
                    z.Id_trenera = Convert.ToInt32(wynik[i][1]);
                z.Kraj = Convert.ToString(wynik[i][4]);
                z.DataUrodzenia = Convert.ToDateTime(wynik[i][5]);
                z.Wzrost = Convert.ToInt32(wynik[i][6]);
                z.Waga = Convert.ToInt32(wynik[i][7]);
                zawodnicy[i] = z;
            }
            return zawodnicy;

        }

        public void UsunZawodnika(int id)
        {
            string connString =  ConfigurationManager.
                ConnectionStrings["mojConnString"].
                ConnectionString;

            PolaczenieZBaza pzb = new PolaczenieZBaza(connString);
            pzb.WykonajZapytanie($"delete zawodnicy where id_zawodnika={id}");
        }

        public void DodajZawodnika(Zawodnik z)
        {
            string connString =           ConfigurationManager.ConnectionStrings["mojConnString"].ConnectionString;
            PolaczenieZBaza pzb = new PolaczenieZBaza(connString);

            pzb.WykonajZapytanie(
                $"insert into zawodnicy values " +
                $"({z.Id_TreneraDB}, " +
                $"'{z.Imie}', " +
                $"'{z.Nazwisko}', " +
                $"'{z.Kraj}', " +
                $"'{z.DataUrodzenia}', " +
                $"{z.Wzrost}, " +
                $"{z.Waga})");
        }

        public void Edytuj(Zawodnik z)
        {
            string connString =           ConfigurationManager.ConnectionStrings["mojConnString"].ConnectionString;
            PolaczenieZBaza pzb = new PolaczenieZBaza(connString);

            pzb.WykonajZapytanie(
                $"update zawodnicy " +
                $"set imie = '{z.Imie}', nazwisko = '{z.Nazwisko}', kraj = '{z.Kraj}'," +
                $"data_ur = '{z.DataUrodzenia.ToString("yyyyMMdd")}', wzrost = {z.Wzrost}, waga = {z.Waga}" +
                $" where id_zawodnika = {z.Id_zawodnika}"
                );
        }
    }
}
