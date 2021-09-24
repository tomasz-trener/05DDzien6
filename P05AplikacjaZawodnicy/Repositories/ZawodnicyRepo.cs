﻿using P03BibliotekaPolaczenieZBaza;
using P05AplikacjaZawodnicy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05AplikacjaZawodnicy.Repositories
{
    class ZawodnicyRepo
    {

        public Zawodnik[] PodajZawodnikow()
        {
            string connString = "Data Source=.;Initial Catalog=A_Zawodnicy;User ID=sa;Password=alx";

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


    }
}