using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestVerticalDisplay
{
    public partial class Form1 : Form
    {
        Point lastPoint = Point.Empty;//Point.Empty represents null for a Point object

        bool isMouseDown = new Boolean();//this is used to evaluate whether our mousebutton is down or not

        List<Point> gesture = new List<Point>();

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void richTextBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)//check to see if the mouse button is down

            {

                if (lastPoint != null)//if our last point is not null, which in this case we have assigned above

                {

                    if (pictureBox1.Image == null)//if no available bitmap exists on the picturebox to draw on

                    {
                        //create a new bitmap
                        Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

                        pictureBox1.Image = bmp; //assign the picturebox.Image property to the bitmap created

                    }

                    using (Graphics g = Graphics.FromImage(pictureBox1.Image))

                    {//we need to create a Graphics object to draw on the picture box, its our main tool

                        //when making a Pen object, you can just give it color only or give it color and pen size

                        g.DrawLine(new Pen(Color.Black, 2), lastPoint, e.Location);
                        //g.SmoothingMode = SmoothingMode.AntiAliasing;
                        //this is to give the drawing a more smoother, less sharper look

                    }

                    pictureBox1.Invalidate();//refreshes the picturebox

                    lastPoint = e.Location;//keep assigning the lastPoint to the current mouse position
                    if (checkBox1.Checked)
                    {
                        gesture.Add(lastPoint);
                    }
                }

            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;//we assign the lastPoint to the current mouse position: e.Location ('e' is from the MouseEventArgs passed into the MouseDown event)

            isMouseDown = true;//we set to true because our mouse button is down (clicked)

            if (checkBox1.Checked)
            {
                gesture.Add(lastPoint);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;

            lastPoint = Point.Empty;

            //set the previous point back to null if the user lets go of the mouse button

            if (checkBox1.Checked)
            {
                foreach (var item in gesture)
                {
                    Console.Write(item.ToString() + " ");

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)

            {

                pictureBox1.Image = null;

                Invalidate();

                String text = "gesture";
                if (textBox1.Text.Trim().Length > 0)
                {
                    text = textBox1.Text;
                }
                using (StreamWriter ws = new StreamWriter(text + ".txt", true))
                {
                    gesture.ForEach(p => { ws.Write(p.ToString() + "\n"); });
                }
                gesture.Clear();
                MessageBox.Show("Fisierul " + text + " a fost salvat! Felicitari!\n", MessageBoxButtons.OK.ToString());
            } 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamReader rs = new StreamReader(textBox1.Text))
            {

            }
        }
    }
}
