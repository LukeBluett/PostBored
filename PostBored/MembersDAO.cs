using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

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
            try {
                conn = new OracleConnection();
                conn.ConnectionString = connectionString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

        }

     
        public Member AuthenticateUser(String username, String password)
        {
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                string sql = "Select * from members where username = '" + username + "' AND account_password = '" + password+"'" ;
                cmd = new OracleCommand(sql);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "ss");
                if (ds.Tables["ss"].Rows[0].ItemArray[0].Equals(username) && ds.Tables["ss"].Rows[0].ItemArray[2].Equals(password))
                {
                    member = createMember(ds);
                }
                return member;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        
        //TODO
        //Retrieve BLOB Image from ds
        private Member createMember(DataSet ds)
        {
            String username, email;
            long phone;
            Image image;
            DateTime lastSeen, joinDate;
            bool msgPrivate;
           

            username =  (String)ds.Tables["ss"].Rows[0].ItemArray[0];
            email =  (String)ds.Tables["ss"].Rows[0].ItemArray[1];
            phone =  long.Parse(ds.Tables["ss"].Rows[0].ItemArray[3].ToString());
            joinDate = (DateTime)ds.Tables["ss"].Rows[0].ItemArray[5];
            int mPrivate = int.Parse(ds.Tables["ss"].Rows[0].ItemArray[6].ToString());
            if (mPrivate == 1)
                msgPrivate = true; //(bool)
            else
                msgPrivate = false;
             lastSeen =(DateTime)ds.Tables["ss"].Rows[0].ItemArray[7];
            lastSeen = new DateTime(2015, 12, 15);
            image = null;

            Member member = new Member(username, email, phone,image, joinDate, msgPrivate,lastSeen);
            return member;
        }
       

        public void InsertMember(Member member)
        {
            try {
                conn.Open();
                string query = "insert into members values('" + member.Username + "', '" + member.Email + "' , " + member.Phone +
                "' , null , '" + member.Image + "' , '"+ member.JoinDate + "' , " + member.MsgPrivate + " , '" + member.LastSeen + ")";
                MessageBox.Show(query);

                cmd = new OracleCommand(query, conn);
                cmd.ExecuteNonQuery();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally{
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public void DeleteMember(Member member)
        {
            try
            {
                conn.Open();
                String sql = "Delete from  Members where username = " + username;
                cmd = new OracleCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        public void UpdateMember(String username,String col_val) {
            try
            {
                conn.Open();
                String sql = "Update Members Set " + col_val + " where username = " + username;
                cmd = new OracleCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }catch(Exception ex)
            {

            }
            finally
            {
                if(conn.State == ConnectionState.Open)
                conn.Close();
            }

        }
        public void UpdateMemberImage(Image image,String username)
        {
            try
            {
                conn.Open();
                String sql = "Update  Members Set IMG = :BlobParameter  where username = " + username;
                OracleParameter blobParameter = new OracleParameter();
                blobParameter.OracleType = OracleType.Blob;
                blobParameter.ParameterName = "BlobParameter";
                blobParameter.Value = image;

                OracleCommand cmnd = new OracleCommand(sql, conn);
                cmnd.Parameters.Add(blobParameter);
                cmnd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        
    }
}
