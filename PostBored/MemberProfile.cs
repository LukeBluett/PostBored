using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            Member member = new Member("Name", "email", 1234567890, null, value, false, value, 5, 7);
            
            lblUsername.Text += member.Username;
            lblEmail.Text += member.Email;
            lblPhoneNumber.Text += member.Phone;
            lblJoinDate.Text += member.JoinDate;
            lblPostsMade.Text += member.PostsMade;
            lblLikesReceived.Text += member.LikesReceived;
        }

        private void btnCreatePost_Click(object sender, EventArgs e)
        {
            menu.CreatePost();
        }
    }
}
