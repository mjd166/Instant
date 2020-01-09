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

namespace Instant
{
    public partial class TextViewer : Form
    {


        List<string> _lstFiles = new List<string>();


        string _text = "";
        string[] words;
        int selected = 1;
        int selectedFiles = 0;

        public TextViewer()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }




        public TextViewer(List<string> text)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _lstFiles = text;
            _text = File.ReadAllText(_lstFiles[0]);
            words = _text.Split(' ');
        }
        private void TextViewer_Load(object sender, EventArgs e)
        {
            label1.Font = new Font(label1.Font.FontFamily, tableLayoutPanel1.Height/5, FontStyle.Regular);
            label2.Font = new Font(label2.Font.FontFamily, tableLayoutPanel1.Height /5, FontStyle.Regular);

            if (words.Length > 1)
            {
                label1.Text = words[0];
                label2.Text = words[1];

            }


            //SizeLabelFont(label1);
        }



        private void Nextitem()
        {
            try
            {

                selected++;

                if (selected == 1)
                    if (!(selected >= words.Length))
                        label1.Text = words[selected];
                    else
                    {
                        if (selectedFiles > _lstFiles.Count - 1)
                        {
                            this.Dispose();
                            this.Close();
                        }
                        else
                        {
                            selectedFiles++;
                            _text = File.ReadAllText(_lstFiles[selectedFiles]);
                            words = _text.Split(' ');
                            selected = -1;
                            Nextitem();
                        }
                    }

                
                if (!(selected >= words.Length))
                {
                    label1.Text = words[selected];
                    selected++;
                    if (!(selected >= words.Length))
                        label2.Text = words[selected];
                    else
                    {
                        if (selectedFiles >= _lstFiles.Count - 1)
                        {
                            this.Close();
                            this.Close();
                        }
                        else
                        {
                            selectedFiles++;
                            _text = File.ReadAllText(_lstFiles[selectedFiles]);
                            words = _text.Split(' ');
                            selected = -1;
                            Nextitem();
                        }

                    }
                }
                else
                {
                    if (selectedFiles >= _lstFiles.Count - 1)
                    {
                        this.Close();
                        this.Close();

                    }
                    else
                    {
                        selectedFiles++;
                        _text = File.ReadAllText(_lstFiles[selectedFiles]);
                        words = _text.Split(' ');
                        selected = -1;
                        Nextitem();
                    }
                }


            }
            catch (Exception exNext)
            {

                Class.publics.WriteLogs("exNetx item on TextViewer", exNext.ToString());

            }
        }
        private void Label1_SizeChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }


        private void SizeLabelFont(Label lbl)
        {
            // Only bother if there's text.
            string txt = lbl.Text;
            if (txt.Length > 0)
            {
                int best_size = 100;

                // See how much room we have, allowing a bit
                // for the Label's internal margin.
                int wid = lbl.DisplayRectangle.Width - 3;
                int hgt = lbl.DisplayRectangle.Height - 3;

                // Make a Graphics object to measure the text.
                using (Graphics gr = lbl.CreateGraphics())
                {
                    for (int i = 1; i <= 100; i++)
                    {
                        using (Font test_font = new Font(lbl.Font.FontFamily, i))
                        {
                            // See how much space the text would
                            // need, specifying a maximum width.
                            SizeF text_size = gr.MeasureString(txt, test_font);
                            if ((text_size.Width > wid) ||
                                (text_size.Height > hgt))
                            {
                                best_size = i - 1;
                                break;
                            }
                        }
                    }
                }

                // Use that font size.
                lbl.Font = new Font(lbl.Font.FontFamily, best_size);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

            MouseEventArgs me = (MouseEventArgs)e;
            if(me.Button == MouseButtons.Right)
            {
                this.Close();
                this.Dispose();
            }
            Nextitem();
        }
    }
}
