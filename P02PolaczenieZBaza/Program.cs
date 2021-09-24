using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02PolaczenieZBaza
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = "Data Source=.;Initial Catalog=A_Zawodnicy;User ID=sa;Password=alx";

            PolaczenieZBaza pzb = new PolaczenieZBaza(connString);

            object[][] tab= pzb.WykonajZapytanie("select * from zawodnicy");

            for (int i = 0; i < tab.Length; i++)
            {
                for (int j = 0; j < tab[i].Length; j++)
                    Console.Write(tab[i][j] + " ");
                Console.WriteLine();
            }

            Console.ReadKey();


        }
    }
}
