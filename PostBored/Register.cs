using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostBored
{
   
    public partial class Register: Form
    {
       private Member member;
       private  MembersDAO dao;
        private Image image;
        private ImageDAO ido;
        public Register()
        {
            InitializeComponent();
            dao = new MembersDAO();
            image = null;
            ido = new ImageDAO();
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
            member = new Member(txtUserName.Text, txtEmail.Text,long.Parse(txtPhone.Text),null, dateNow, false, dateNow);
            dao.InsertMember(member);
            dao.UpdateMemberImage(image, member.Username);
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            image = ido.getImageFromFile();
        }
    }
}
