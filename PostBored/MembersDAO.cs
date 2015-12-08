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
                //MessageBox.Show(ex.Message);
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

            Image image; DateTime lastSeen, joinDate;
            bool msgPrivate;
            int postsMade, likesReceived;

            username = "Ian1001";// (String)ds.Tables["ss"].Rows[0].ItemArray[0];
            email = "ian@gmail.com";// (String)ds.Tables["ss"].Rows[0].ItemArray[1];
            phone = 087555; //(long)ds.Tables["ss"].Rows[0].ItemArray[3];
            //joinDate = (DateTime)ds.Tables["ss"].Rows[0].ItemArray[4];
            msgPrivate = true; //(bool)ds.Tables["ss"].Rows[0].ItemArray[5];
            // lastSeen =(DateTime)ds.Tables["ss"].Rows[0].ItemArray[6];
            joinDate =  new DateTime(2015,12,15);
            lastSeen = new DateTime(2015, 12, 15);
            postsMade = 44;// (int)ds.Tables["ss"].Rows[0].ItemArray[7];
            likesReceived =  (int)ds.Tables["ss"].Rows[0].ItemArray[8];

            // image = returnImage(()ds.Tables["ss"].Rows[0].ItemArray[4];)
            image = null;

            Member member = new Member(username, email, phone,image, joinDate, msgPrivate,lastSeen, postsMade, likesReceived);
                

            return member;
        }
       

        public void InsertMember(Member member)
        {
            try {
                conn.Open();
                string query = "insert into members values('" + member.Username + "', '" + member.Email + "' , " + member.Phone + " , :BlobParameter , '" + member.Image + "' , '"
                    + member.JoinDate + "' , " + member.MsgPrivate + " , '" + member.LastSeen + ")";
                MessageBox.Show(query);

                cmd = new OracleCommand(query, conn);
                cmd.ExecuteNonQuery();
            }catch(Exception ex)
            {

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
                String sql = "Update  Members Set Imagev= :BlobParameter  where username = " + username;
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
