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

        private string connectionString = PostBored.connection.GetConnection();
        private string username, email;
        private long phone;
        private DateTime joinDate, lastSeen;
        private 

        public void SelectMember(String username,String password)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection())
                {
                    conn.ConnectionString = connectionString;
                    conn.Open();

                    OracleCommand command = conn.CreateCommand();
                    string sql = "Select * from members where username = " + username+ "&& password =" + password  ;
                    command.CommandText = sql;
                    OracleDataReader reader = command.ExecuteReader();
                    MessageBox.Show("starting");
                    while (reader.Read())
                    {
                        username = (string)reader["Username"];
                     
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
        public 
    }
}
