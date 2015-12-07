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
        public string username, email;
        public long phone;
        public DateTime joinDate, lastSeen;
        private System.Drawing.Image image;
        OracleConnection conn;
        OracleCommand cmd;
        OracleDataAdapter da;
        DataSet ds;
        Member member;
        // i put this in here so i can check if the user is loged in r not
        //public Boolean isLogedIn = false;
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
                        //getsLastSeen
                        lastSeen = (DateTime)reader["Last_Seen"];
                     
                    }

                    conn.Close();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred:", e);
            }

        }

        /**
        * Creates member if username && password match
        * returns null if not
        *TODO
        *Handle errors
        **/
        public Member AuthenticateUser(String username, String password)
        {

            conn.Open();

            cmd = conn.CreateCommand();
            string sql = "Select * from members where username = " + username + "&& password =" + password;
            cmd = new OracleCommand(sql);
            cmd.CommandType = CommandType.Text;
            da = new OracleDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "ss");


            if (ds.Tables["ss"].Rows[0].ItemArray[0].Equals(username) && ds.Tables["ss"].Rows[0].ItemArray[2].Equals(password)){
                member = createMember(ds);
                //isLogedIn = true;
                return member;
        }
            return null; 
        }
        
        private Member createMember(DataSet ds)
        {
            Member member = null;

            return member;
        }
        //getting last seen

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
