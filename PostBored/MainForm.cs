using System;
using System.Collections;
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
    public partial class MainForm : Form
    {
        MembersDAO memDAO;
        TagsDAO tagsDao;
        FollowMemberDAO fmember;
        Member member;
        Dictionary<string, int> dict;
        Boolean isLoggedIn; 
        

        public MainForm()
        {
            InitializeComponent();
            memDAO = new MembersDAO();
            fmember = new FollowMemberDAO();
            tagsDao = new TagsDAO();
            dict = tagsDao.dict;
            isLoggedIn = memDAO.isLogedIn;

            if (isLoggedIn == false)
            {
                tagLabel.Text = "Popular Tags";
                userLabel.Text = "Popular Members";
                btnCreatePost.Text = "Login";
                btnLogout.Text = "Create Account";
                btnUsername.Hide();

            }
            else
            {
                tagLabel.Text = "Subscribed Tags";
                userLabel.Text = "Users Followed";
                btnCreatePost.Text = "Create Post";
                btnUsername.Text = "" + fmember.username2;
                btnLogout.Text = "Logout";
            }

    }
        private void MainForm_Load(object sender, EventArgs e)
        {
            //tagsDao.SelectTags();
            //fmember.SelectFriendUsername();
            //insertDataGrdviewSubscribeTags();
        }

        private void insertDataGrdviewSubscribeTags()
        {
            grdSubscribeTags.ColumnCount = 2;
            grdSubscribeTags.Columns[0].Name = "Tag Name";
            grdSubscribeTags.Columns[1].Name = "Number Of Posts";
            
            int size = dict.Count();
            /*foreach (KeyValuePair<string, int> kv in dict){
                int i = 0;
                grdSubscribeTags.Rows[i].Cells[0].Value = kv.Key.ToString();
                grdSubscribeTags.Rows[i].Cells[1].Value = kv.Value.ToString();
                i++;
            }*/
            int i = 1;
            grdSubscribeTags.Rows.Add(dict.Count);

            foreach (KeyValuePair<string, int> kv in dict)
            {
                MessageBox.Show("wwwwwwww"+kv.Key.ToString()+" : "+kv.Value);
                string key = kv.Key.ToString();
                int value = kv.Value;
                //add the values to the datagridview

            }

            
            
        }
        private void insertUsersFollwed()
        {
            grdUsersFollowed.ColumnCount = 2;
            grdUsersFollowed.Columns[0].Name = "Username";
            grdUsersFollowed.Columns[1].Name = "No. of post since last log in";
        }

        private void btnCreatePost_Click(object sender, EventArgs e)
        {
            if (isLoggedIn == false)
            {
                //go to log in
                LogIn frmLogIn = new LogIn();
                frmLogIn.Show();
            }
            else
            {
                //go to create post

                //LogIn frmLogIn = new LogIn();
                //frmLogIn.Show();
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (isLoggedIn == true)
            {
                //go to log out
                this.Close();
                MainForm frmMain = new MainForm();
                frmMain.Show();
            }
            else
            {
                //go to create account
            }
        }

        private void btnUsername_Click(object sender, EventArgs e)
        {

        }

    }
}
