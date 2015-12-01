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

        public string LogInString(Button logOut)
        {
            if (IsLoggedIn())
            {
                return "LogOut";
            }
            else
            {
                return "SignIn/SignUp";
            }
        }

        public void HideCreatePost(Button btn)
        {
            if (IsLoggedIn())
            {
                btn.Text = "Username";
            }
            else
            {
                btn.Text = "Username";
            }
        }
    }
}
