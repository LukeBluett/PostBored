using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostBored
{
    class MembersDAO 
    {

        string connectionString = PostBored.connection.GetConnection();

        public void SelectMember()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection())
                {
                    conn.ConnectionString = connectionString;
                    conn.Open();

                    OracleCommand command = conn.CreateCommand();
                    string sql = "Select * from members";
                    command.CommandText = sql;
                    OracleDataReader reader = command.ExecuteReader();
                    MessageBox.Show("starting");
                    while (reader.Read())
                    {
                        string field = (string)reader["Username"];
                        MessageBox.Show(field);
                    }

                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred:", e);
            }

        }

        public void InsertMember()
        {

        }

        public void DeleteMember()
        {

        }

        public void UpdateMember()
        {

        }
    }
}
