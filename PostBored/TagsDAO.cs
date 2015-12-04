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
        string username2 = "Luke1000";
        private string tag;
        public ArrayList arraylist;
        public Dictionary<string, int> dict;
        private string connectionString = PostBored.connection.GetConnection();
        OracleConnection conn;
        DateTime lastseen;
        int numOfTimePosted;

        public TagsDAO()
        {

            conn = new OracleConnection();
            conn.ConnectionString = connectionString;
            //lastseen = new DateTime("01-DEC-15 12:57:37.00","");
            //Runs Selecttag method ??
            arraylist = new ArrayList();
            dict = new Dictionary<string, int>();
        }

        public void SelectTags()
        {
            try
            {
                conn.Open();
                OracleCommand command = conn.CreateCommand();
                string sql = "Select tag from Follow_Tag where Username = '" + username2 + "'";
                command.CommandText = sql;
                OracleDataReader reader = command.ExecuteReader();
                ArrayList arraylist = new ArrayList();
                while (reader.Read())
                {
                   // MessageBox.Show("TAG: " + tag);
                    tag = (string)reader["Tag"];
                    arraylist.Add(tag);
                }
               // MessageBox.Show("Added tag to arraylist --- " + arraylist.Count);
                int size = arraylist.Count;
                    for (int i = 0; i < size; i++)
                    {

                        //MessageBox.Show("Item in array "+arraylist[i].ToString());

                        string sql2 = "Select count(*) As post_id from posts where tag ='" + arraylist[i].ToString() + "'";
                        //AND '" + lastseen + "'< Post_time
                        command.CommandText = sql2;

                        //MessageBox.Show(""+sql2);
                        string num = command.ExecuteScalar().ToString();
                        numOfTimePosted = Int32.Parse(num);

                        string tag = arraylist[i].ToString();
                        dict.Add(tag,numOfTimePosted);

                        //MessageBox.Show("Added item to dictionary");
                        
                        
                    }
                
                
            }
            finally
            {

                conn.Close();
            }
            

        }
    }
}
