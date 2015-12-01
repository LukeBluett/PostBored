using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Data;
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
        OracleCommand cmd;
        OracleDataAdapter da;
        DataSet ds;
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
      /*  public Member AuthenticateUser(String username,String password)
        {
            
            conn.Open();

            cmd = conn.CreateCommand();
            string sql = "Select * from members where username = " + username + "&& password =" + password;
            cmd = new OracleCommand(sql);
            cmd.CommandType = CommandType.Text;
            da = new OracleDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "ss");




            Member member = createMemberImpl(da);

            return member;
        }

        private Member createMemberImpl(OracleDataAdapter ds)
        {
            Member member = null;

            return member;
        }*/
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
