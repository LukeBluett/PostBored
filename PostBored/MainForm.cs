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
        Dictionary<string, int> followMemberDict;
        HashSet<string> hashSet;
        HashSet<string> followMemberHashSet;
        Boolean isLoggedIn; 
        
        public void setMember(Member member)
        {

        }
        public MainForm()
        {
            InitializeComponent();
            memDAO = new MembersDAO();
            fmember = new FollowMemberDAO();
            tagsDao = new TagsDAO();
            followMemberDict = fmember.followMember;
            dict = tagsDao.dict;
            followMemberHashSet = fmember.followMemberHashSet;
            hashSet = tagsDao.hashSet;
            isLoggedIn = true;

            if (isLoggedIn == true)
            {
                tagLabel.Text = "Subscribed Tags";
                userLabel.Text = "Users Followed";
                btnCreatePost.Text = "Create Post";
                btnUsername.Text = "" + fmember.username2;
                btnLogout.Text = "Logout";
            }
            else
            {
                tagLabel.Text = "Popular Tags";
                userLabel.Text = "Popular Members";
                btnCreatePost.Text = "Login";
                btnLogout.Text = "Create Account";
                btnUsername.Hide();

            }

    }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (isLoggedIn == true)
            {
                tagsDao.SelectTags();
                fmember.SelectFriendUsername();
                insertDataGrdviewSubscribeTags();
                insertUsersFollwed();
            }
            else
            {
                fmember.GetPopularMembers();
                tagsDao.SelectPopularTags();
                insertDataGrdviewSubscribeTags();
                insertUsersFollwed();

            }
        }

        private void insertDataGrdviewSubscribeTags()
        {
            if (isLoggedIn == true)
            {
                grdSubscribeTags.ColumnCount = 2;
                grdSubscribeTags.Columns[0].Name = "Tag Name";
                grdSubscribeTags.Columns[1].Name = "Number Of Posts";
                foreach (KeyValuePair<string, int> kv in dict)
                {
                    string key = kv.Key.ToString();
                    int value = kv.Value;
                    grdSubscribeTags.Rows.Add(key, value);

                }

            }
            else
            {
                grdSubscribeTags.ColumnCount = 1;
                grdSubscribeTags.Columns[0].Name = "Tag Name";

                foreach (string i in hashSet)
                {

                    grdSubscribeTags.Rows.Add(i);
                }

            }
        }
        private void insertUsersFollwed()
        {
            if (isLoggedIn == true)
            {
                grdUsersFollowed.ColumnCount = 2;
                grdUsersFollowed.Columns[0].Name = "Username";
                grdUsersFollowed.Columns[1].Name = "No. of post";
                foreach (KeyValuePair<string, int> kv in followMemberDict)
                {
                    string key = kv.Key.ToString();
                    int value = kv.Value;
                    grdUsersFollowed.Rows.Add(key, value);

                }
            }
            else
            {
                grdUsersFollowed.ColumnCount = 1;
                grdUsersFollowed.Columns[0].Name = "Username";

            }
            foreach (string j in followMemberHashSet)
            {

                grdUsersFollowed.Rows.Add(j);
            }
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
            if (isLoggedIn == false)
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
