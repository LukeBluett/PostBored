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
        Member member;
        MembersDAO dao;
        Image image;
        public Register()
        {
            InitializeComponent();
            dao = new MembersDAO();
            image = null;
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
           
            if (image != null)
            {
                dao.UpdateMemberImage(image,member.Username);
            }
            MainForm main = new MainForm();
            main.setMember(member);
            main.Show();
            this.Hide();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            fdOpenFile = new OpenFileDialog();
            fdOpenFile.Filter = "Files | *.jpg; *.jpeg; *.png;";
            DialogResult = fdOpenFile.ShowDialog();
            if(DialogResult == DialogResult.OK)
            {
               
                Image image = new Bitmap(fdOpenFile.FileName);
                pbImage.Image = image;
                //dao.UpdateMemberImage(image,member.Username);

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
