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

        MembersDAO memDao;
        string username2 = "Luke1000";
        private string tag;
        public ArrayList arraylist;
        public Dictionary<string, int> dict;
        private string connectionString = PostBored.connection.GetConnection();
        OracleConnection conn;
        string username = "";
        DateTime lastseen;

        public TagsDAO()
        {

            conn = new OracleConnection();
            conn.ConnectionString = connectionString;
            memDao = new MembersDAO();
            lastseen = memDao.lastSeen;
            username = memDao.username;
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
                    MessageBox.Show("TAG: " + tag);
                    tag = (string)reader["Tag"];
                    arraylist.Add(tag);
                }
                MessageBox.Show("Added tag to arraylist --- " + arraylist.Count);
                int size = arraylist.Count;
                while (size > 0)
                {

                    MessageBox.Show("went inside the while");
                    for (int i = 0; i < size; i++)
                    {

                        MessageBox.Show("Went inside the for");
                        MessageBox.Show("Item in array "+arraylist[i]);

                        string sql2 = "select count(Post_ID) from Posts where tag ='" + arraylist[i] + "'";
                        //AND '" + lastseen + "'< Post_time
                        command.CommandText = sql2;

                        MessageBox.Show("created the command");
                        int numOfTimePosted = (int)command.ExecuteScalar();

                        MessageBox.Show("executing command"+ numOfTimePosted);
                        string tag = arraylist[i].ToString();
                        dict.Add(tag,numOfTimePosted);

                        MessageBox.Show("Added item to dictionary");
                        
                        
                    }
                }
                
            }
            finally
            {

                conn.Close();
            }
            

        }
    }
}
