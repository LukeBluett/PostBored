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
   
    public partial class Register: Form
    {
        Member member;
        MembersDAO dao;
        public Register()
        {
            InitializeComponent();
            dao = new MembersDAO();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            DateTime dateNow = DateTime.Now;
            
            member = new Member(txtUserName.Text, txtEmail.Text,txtPhone.Text,null, dateNow, false, dateNow, 0, 0);
            dao.InsertMember(member);
            //TODO
            //dao.UpdateImage();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
           
        }
    }
}
