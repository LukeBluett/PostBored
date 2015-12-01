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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            insertDataGrdviewSubscribeTags();
            insertUsersFollwed();
        }

        private void insertDataGrdviewSubscribeTags()
        {
            grdSubscribeTags.ColumnCount = 2;
            grdSubscribeTags.Columns[0].Name = "Tag Name";
            grdSubscribeTags.Columns[1].Name = "Number Of Posts";
        }
        private void insertUsersFollwed()
        {
            grdUsersFollowed.ColumnCount = 2;
            grdUsersFollowed.Columns[0].Name = "Username";
            grdUsersFollowed.Columns[1].Name = "No. of post since last log in";
        }

        private void btnCreatePost_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void btnUsername_Click(object sender, EventArgs e)
        {

        }

    }
}
