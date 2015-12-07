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
        public HashSet<string> hashSet;
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
            hashSet = new HashSet<string>();
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
                    tag = (string)reader["Tag"];
                    arraylist.Add(tag);
                }
                int size = arraylist.Count;
                    for (int i = 0; i < size; i++)
                    {

                        string sql2 = "Select count(*) As post_id from posts where tag ='" + arraylist[i].ToString() + "'";
                        //AND '" + lastseen + "'< Post_time
                        command.CommandText = sql2;

                        string num = command.ExecuteScalar().ToString();
                        numOfTimePosted = Int32.Parse(num);
                        if (numOfTimePosted != 0)
                    {
                        string tag = arraylist[i].ToString();
                        dict.Add(tag,numOfTimePosted);

                        }
                        
                    }
                
                
            }
            finally
            {

                conn.Close();
            }
            

        }
        public void SelectPopularTags()
        {
            try
            {
                conn.Open();
                OracleCommand command = conn.CreateCommand();
                string sql = "Select tag from posts";
                command.CommandText = sql;
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tag = (string)reader["Tag"];
                    hashSet.Add(tag);
                }
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
