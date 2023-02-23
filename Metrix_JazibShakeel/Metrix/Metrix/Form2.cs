using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Metrix
{
    public partial class Form2 : Form
    {
        Form1 form1 = new Form1();

        Pen pen = new Pen(Color.Purple, 5f);
        Rectangle r = new Rectangle();
        Graphics g;


        //// Create location and size of ellipse.
        int x = 30;
        int y = 50;
        int width = 10;
        int height = 10;


        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //form1.DrawLine();
            //TestDraw();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            //TestDraw();
            TestDraw(e);
        }
        public void TestDraw(PaintEventArgs e)
        {
            form1.startX = (int)form1.startPosition.X;
            form1.startY = (int)form1.startPosition.Y;

            PointF pOne = new PointF(form1.startX, form1.startX);
            PointF pTwo = new PointF(form1.startY, form1.startY);
            e.Graphics.DrawLine(pen, pOne, pTwo);

            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);


            //// Fill ellipse on screen.
            e.Graphics.FillEllipse(redBrush, x, y, width, height);


            for (int i = 0; i < form1.edges; i++)
            {
                Brush brush = new SolidBrush(Color.Red);
                g.FillEllipse(brush, form1.startPosition.X - 25, form1.startPosition.Y - 25, 50, 50);

            }
            e.Graphics.DrawLine(pen, form1.newNode, form1.nextNode);

        }
        public void adjacencyNode()
        {

        }

    }
}
