using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateGrid();
            Timer t = new Timer();
            grid[8][12].ImageLocation = "thumbnail.jpg";
            //grid[8][12].Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            t.Tick += new EventHandler(t_Tick);
            t.Interval = 500;
            t.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            if (y>0)
            {
                grid[8][y].Image = null;
                grid[8][y].BackColor = Color.Gray;
                grid[8][--y].ImageLocation = "thumbnail.jpg";
                grid[8][y].SizeMode = PictureBoxSizeMode.StretchImage;
            }            
        }

        int y = 12;
        List<List<PictureBox>> grid = new List<List<PictureBox>>();

        public void CreateGrid()
        {
            List<PictureBox> rows = new List<PictureBox>();
            for (int i = 0; i < 13; i++)
            {
                grid.Add(new List<PictureBox>());
                for (int a = 0; a < 13; a++)
                {
                    PictureBox p = new PictureBox();
                    
                    p.Location = new Point(i * 21, a * 21);
                    p.Size = new Size(20, 20);
                    if (a >= 4 && a < 9 || i >= 4 && i < 9)
                    {
                        if (a == 6 && i < 4 || i == 6 && a < 4 || i == 6 && a > 8 || a == 6 && i > 8)
                        {
                            p.BackColor = Color.LightGray;
                        }
                        else
                        {
                            p.BackColor = Color.Gray;
                        }
                    }
                    else
                    {
                        p.BackColor = Color.Green;
                    }
                    grid[i].Add(p);
                    
                    this.Controls.Add(p);
                }
            }
        }
    }
}
