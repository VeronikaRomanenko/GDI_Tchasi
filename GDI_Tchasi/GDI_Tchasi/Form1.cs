using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDI_Tchasi
{
    public partial class Form1 : Form
    {
        Point zentr;
        Graphics g;
        Pen pen;
        Matrix m1, m2, m3;
        int i;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        public Form1()
        {
            InitializeComponent();
            i = 0;
            m1 = new Matrix();
            m2 = new Matrix();
            m3 = new Matrix();
            zentr = new Point(160, 160);
            timer1.Start();
            Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawEllipse(new Pen(Color.Black, 3), 10, 10, 300, 300);
            pen = new Pen(Color.Black, 5);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.SquareAnchor;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            Matrix m = new Matrix();
            g.DrawLine(new Pen(Color.Black, 2), 160, 10, 160, 25);
            for (int i = 0; i < 11; i++)
            {
                m.RotateAt(30, new PointF(160, 160));
                g.Transform = m;
                g.DrawLine(new Pen(Color.Black, 2), 160, 10, 160, 25);
            }

            if (i == 0)
            {
                g.Transform = m1;
                m1.RotateAt(6 * DateTime.Now.Second, new PointF(160, 160));
                pen.Width = 5;
                g.DrawLine(pen, zentr, new Point(160, 10));
                g.Transform = m2;
                m2.RotateAt(6 * DateTime.Now.Minute, new PointF(160, 160));
                pen.Width = 6;
                g.DrawLine(pen, zentr, new Point(160, 25));
                g.Transform = m3;
                m3.RotateAt(30 * DateTime.Now.Hour, new PointF(160, 160));
                pen.Width = 7;
                g.DrawLine(pen, zentr, new Point(160, 50));
            }
            else
            {
                g.Transform = m1;
                m1.RotateAt(6, new PointF(160, 160));
                pen.Width = 5;
                g.DrawLine(pen, zentr, new Point(160, 10));
                g.Transform = m2;
                m2.RotateAt(0.1f, new PointF(160, 160));
                pen.Width = 6;
                g.DrawLine(pen, zentr, new Point(160, 25));
                g.Transform = m3;
                m3.RotateAt(0.0083333333f, new PointF(160, 160));
                pen.Width = 7;
                g.DrawLine(pen, zentr, new Point(160, 50));
            }
            i++;
        }
    }
}