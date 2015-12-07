using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostBored
{
    class MemberDAOImpl
    {
        public string getPassword()
        {
            var base64EncodedBytes = System.Convert.FromBase64String("");
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public void createPost(Member member)
        {
            try
            {


                String connstr = "Data source = studentoracle.students.ittralee.ie/orcl;User id = t00171832;Password=" + getPassword() + ";";
                OracleConnection conn = new OracleConnection(connstr);
                conn.Open();
            
                string query = "insert into posts values('" + member.Username + "', '" + member.Email + "' , " + member.Phone + " , :BlobParameter , '" + member.Image + "' , '"
                    + member.JoinDate + "' , " + member.MsgPrivate + " , '" + member.LastSeen + "'," + member.PostsMade + "," + member.LikesReceived + ")";
                MessageBox.Show(query);
                //insert the byte as oracle parameter of type blob 
                OracleParameter blobParameter = new OracleParameter();
                blobParameter.OracleType = OracleType.Blob;
                blobParameter.ParameterName = "BlobParameter";
                blobParameter.Value = member.Image;

                OracleCommand cmnd = new OracleCommand(query, conn);
                cmnd.Parameters.Add(blobParameter);
                cmnd.ExecuteNonQuery();
                cmnd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
            }
        }

        public void DeleteMember(int Email)
        {
            throw new NotImplementedException();
        }

        public List<Member> GetAllMember()
        {
            throw new NotImplementedException();
        }

        public Member GetMember(int Email)
        {
            throw new NotImplementedException();
        }
    }
}
