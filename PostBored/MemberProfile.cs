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
            string userName = GetSingleValue("Username", connection.GetConnection());

            Member member = new Member(userName, "email", 1234567890, null, value, false, value, 5, 7);//, email, phone, image, joinDate, msgPrivate, lastSeen, postsMade, likesReceived);
            
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

        public string GetSingleValue(string newName, string connString)
        {
            string Value = "";
            string sql =
                "SELECT " + newName + " FROM Members";
            using (OracleConnection conn = new OracleConnection(connString))
            {
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add("@Name", OracleType.VarChar);
                cmd.Parameters["@name"].Value = newName;
                try
                {
                    conn.Open();
                    Value = (string)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return Value;
        }
    }
}
