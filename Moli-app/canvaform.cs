using Moli_app.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moli_app
{
    public partial class canvaform : Form
    {
        public canvaform()
        {
            InitializeComponent();
            Util.KillAllFFMPEG();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSearchYoutube_Click(object sender, EventArgs e)
        {
            // Create an instance of FormABC
            SearchVideoShort formABC = new SearchVideoShort();
            // Show FormABC
            formABC.Show();
        }

        private void btnSplitVideo_Click(object sender, EventArgs e)
        {
            // Create an instance of FormABC
            tiktok formABC = new tiktok();
            // Show FormABC
            formABC.Show();
        }

        private void btnMergeVideo_Click(object sender, EventArgs e)
        {
            // Create an instance of FormABC
            MergeVideo formABC = new MergeVideo();
            // Show FormABC
            formABC.Show();
        }
    }
}
