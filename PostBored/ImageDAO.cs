using System;
using System.Drawing;
using System.Windows.Forms;

namespace PostBored
{
    public class ImageDAO
    {

        private OpenFileDialog fdOpenFile;
        private Image image;
        private DialogResult dialogResult;
        public ImageDAO()
        {
        }

        public Image getImageFromFile()
        {
            fdOpenFile = new OpenFileDialog();
            fdOpenFile.Filter = "Files | *.jpg; *.jpeg; *.png;";
            dialogResult = fdOpenFile.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                image = new Bitmap(fdOpenFile.FileName);
                return image;
            }
            return null;
        }
    }
}
