using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zegar
{
    public partial class Form1 : Form
    {
        Graphics g;

        int xCenter = 315;
        int yCenter = 265;
		int godzinaLength = 120;
		int minutaLength = 150;
		int sekundaLength = 200;

		public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
			g.Clear(Color.DarkOrange);

			PrintNumber("2", 473, 150);
			PrintNumber("4", 473, 349);
			PrintNumber("6", 300, 450);
			PrintNumber("8", 127, 350);
			PrintNumber("10", 127, 150);
			PrintNumber("12", 300, 50);

			int sekundaX = xCenter + (int)(sekundaLength * Math.Sin(Math.PI * DateTime.Now.Second / 30));
			int sekundaY = yCenter - (int)(sekundaLength * Math.Cos(Math.PI * DateTime.Now.Second / 30));

			int minutaX = xCenter + (int)(minutaLength * Math.Sin(Math.PI * DateTime.Now.Minute / 30));
			int minutaY = yCenter - (int)(minutaLength * Math.Cos(Math.PI * DateTime.Now.Minute / 30));

			int godzinaX = xCenter + (int)(godzinaLength * Math.Sin(Math.PI * DateTime.Now.Hour / 6));
			int godzinaY = yCenter - (int)(godzinaLength * Math.Cos(Math.PI * DateTime.Now.Hour / 6));

			g.DrawLine(new Pen(Color.Blue, 8), xCenter, yCenter, godzinaX, godzinaY);
			g.DrawLine(new Pen(Color.CadetBlue, 4), xCenter, yCenter, minutaX, minutaY);
			g.DrawLine(new Pen(Color.DarkBlue, 1), xCenter, yCenter, sekundaX, sekundaY);

        }

		private void PrintNumber(string number, int x, int y)
		{
			g.DrawString(number, new Font("Console Lucida", 20), Brushes.DarkCyan, x, y);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			timer1.Start();
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			timer1.Stop();
		}
	}
}
