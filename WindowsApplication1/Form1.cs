using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        Int32[,] oyun=new Int32[10,10];
        Int32[,] kont = new Int32[10, 10];
        int o, o1, son=1,skor=0,sag=1,sol=1,ust=1,alt=1,ustsol=1,ustsag=1,altsol=1,altsag=1;
        Int32 x=1, y=1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            basla();

        }

        private void basla()
        {
            for (o = 0; o <= 9; o++)
            {
                for (o1 = 0; o1 <= 9; o1++)
                {
                    oyun[o, o1] = 0;
                    kont[o, o1] = 0;
                }
            }
            textBox7.Text = "1";
            oyun[0, 0] = 1;
            skor = 0;
            son = 2;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int i;
            SolidBrush br = new SolidBrush(Color.LightGreen);
            SolidBrush brush = new SolidBrush(Color.DarkBlue);
            FontStyle style = FontStyle.Bold;
            Font arial = new Font("Arial", 16, style);
            Pen P=new Pen(Color.Black,2);
            e.Graphics.TranslateTransform(40, 40);
            e.Graphics.DrawRectangle(P, 0, 0, 500, 500);
            for (i = 1; i <= 9;i++ )
            {
                e.Graphics.DrawLine(P, 0, 50*i, 500, 50*i);
                e.Graphics.DrawLine(P, 50*i,0, 50*i, 500);
            }
            //rakam koy
            //sola iþaret koy
            if ((x - 3) >= 1)
            {
                if (oyun[x - 4, y - 1] == 0)
                {
                    e.Graphics.FillRectangle(br, (x * 50) - (200), (y - 1) * 50, 50, 50);
                    sol = 1;
                }else  {  sol = 0;  }
            }else  {  sol = 0;  }

            //saða iþaret koy
            if ((x + 3) <= 10)
            {
                if (oyun[x + 2, y - 1] == 0)
                {
                    e.Graphics.FillRectangle(br, (x * 50) + (100), (y - 1) * 50, 50, 50);
                    sag = 1;
                }else  {  sag = 0;  }
            }else  {  sag = 0;  }

            //üst iþaret koy
            if ((y - 3) >= 1)
            {
                if (oyun[x - 1, y - 4] == 0)
                {
                    e.Graphics.FillRectangle(br, (x - 1) * 50, (y * 50) - 200, 50, 50);
                    ust = 1;
                }else  {  ust = 0;  }
            }else  {  ust = 0;  }

            //alt iþaret koy
            if ((y + 3) <= 10)
            {
                if (oyun[x - 1, y + 2] == 0)
                {
                    e.Graphics.FillRectangle(br, (x - 1) * 50, (y * 50) + 100, 50, 50);
                    alt = 1;
                }else  {  alt = 0;  }
            }else  {  alt = 0;  }

           //ust sol iþaret koy
            if ((x - 2) >= 1 && (y - 2) >= 1)
            {
                if (oyun[x - 3, y - 3] == 0)
                {
                    e.Graphics.FillRectangle(br, (x * 50) - 150, (y *50) -150, 50, 50);
                    ustsol = 1;
                }
                else { ustsol = 0; }
            }
            else { ustsol = 0; }

           //ust sag iþaret koy
            if ((x + 2) <= 10 && (y - 2) >= 1)
            {
                if (oyun[x + 1, y - 3] == 0)
                {
                    e.Graphics.FillRectangle(br, (x * 50) + 50, (y * 50) - 150, 50, 50);
                    ustsag= 1;
                }
                else { ustsag = 0; }
            }
            else { ustsag = 0; }

            //alt sol iþaret koy
            if ((x - 2) >= 1 && (y + 2) <= 10)
            {
                if (oyun[x - 3, y + 1] == 0)
                {
                    e.Graphics.FillRectangle(br, (x * 50) - 150, (y * 50) + 50, 50, 50);
                    altsol = 1;
                }
                else { altsol = 0; }
            }
            else { altsol= 0; }

            //alt sað iþaret koy
            if ((x + 2) <= 10 && (y + 2) <= 10)
            {
                if (oyun[x + 1, y + 1] == 0)
                {
                    e.Graphics.FillRectangle(br, (x * 50) + 50, (y * 50) + 50, 50, 50);
                    altsag = 1;
                }
                else { altsag = 0; }
            }
            else { altsag = 0; }


            //bitiþ mesajý
            if (sag == 0 && sol == 0 && ust == 0 && alt == 0 && ustsol==0 && ustsag==0 && altsag==0 && altsol==0) 
            {
                MessageBox.Show("Oyun Bitti Oglum Nereye Týklýcan Skorun: "+ Convert.ToString(son-1)+" ok.:D");
            } 

            //rakamlarý yerleþtir
            for (o = 0; o <= 9; o++)
            {
                for (o1 = 0; o1 <= 9; o1++)
                {
                    if (oyun[o, o1] != 0)
                    {
                        e.Graphics.DrawString(Convert.ToString(oyun[o, o1]), arial, brush, ((o) * 50) + 15, ((o1) * 50) + 15);
                    }
                }
            }

        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           //kural 1: sadece yeþillere týklasýn
           //yeþil yollar
                //üst
                yesilYol(e, x - 1, x, y - 4, y - 3);
                //alt
                yesilYol(e, x - 1, x, y + 2, y + 3);
                //sag
                yesilYol(e, x + 2, x+3, y -1, y );
                //sol
                yesilYol(e, x - 4, x-3, y -1, y);
                //üstsol
                yesilYol(e, x - 3, x-2, y - 3, y - 2);
                //üstsað
                yesilYol(e, x +1, x+2, y - 3, y - 2);
                //altsol
                yesilYol(e, x - 3, x-2, y + 1, y + 2);
                //altsag
                yesilYol(e, x +1, x+2, y + 1, y + 2);
        }

        private void yesilYol(MouseEventArgs e, Int32 x1, Int32 x2, Int32 y1, Int32 y2)
        {
            if ((Convert.ToDouble(e.X) >= 40) && (Convert.ToDouble(e.Y) >= 40) && (Convert.ToDouble(e.X) <= 539) && (Convert.ToDouble(e.Y) <= 539))
            {

                if ((e.X > ((x1) * 50)+40) && (e.X < ((x2) * 50)+40) && (e.Y > ((y1) * 50)+40) && (e.Y < ((y2) * 50)+40))
                {
                    textBox3.Text = Convert.ToString(((e.X - 40) / 50) + 1);
                    textBox4.Text = Convert.ToString(((e.Y - 40) / 50) + 1);
                    x = Convert.ToInt32(textBox3.Text);
                    y = Convert.ToInt32(textBox4.Text);
                    
                    //kural 2: ayný kareye bir daha týklamasýn
                    if (oyun[x - 1, y - 1] == 0)
                    {
                        oyun[Convert.ToInt32(textBox3.Text) - 1, Convert.ToInt32(textBox4.Text) - 1] = son;
                        son++;
                    }
                    skor = 0;
                    for (o = 0; o <= 9; o++)
                    {
                        for (o1 = 0; o1 <= 9; o1++)
                        {
                            if (oyun[o, o1] > 0) skor++;
                        }
                    }
                    textBox7.Text = Convert.ToString(skor);
                    Invalidate();
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = "x: "+Convert.ToString(e.X)+" y: "+Convert.ToString( e.Y);
            textBox1.Text = Convert.ToString(e.X);
            textBox2.Text = Convert.ToString(e.Y);
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if ((Convert.ToDouble(e.X) >= 40) && (Convert.ToDouble(e.Y) >= 40) && (Convert.ToDouble(e.X) <= 539) && (Convert.ToDouble(e.Y) <= 539))
            {
                textBox5.Text = Convert.ToString(((e.X - 40) / 50) + 1);
                textBox6.Text = Convert.ToString(((e.Y - 40) / 50) + 1);
            }
        }

        private void baþlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            basla();
            x = 1;
            y = 1;
            Invalidate();
        }

        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Oyun Yapým Ve Programlama: Erkan ESEN / Oyun Fikri: Veysel ÇAKIR / Hatalar için: esengraphic@hotmail.com");
        }
    }
}