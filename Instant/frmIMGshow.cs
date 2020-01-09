﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Instant
{
    public partial class frmIMGshow : Form
    {

        List<string> _lstimg = new List<string>();
        int selected = 0;

        public frmIMGshow()
        {
            InitializeComponent();
        }
        public frmIMGshow(List<string> lstimgs)
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.WindowState = FormWindowState.Maximized;
            _lstimg = lstimgs;
            //this.TopMost = true;
        }

        private void frmIMGshow_Activated(object sender, EventArgs e)
        {

        }

        private void frmIMGshow_Shown(object sender, EventArgs e)
        {
            foreach (var s in _lstimg)
            {
                pictureBox1.Image = Image.FromFile(s);
                break;
            }


            //this.Close();
            //this.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            nextIMg();
        }

        private void nextIMg()
        {
            string newp = "";
            selected++; try
            {

                newp = _lstimg[selected];
            }
            catch (Exception)
            {
                newp = "";

            }
            if (newp != "")
            {
                pictureBox1.Image = Image.FromFile(newp);
            }

            if(selected >= _lstimg.Count)
            {
                this.Close();
                this.Dispose();
            }



        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Right)
            {
                this.Close();
                this.Dispose();
            }
            nextIMg();
        }
    }
}
