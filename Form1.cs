using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A3HW
{
    public partial class Form1 : Form
    {
        //Drawing Area creating
        Graphics g;
        Pen pointColor, lineColor;
        Point cursor;
        
        Curve curve = new Curve();
        public Form1()
        {
            InitializeComponent();
            
            pointColor = new Pen(Color.Red);
            lineColor = new Pen(Color.Red);
        }
        // Draw point and line
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            
            for(int i = 0;i < curve.points.Count; i++)
            {
                g.DrawEllipse(pointColor, curve.points[i].x , curve.points[i].y, 3, 3);
            }
            for (int i = 0; i < curve.points.Count; i++)
            {
                if(i != curve.points.Count-1)
                {

                g.DrawLine(lineColor, curve.points[i].x, curve.points[i].y, curve.points[i+1].x, curve.points[i+1].y);
                }
            }
            Refresh();
            
        }
        // Detecting mouse move
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)//correct
        {
            int[] array;
            array = cursorXY();
            
            label1.Text = "X : " + array[0] + " Y : " + array[1];

        }

        // Detecting current cursor
        private int[] cursorXY()
        {
            cursor = this.PointToClient(Cursor.Position);
            int[] coordinate = new int[2];
     
            coordinate[0] = cursor.X-23;
            coordinate[1] = cursor.Y-13;

            return coordinate;

        }
        // MouseClick events(Left,Right)
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            int[] array;
            array = cursorXY();
            int counter = 0;
            switch (e.Button)
            {
                // Adding point by left click
                case MouseButtons.Left:
                    

                    point p1 = new point(array[0], array[1]);
                    curve.AddPoint(p1);
                  
                    break;
                // Delete point by right click 
                case MouseButtons.Right:
                    if (curve.points.Count != 0)
                    {


                    //if right click is over point, point is deleted
                    for (int i = 0;i < curve.points.Count; i++)
                    {
                            if (array[0] == curve.points[i].x && array[1] == curve.points[i].y)
                            {
                                curve.RemovePoint(curve.points[i]);
                            counter++;
                            }
                        }

                        // Directly delete last point of the curve
                        if (counter == 0){
                       
                        
                            curve.RemovePoint(curve.points[curve.points.Count - 1]);
                       
                    }
                    }
                    break;

                    }

        }

        // Exit button
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Calculating curve length
        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = curve.CurveLength().ToString();
        }

        // Selecting Line Color
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBox2.SelectedIndex;
            Object selectedItem = comboBox2.SelectedItem;

            switch ((string)selectedItem)
            {


                case "Black":
                    lineColor = new Pen(Color.Black);
                    break;
                case "Red":
                    lineColor = new Pen(Color.Red);
                    break;
                case "Blue":
                    lineColor = new Pen(Color.Blue);
                    break;

            }
        }
        // Selecting Point Color
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBox1.SelectedIndex;
            Object selectedItem = comboBox1.SelectedItem;
        
            switch ((string)selectedItem)
            {


             case "Black":
                pointColor = new Pen(Color.Black);
                    break;
            case "Red":
                    pointColor = new Pen(Color.Red);
                    break;
            case "Blue":
                    pointColor = new Pen(Color.Blue);
                    break;
               
        }
               
        
        
        
        }
    }
}
