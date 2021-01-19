using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Had
{
    public partial class Form1 : Form
    {

        // ZAKLADNÍ PROMENNE

        PictureBox[] hadCasti;
        int hadVelikost;
        Point lokace = new Point(120, 120);
        string smer = "Prava";
        bool zmenaSmeru = false;
        
        //Jídllo
        PictureBox jidlo = new PictureBox();
        Point lokaceJidla = new Point(0, 0);
        public Form1()
        {
            InitializeComponent();
            tlacitkoStop.Enabled = false;
        }
        

        private void tlacitkoStart_Click(object sender, EventArgs e)
        {
            //znovu zapnutí hry 
            panel1.Controls.Clear();
            hadCasti = null;
            Skore.Text = "0";
            hadVelikost = 5;
            smer = "Prava";
            lokace = new Point(120, 120);
            
            //Start hry
            vykresliHada();
            vykresliJidlo();
            timer1.Start();

            //zakazani tlacitek start a rychlost
            Rychlost.Enabled = false;
            tlacitkoStart.Enabled = false;

            //povoleni tlacitka stop

            tlacitkoStop.Enabled = true;
        }
        private void vykresliHada()
        {
            hadCasti = new PictureBox[hadVelikost];

            //vykresleni casti hada
            for (int i = 0; i < hadVelikost; i++)
            {
                hadCasti[i] = new PictureBox();
                hadCasti[i].Size = new Size(15, 15);
                hadCasti[i].BackColor = Color.Red;
                hadCasti[i].BorderStyle = BorderStyle.None;
                hadCasti[i].Location = new Point(lokace.X - (15 * i), lokace.Y);
                panel1.Controls.Add(hadCasti[i]);
            }

        }
         
        private void vykresliJidlo()
        {
            Random random = new Random();
            int Xrandom = random.Next(38) * 15;
            int Yrandom = random.Next(30) * 15;

            bool naHadovi = true;

            //Znovu vykreslení jidla v pripade že se objeví na pozici hada
            while (naHadovi)
            {

                for (int i = 0; i < hadVelikost; i++)
                {
                    if (hadCasti[i].Location == new Point(Xrandom, Yrandom))
                    {
                        Xrandom = random.Next(38) * 15;
                        Yrandom = random.Next(30) * 15;
                    }
                    else
                    {
                        naHadovi = false;
                    }
                }
            }
            // vykresleni jidla
            if (naHadovi == false)
            {
                lokaceJidla = new Point(Xrandom, Yrandom);
                jidlo.Size = new Size(15, 15);
                jidlo.BackColor = Color.Yellow;
                
                jidlo.Location = lokaceJidla;
                panel1.Controls.Add(jidlo);

            }

        }

        private void Rychlost_Scroll(object sender, EventArgs e)
        {
            //zmena  rychlosti
            timer1.Interval = 501 - (5 * Rychlost.Value);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pohyb();
        }

        private void pohyb()
        {

            Point point = new Point(0, 0);

            // zvuk pro udalosti
            SoundPlayer hadNaraz = new SoundPlayer(Properties.Resources.crash);
            SoundPlayer hadEat = new SoundPlayer(Properties.Resources.eat);

            //cyklus pro pohyb vsech casti pri zmene smeru
            for (int i = 0; i < hadVelikost; i++)
            {
                if (i == 0)
                {

                    point = hadCasti[i].Location;
                    if (smer == "Leva")
                    {
                        hadCasti[i].Location = new Point(hadCasti[i].Location.X - 15, hadCasti[i].Location.Y);
                    }
                    if (smer == "Prava")
                    {
                        hadCasti[i].Location = new Point(hadCasti[i].Location.X + 15, hadCasti[i].Location.Y);
                    }
                    if (smer == "Nahoru")
                    {
                        hadCasti[i].Location = new Point(hadCasti[i].Location.X, hadCasti[i].Location.Y - 15);
                    }
                    if (smer == "Dolu")
                    {
                        hadCasti[i].Location = new Point(hadCasti[i].Location.X, hadCasti[i].Location.Y + 15);
                    }

                }
                else
                {
                    Point novyPoint = hadCasti[i].Location;
                    hadCasti[i].Location = point;
                    point = novyPoint;
                }
            }
            // kolize s jidlem
            
            if (hadCasti[0].Location == lokaceJidla)
            {
                snezJidlo();
                vykresliJidlo();
                hadEat.Play();

            }
            //kolize se stenou
            if (hadCasti[0].Location.X < 0 || hadCasti[0].Location.X >= 570 || hadCasti[0].Location.Y < 0 || hadCasti[0].Location.Y >= 450) 
            {
                zastavHru();
                hadNaraz.Play();
                
            }
            // kolize hada se sebou
            
            
            for (int i = 3; i < hadVelikost; i++)
            {
                if (hadCasti[0].Location == hadCasti[i].Location)
                {
                    zastavHru();
                    hadNaraz.Play();
                }
                
            }
            

            zmenaSmeru = false;
        }
        //ovladani hada
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Up) && smer != "Dole" && zmenaSmeru != true)
            {
                smer = "Nahoru";
                zmenaSmeru = true;
                
            }
            if (keyData == (Keys.Down) && smer != "Nahoru" && zmenaSmeru != true)
            {
                smer = "Dolu";
                zmenaSmeru = true;
                
            }
            if (keyData == (Keys.Right) && smer != "Leva" && zmenaSmeru != true)
            {
                smer = "Prava";
                zmenaSmeru = true;
                
            }
            if (keyData == (Keys.Left) && smer != "Prava" && zmenaSmeru != true)
            {
                smer = "Leva";
                zmenaSmeru = true;
                
            }
            
            


            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void snezJidlo()
        {
            hadVelikost++;
            //zvetseni hada o 1 policko ,,, ulozeni stareho hada a vytvoreni vetsiho hada
            PictureBox[] staryHad = hadCasti;
            panel1.Controls.Clear();
            hadCasti = new PictureBox[hadVelikost];
            for (int i=0;i<hadVelikost;i++)
            {
                hadCasti[i] = new PictureBox();
                hadCasti[i].Size = new Size(15, 15);
                hadCasti[i].BackColor = Color.Red;
                
                if (i==0)
                {
                    hadCasti[i].Location = lokaceJidla;
                }
                else
                {
                    hadCasti[i].Location = staryHad[i - 1].Location;
                }
                panel1.Controls.Add(hadCasti[i]);
            }
            //skore
            int dosavadniSkore = Int32.Parse(Skore.Text);
            int noveSkore = dosavadniSkore + 10 ;
            Skore.Text = noveSkore + "";
        }

        private void zastavHru()
        {
            timer1.Stop();
            tlacitkoStart.Enabled = true;
            Rychlost.Enabled = true;
            tlacitkoStop.Enabled = false;
            panel1.Controls.Clear();

            //Konec hry
            Label konec = new Label();
            konec.Text = "KONEC HRY";
            konec.ForeColor = Color.Red;
            konec.Font = new Font("Sagoe Print", 50, FontStyle.Bold);
            konec.Size = konec.PreferredSize;
            konec.TextAlign = ContentAlignment.MiddleCenter;
            konec.BringToFront();

            // misto kde se ma objevit label konec hry
            int X = panel1.Width / 2 - konec.Width / 2;
            int Y = panel1.Height / 2 - konec.Height / 2;
            konec.Location = new Point(X, Y);
            panel1.Controls.Add(konec);
            
         }

        private void tlacitkoStop_Click(object sender, EventArgs e)
        {
            
            zastavHru();
        }
    }
    
}
