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
        public string username2 = "Luke1000";
        private string follwerUsername = "";
        private string connectionString = PostBored.connection.GetConnection();
        public Dictionary<string, int> followMember;
        public HashSet<string> followMemberHashSet;
        OracleConnection conn;
        int numOfPosts;

        public FollowMemberDAO()
        {
            conn = new OracleConnection();
            conn.ConnectionString = connectionString;
            followMember = new Dictionary<string, int>();
            followMemberHashSet = new HashSet<string>();
        }
        public void SelectFriendUsername()
        {
            try
            {
                conn.Open();
                OracleCommand command = conn.CreateCommand();
                string sql = "Select FRIEND_USERNAME from FOLLOW_MEMBERS where USERNAME = '" + username2 + "'";
                command.CommandText = sql;
                OracleDataReader reader = command.ExecuteReader();
                ArrayList listOfMembersFollowed = new ArrayList();
                while (reader.Read())
                {
                    follwerUsername = (string)reader["Friend_Username"];
                    listOfMembersFollowed.Add(follwerUsername);
                }

                int size = listOfMembersFollowed.Count;
                for (int i = 0; i < size; i++)
                {

                    string sql2 = "Select count(*) As post_id from posts where Username ='" + listOfMembersFollowed[i].ToString() + "'";
                    //AND '" + lastseen + "'< Post_time
                    command.CommandText = sql2;

                    string num = command.ExecuteScalar().ToString();
                    numOfPosts = Int32.Parse(num);
                    if (numOfPosts != 0)
                    {
                        string userFollowed = listOfMembersFollowed[i].ToString();
                        followMember.Add(userFollowed, numOfPosts);
                    }
                }
            }
            finally
            {
                conn.Close();
            }

        }
        public void GetPopularMembers()
        {
            try
            {
                conn.Open();
                OracleCommand command = conn.CreateCommand();
                string sql = "Select username from members";
                command.CommandText = sql;
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    follwerUsername = (string)reader["Username"];
                    followMemberHashSet.Add(follwerUsername);
                }
                /*foreach (string j in followMemberHashSet)
                {
                    MessageBox.Show("" + j);
                }*/
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
