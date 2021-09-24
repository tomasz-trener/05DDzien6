using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01PolaczenieZBaza
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection; // do komunikacji z baza danych 
            SqlCommand command; // przechowywanie polecen SQL 
            SqlDataReader dataReader; // czytanie odpowiedzi z bazy danych 


            string connString = "Data Source=.;Initial Catalog=A_Zawodnicy;User ID=sa;Password=alx";
            connection = new SqlConnection(connString);

            command = new SqlCommand("SELECT * FROM zawodnicy", connection);
            connection.Open();

            dataReader= command.ExecuteReader(); // wyslanie polecenia sql do bazy 
                                                 // dataReader jest uchwytem do wyniku 
                                                 //     dataReader.Read();
                                                 //     string wynik = (string)dataReader.GetValue(3);
                                                 ////     string wynik = Convert.ToString(dataReader.GetString(2));
                                                 //     Console.WriteLine(wynik);

            //dataReader.Read();
            //wynik = (string)dataReader.GetValue(3);
            //Console.WriteLine(wynik);

            while (dataReader.Read())
            {
             //   Console.WriteLine(dataReader.GetValue(1) == null);

                //  int? a = (int?)dataReader.GetValue(1);

                    int a;
                    int.TryParse(Convert.ToString(dataReader.GetValue(1)), out a);
              
                //  Nullable<int> a = (Nullable<int>)dataReader.GetValue(1);

              //  Console.WriteLine(a);
                Console.WriteLine(dataReader.GetValue(2) + " "+  dataReader.GetValue(3));
            }

            int b = 3;
            string s1 = b.ToString();
            string s2 = Convert.ToString(b);


            connection.Close();

            Console.ReadKey();

        }
    }
}
