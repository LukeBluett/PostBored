using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostBored
{
    class FollowMemberDAO
    {
        string username2 = "Luke1000";
        private string follwerUsername = "";
        private string connectionString = PostBored.connection.GetConnection();
        public Dictionary<string, int> followMember;
        OracleConnection conn;
        int numOfPosts;

        public FollowMemberDAO()
        {
            conn = new OracleConnection();
            conn.ConnectionString = connectionString;
            followMember = new Dictionary<string, int>();
        }
        public void SelectFriendUsername()
        {
            try
            {
                conn.Open();
                OracleCommand command = conn.CreateCommand();
                string sql = "Select FRIEND_USERNAME from FOLLOW_MEMBERS where USERNAME = '" + username2 + "'";
                command.CommandText = sql;
                //MessageBox.Show(""+sql);
                OracleDataReader reader = command.ExecuteReader();
                ArrayList listOfMembersFollowed = new ArrayList();
                while (reader.Read())
                {
                    // MessageBox.Show("TAG: " + tag);
                    follwerUsername = (string)reader["Friend_Username"];
                    listOfMembersFollowed.Add(follwerUsername);
                }
               // MessageBox.Show("Added tag to arraylist --- " + listOfMembersFollowed.Count);

                int size = listOfMembersFollowed.Count;
                for (int i = 0; i < size; i++)
                {
                    //MessageBox.Show("Item in array "+arraylist[i].ToString());

                    string sql2 = "Select count(*) As post_id from posts where Username ='" + listOfMembersFollowed[i].ToString() + "'";
                    //AND '" + lastseen + "'< Post_time
                    command.CommandText = sql2;

                    //MessageBox.Show(""+sql2);
                    string num = command.ExecuteScalar().ToString();
                    numOfPosts = Int32.Parse(num);
                    //MessageBox.Show("Added to the dictionary" + numOfPosts);
                    if (numOfPosts != 0)
                    {
                        string userFollowed = listOfMembersFollowed[i].ToString();
                        followMember.Add(userFollowed, numOfPosts);
                        //MessageBox.Show("Added to the dictionary");
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
