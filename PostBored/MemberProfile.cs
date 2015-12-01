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

        private void MemberProfile_Load(object sender, EventArgs e)
        {
            //Figure out if user is logged in
            

            //Get user details

            //show/hide details based on if user is logged in or not

            //get links details
        }

        private void btnUsername_Click(object sender, EventArgs e)
        {
            //link to users profile
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //search users details
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //logout of current user
        }

        private void LogInFormOrLogOutForm()
        {
            LogInFormOrLogOutForm();
            Menubar menu = new Menubar();

            menu.UsernameBtn(btnUsername);

            menu.HideCreatePost(btnCreatePost);
        }
    }
}
