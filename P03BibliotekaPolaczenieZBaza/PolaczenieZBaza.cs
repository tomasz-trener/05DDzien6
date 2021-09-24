using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03BibliotekaPolaczenieZBaza
{
    public class PolaczenieZBaza
    {
        string connString;

        public PolaczenieZBaza(string connString)
        {
            this.connString = connString;
        }

        public object[][] WykonajZapytanie(string sql)
        {
            SqlConnection connection; // do komunikacji z baza danych 
            SqlCommand command; // przechowywanie polecen SQL 
            SqlDataReader dataReader; // czytanie odpowiedzi z bazy danych 

            connection = new SqlConnection(connString);
            command = new SqlCommand(sql, connection);

            List<object[]> listawierszy = new List<object[]>();

            try
            {
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    object[] wiersz = new object[dataReader.FieldCount];
                    for (int i = 0; i < dataReader.FieldCount; i++)
                        wiersz[i] = dataReader.GetValue(i);

                    listawierszy.Add(wiersz);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return listawierszy.ToArray();
        }
        



    }
}
