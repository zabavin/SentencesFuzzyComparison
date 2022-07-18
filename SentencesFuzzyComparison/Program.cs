using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using System.Threading;
using System.Data.SqlClient;

namespace SentencesFuzzyComparison {
    class Program {
        static void Main(string[] args) {


            string connectionString = "Data Source=localhost;Initial Catalog=nad;User Id=sa;Password=RgH75bmLTg;"
                Dictionary<string,string> lsd= new Dictionary<string, string>;
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select [c_address_original],[c_address_full] from [nad].[dbo].[Nadirly_krasnodar_out] ", con))
                    {
                        con.Open();
                        
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lsd.Add(reader[0].ToString(), reader[1].ToString());
                               

                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {

              //  Log.Fatal("Merch_id:" + merch_id + "  An error occurred while reading from the database! " + e.Message);
            
            }
            //end read data from DB POS

            ////////////////////////////////////////
            //HIPERLOOP by orders readed previosly orders in ODT
            ////////////////////////////////////////
            FuzzyComparer fc = new FuzzyComparer();
            foreach (var item in lsd)
            {
                using (SqlConnection conn = new SqlConnection("connectionString"))
                {
                    using (SqlCommand cmd = new SqlCommand( @"INSERT INTO klant(klant_id,naam,voornaam)  VALUES(@param1,@param2,@param3)"))
                    { 

                        cmd.Parameters.AddWithValue("@param1", klantId);
                        cmd.Parameters.AddWithValue("@param2", klantNaam);
                        cmd.Parameters.AddWithValue("@param3", klantVoornaam);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                        catch (SqlException e)
                        {
                            MessgeBox.Show(e.Message.ToString(), "Error Message");
                        }

                    }
                }
                double d = fc.CalculateFuzzyEqualValue(item.Key, item.Value);
            }

            Console.ReadLine();
        }
    }
}
