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
    public partial class LogIn : Form
    {
        MembersDAO memberDAO;
        Member member;
        public LogIn()
        {
            InitializeComponent();
            memberDAO = new MembersDAO();
            
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            //dfgdfgjihuih   ohh
            //member = memberDAO.(txtUsername, txtPassword);
        }
    }
}           
