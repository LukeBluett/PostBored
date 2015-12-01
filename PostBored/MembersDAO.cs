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
        private System.Drawing.Image image;
        OracleConnection conn;

        public MembersDAO()
        {
            conn = new OracleConnection();
            conn.ConnectionString = connectionString;
        }

        public void SelectAllMembers()
        {
            try
            {
                
                    
                    conn.Open();

                    OracleCommand command = conn.CreateCommand();
                    string sql = "Select * from members;" ;
                    command.CommandText = sql;
                    OracleDataReader reader = command.ExecuteReader();
                    MessageBox.Show("starting");
                    while (reader.Read())
                    {
                        username = (string)reader["Username"];
                     
                    }

                    conn.Close();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred:", e);
            }

        }
        public Member AuthenticateUser(String username,String password)
        {
            
            conn.Open();

            OracleCommand command = conn.CreateCommand();
            string sql = "Select * from members where username = " + username + "&& password =" + password;
            command.CommandText = sql;
            OracleDataReader reader = command.ExecuteReader();


            Member member = new Member();

            return Member;
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
