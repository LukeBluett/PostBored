using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace PostBored
{
    class TagsDAO
    {

        //private string connectionString = PostBored.connection.GetConnection();
       
        public TagsDAO()
        {
        }
        public static void subscribeTags()
        {
            String username2 = "luke1000";

            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = PostBored.connection.GetConnection();
            try
            {
                OracleCommand command = conn.CreateCommand();
                string sql = "Select tag from Follow_tag where Username = '" + username2 + "'";
                command.CommandText = sql;

                MessageBox.Show("got to here5"+sql);
                conn.Open();
                OracleDataReader reader = command.ExecuteReader();
                ArrayList arraylist = new ArrayList();
                while (reader.Read())
                {
                    string tag = (string)reader["Tag"];
                    arraylist.Add(tag);

                }
                //get last visted
         
                var list = new List<KeyValuePair<string,int>>();
                while (arraylist.Count !=0)
                {


                    string sql2 = "select count(Post_ID) where tag '" + tag+"'AND '"+lastVisted + "'< Post_time";
                }
            }
            finally
            {

                conn.Close();
            }
            

        }
    }
}
