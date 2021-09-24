using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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


            try
            {
                connection.Open();

                dataReader = command.ExecuteReader(); // wyslanie polecenia sql do bazy 
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
                    // mozna tak spracac czy wnik to int (not nullable)
                    bool a = dataReader.GetValue(1) is int;
                    Console.WriteLine(a);

                    //tak mozna wprost sprawdzic nazwę tpyu i potem np sprawdzćzy czy to in
                    Console.WriteLine(dataReader.GetValue(1).GetType().FullName);

                    //int? bb = ToNullable((SqlInt32)dataReader.GetValue(1));
                    //Console.WriteLine(bb);
                    //   Console.WriteLine(dataReader.GetValue(1) == null);

                    //  int? a = (int?)dataReader.GetValue(1);

                    //można też używać tryparse do próby konwersji typu na int 
                    //   int a;
                    //   int.TryParse(Convert.ToString(dataReader.GetValue(1)), out a);

                    //  Nullable<int> a = (Nullable<int>)dataReader.GetValue(1);


                    Console.WriteLine(dataReader.GetValue(2) + " " + dataReader.GetValue(3));

                }
            }
            catch (Exception)
            {
                Console.WriteLine("error");
            }
            finally //to się wkykona zawsze niezaleznie czy blad jest czy nie
            {
                connection.Close();
            }    
            
           
            int b = 3;
            string s1 = b.ToString();
            string s2 = Convert.ToString(b);


           

            Console.ReadKey();

        }

    
    }
}
