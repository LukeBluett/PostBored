using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostBored
{
    class Menubar
    {
        string username;
        
        public Menubar()
        {
            username = "";
            //username = "" + Member.GetUsername(); GetUsername method not created yet
        }

        public string GetUsername()
        {
            return username;
        }

        public bool IsLoggedIn()
        {
            if (username == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void UsernameBtn(Button btnUsername)
        {
            if (IsLoggedIn())
            {
                btnUsername.Text = "Username";
            }
            else
            {
                btnUsername.Text = "PostBored";
            }
        }

        public void LogInString(Button logOut)
        {
            if (IsLoggedIn())
            {
                logOut.Text = "LogOut";
            }
            else
            {
                logOut.Text = "SignIn/SignUp";
            }
        }

        public void HideCreatePost(Button btn)
        {
            if (IsLoggedIn())
            {
                btn.Text = "Create Post";
            }
            else
            {
                btn.Hide();
            }
        }

        public void SearchDatabase()
        {

        }
        public void CreatePost()
        {

        }
        public void LogOut()
        {

        }
    }
}
