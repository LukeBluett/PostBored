using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostBored
{
    public partial class MemberProfile : Form
    {
        public MemberProfile()
        {
            InitializeComponent();
        }

        Menubar menu = new Menubar();

        private void MemberProfile_Load(object sender, EventArgs e)
        {
            //Figure out if user is logged in
            LogInFormOrLogOutForm();

            //Get user details
            GetUserDetails();

            //show/hide details based on if user is logged in or not


            //get links details


        }

        private void btnUsername_Click(object sender, EventArgs e)
        {
            //link to users profile
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            menu.SearchDatabase();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            menu.LogOut();
        }

        private void LogInFormOrLogOutForm()
        {

            menu.UsernameBtn(btnUsername);
            menu.LogInString(btnLogout);
            menu.HideCreatePost(btnCreatePost);
        }

        private void GetUserDetails()
        {
            //Get Details of the specific member
            //lblUsername.Text += member.getMember();
            DateTime value = new DateTime(2014, 1, 18);
            //Member member = new Member("Name", "email", 1234567890, null, value, false, value, 5, 7);
            connection connection = new connection();
            string userName = GetSingleValue("Select Username from member where username = 'Luke1001'", "Username");
            string email = GetSingleValue("Select Username from member where username = 'Luke1001'", "Username");
            long phone = Convert.ToInt32(GetSingleValue("Select Username from member where username = 'Luke1001'", "Username"));
            System.Drawing.Image image = null;
            System.DateTime joinDate = DateTime.Now;
            bool msgPrivate = false;
            System.DateTime lastSeen = DateTime.Now;
            int postsMade = 0;
            int likesReceived = 0;
            Member member = new Member(userName, email, phone, image, joinDate, msgPrivate, lastSeen, postsMade, likesReceived);
            
            lblUsername.Text += member.Username;
            lblEmail.Text += member.Email;
            lblPhoneNumber.Text += member.Phone;
            lblJoinDate.Text += member.JoinDate;
            lblPostsMade.Text += member.PostsMade;
            lblLikesReceived.Text += member.LikesReceived;
            


            /*
            Random rnd = new Random();
            Member member = new Member();

            member.Username = txtTitle.Text;
            member.Email = txtText.Text;
            member.Phone = txtTag.Text;
            member.JoinDate = DateTime.Now.ToString("dd-MMM-yy hh:mm:ss:fffffff");
            member.PostsMade = 0;
            member.LikesReceived = 0;

            FileStream fls = new FileStream(imagename, FileMode.Open, FileAccess.Read);
            byte[] blob = new byte[fls.Length];
            fls.Read(blob, 0, Convert.ToInt32(fls.Length));
            fls.Close();

            member.Image = blob;


            PostDaoImpl dao = new PostDaoImpl();

            dao.createPost(member);
            */
        }

        private void btnCreatePost_Click(object sender, EventArgs e)
        {
            menu.CreatePost();
        }

        public static String GetSingleValue(String strSQL, String ColName)
        {
            String GetSingleValue = "";

            try
            {
                String oradb = connection.GetConnection();

                OracleConnection conn = new OracleConnection(oradb);

                OracleCommand cmd = new OracleCommand(strSQL, conn);

                cmd.CommandType = CommandType.Text;

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                OracleDataAdapter orada = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                orada.Fill(dt);

                int RowCount = dt.Rows.Count;
                string row = RowCount.ToString();


                if (RowCount > 0)
                {
                    GetSingleValue = dt.Rows[0][ColName].ToString().Trim();
                }
                conn.Close();
            }
            catch (OracleException e)
            {
            }

            return GetSingleValue;
        }
    }
}
