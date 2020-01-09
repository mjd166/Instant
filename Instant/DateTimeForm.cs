using PersianTools.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Instant
{
    public partial class DateTimeForm : Form
    {
        public DateTimeForm()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

        }

        string[] words;
        private void DateTimeForm_Load(object sender, EventArgs e)
        {

            // var dt1 = new PersianDateTime(1399, 10, 13);


            var d1 = PersianDateTime.Now.ToLongStringYMD();// جمعه بیست و هفت مهر سال یکهزار و سیصد و نود و هفت

            words = d1.Split(' ');


            lblDateFull.Font = new Font(lblDateFull.Font.FontFamily, (tableLayoutPanel1.Height / 7) + 5);
            lblDayofWeek.Font = new Font(lblDayofWeek.Font.FontFamily, (tableLayoutPanel1.Height / 7) + 5);
            lbl4.Font = lbl3.Font = new Font(lbl3.Font.FontFamily, (tableLayoutPanel1.Height / 7) + 5);


            var year = PersianDateTime.Now.Year;

            lblDayofWeek.Text = words[0];
            lblDateFull.Text = words[1];
            lbl3.Text = words[2];
            if (words[3] != "سال")
            {
                lbl4.Text = year.ToString();
            }
            else
            {
                lbl4.Text = year.ToString();
            }



            lblDayofWeek.BackColor = Color.Yellow;
            lblDateFull.BackColor = Color.Yellow;

            lbl3.BackColor = Color.Green
                ;
            lbl4.BackColor = Color.Green;




        }

        private void lblDayofWeek_Click(object sender, EventArgs e)
        {
            //DateTimeForm2 f2 = new DateTimeForm2();
            //f2.ShowDialog();
            //this.Close();
            //this.Dispose();
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Right)
            {
                this.Close();
                this.Dispose();
            }
            NextItem();

        }


        int part = 0;
        int step = 0;
        private void NextItem()
        {
            string[] monasebat = PersianDateTime.GetDateData(DateTime.Now).Split(' ');






            if (step >= monasebat.Length)
            {
                part = 1000000;

                if (part == 1)
                {
                    var nowdate = PersianDateTime.Now;
                    if (nowdate.IsHoliDay)
                    {
                        lblDayofWeek.Text = "امروز";
                        lblDateFull.Text = "تعطیل";
                        lbl3.Text = "است";

                    }
                    else
                    {
                        lblDayofWeek.Text = "امروز";
                        lblDateFull.Text = "تعطیل";
                        lbl3.Text = "نیست";
                    }
                }
                else if (part == 2)
                {
                    var nowdat = PersianDateTime.Now.AddDays(1);
                    if (nowdat.IsHoliDay)
                    {
                        lblDayofWeek.Text = "فردا";
                        lblDateFull.Text = "تعطیل";
                        lbl3.Text = "است";

                    }
                    else
                    {
                        lblDayofWeek.Text = "فردا";
                        lblDateFull.Text = "تعطیل";
                        lbl3.Text = "نیست";
                    }

                }
                else if (part == 3)
                {



                }
                else
                {
                    this.Close();
                    this.Dispose();

                }
            }
            else
            {
                if (part >= 3)
                {
                    part = 3;

                }
                else
                    part++;
                if (part == 1)
                {
                    var nowdate = PersianDateTime.Now;
                    if (nowdate.IsHoliDay)
                    {
                        lblDayofWeek.Text = "امروز";
                        lblDateFull.Text = "تعطیل";
                        lbl3.Text = "است";

                    }
                    else
                    {
                        lblDayofWeek.Text = "امروز";
                        lblDateFull.Text = "تعطیل";
                        lbl3.Text = "نیست";
                    }
                }
                else if (part == 2)
                {
                    var nowdat = PersianDateTime.Now.AddDays(1);
                    if (nowdat.IsHoliDay)
                    {
                        lblDayofWeek.Text = "فردا";
                        lblDateFull.Text = "تعطیل";
                        lbl3.Text = "است";

                    }
                    else
                    {
                        lblDayofWeek.Text = "فردا";
                        lblDateFull.Text = "تعطیل";
                        lbl3.Text = "نیست";
                    }
                }
                else if (part == 3)
                {
                    part = 3;
                    if (monasebat[step] != "")
                        lblDayofWeek.Text = monasebat[step];
                    else
                    {
                        step++;
                        if (step >= monasebat.Length)
                        {
                            this.Close();
                            this.Dispose();
                            return;
                        }
                        else
                        {
                            lblDayofWeek.Text = monasebat[step];
                        }

                    }

                    step++; if (step >= monasebat.Length)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                        this.Dispose();
                        return;
                    }

                    if (monasebat[step] != "")
                    {
                        lblDateFull.Text = monasebat[step];
                    }
                    else
                    {
                        step++; lblDateFull.Text = monasebat[step];

                    }

                    step++; if (step >= monasebat.Length)
                    {
                        this.Close();
                        this.Dispose();
                    }


                    if (monasebat[step] != "")
                    {
                        lbl3.Text = monasebat[step];
                    }
                    else
                    {
                        step++;
                        lbl3.Text = monasebat[step];

                    }

                    step++;
                    if (step >= monasebat.Length)
                    {
                        this.Close();
                        this.Dispose();
                        return;
                    }
                    if (monasebat[step] != "")
                    {
                        lbl4.Text = monasebat[step];
                    }
                    else
                    {
                        step++;
                        lbl4.Text = monasebat[step];
                    }

                    step++;
                    if (step >= monasebat.Length)
                    {
                        this.Close();
                        this.Dispose();
                    }



                }
            }



        }
    }
}
