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

                MessageBox.Show("Added tag to arraylist");
                //get last visted
                string dateString = "5/1/2008 8:30:52 AM";
                DateTime lastVisted = DateTime.Parse(dateString,
                                          System.Globalization.CultureInfo.InvariantCulture);

                MessageBox.Show("created time");
                Dictionary<string,int> dict = new Dictionary<string,int>();

                MessageBox.Show("created dictionary");
                while (arraylist.Count != 0)
                {

                    MessageBox.Show("went inside the while");
                    for (int i = 0; i < arraylist.Count; i++)
                    {

                        MessageBox.Show("Went inside the for");
                        MessageBox.Show("Item in array "+arraylist[i]);
                        string sql2 = "select count(Post_ID) where tag '" + arraylist[i] + "'AND '" + lastVisted + "'< Post_time";
                        command.CommandText = sql2;

                        MessageBox.Show("created the command");
                        int numOfTimePosted = (int)command.ExecuteScalar();

                        MessageBox.Show("executing command");
                        string tag = arraylist[i].ToString();
                        dict.Add(tag,numOfTimePosted);

                        MessageBox.Show("Added item to dictionary");
                        
                        
                    }
                }
                foreach (KeyValuePair<string, int> kv in dict)
                {
                    MessageBox.Show(kv.ToString());
                }
            }
            finally
            {

                conn.Close();
            }
            

        }
    }
}
