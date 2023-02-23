using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metrix
{
    //Credits
    //https://kalkicode.com/adjacency-matrix-representation-of-directed-graph-in-csharp
    //https://www.youtube.com/watch?v=Jc5eXYwTROg
    //ChatGPT
    public partial class Form1 : Form
    {
        private int[,] node;
        Color color = Color.Purple;
        private float width = 10;
        //Pen pen = new Pen(Color.Purple, 5f);
        //Graphics g;
        public Vector2 startPosition = new Vector2(100, 200);

        public int startX, startY;
        public int start, end;
        public int angle;
        public int length;
        public int dist;
        public int edges = 0;

        public Point newNode;
        public Point nextNode;

        PaintEventArgs e;
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < Graph.ColumnCount; i++)
            {
                for (int j = 0; j < Graph.RowCount; j++)
                {
                    TextBox slotes = new TextBox();
                    slotes.Text = "0";
                    Graph.Controls.Add(slotes, i, j);
                }
            }
            this.node = new int[edges, edges];

        }
        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (this.edges > start && this.edges > start)
            {
                this.node[start, end] = 1;
            }

            Form2 form2 = new Form2();
            form2.ShowDialog();
            //form2.TestDraw();

            for (int i = 0; i < edges; i++)
            {
                for (int j = 0; j < edges; j++)
                {
                    if (node[i,j] == 1)
                    {
                        //find way to get angle to next node
                        //polar coordinate // trig


                        //Cant come up with solution to grab data from textbox and have program tell it where to go
                        Point newNode = new Point(startX, startY);
                        Point nextNode = new Point(startX + 150, startY + 150);
                        form2.TestDraw((PaintEventArgs)e);
                        
                    }
                }
            }

        }
    }
}
