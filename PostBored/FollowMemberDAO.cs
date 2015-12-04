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
        OracleConnection conn;

        public FollowMemberDAO()
        {
            conn = new OracleConnection();
            conn.ConnectionString = connectionString;
        }
        public void SelectFriendUsername()
        {
            try
            {
                conn.Open();
                OracleCommand command = conn.CreateCommand();
                string sql = "Select FRIEND_USERNAME from FOLLOW_MEMBERS where USERNAME = '" + username2 + "'";
                command.CommandText = sql;
                MessageBox.Show(""+sql);
                OracleDataReader reader = command.ExecuteReader();
                ArrayList listOfMembersFollowed = new ArrayList();
                while (reader.Read())
                {
                    // MessageBox.Show("TAG: " + tag);
                    follwerUsername = (string)reader["Friend_Username"];
                    listOfMembersFollowed.Add(follwerUsername);
                }
                MessageBox.Show("Added tag to arraylist --- " + listOfMembersFollowed.Count);

            }
            finally
            {
                conn.Close();
            }

        }
    }
}
