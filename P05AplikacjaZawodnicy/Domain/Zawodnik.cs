using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05AplikacjaZawodnicy.Domain
{
    public class Zawodnik
    {
        public int Id_zawodnika;
        public int? Id_trenera;
        public string Imie;
        public string Nazwisko { get; set; }
        public string Kraj;
        public DateTime DataUrodzenia;
        public int Wzrost;
        public int Waga;


        public string Wiersz
        {
            get
            {
                return $"{Id_zawodnika};{Id_trenera};{Imie};{Nazwisko};{Kraj};{DataUrodzenia};{Wzrost};{Waga}";
            }
        }

        public string ImieNazwisko { get { return Imie + " " + Nazwisko; } }

        public string ImieNazwiskoWzrost
        {
            get { return ImieNazwisko + " " + Wzrost; }
        }

        // poniewaz nie ma w tej klasie zdefiniowanych żadnych innych konstruktórow 
        // to obecnie jedyną możliwością jest stworzenie nowego zawodnika używajac 
        // tego konstruktra dwu argumentowego 
        public Zawodnik(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }

        public string PrzedstawSie()
        {
            return string.Format("Nazywam się {0} {1} i pochodze z {2}",
                Imie, Nazwisko, Kraj);
        }

    }
}
