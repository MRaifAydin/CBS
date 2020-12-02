using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }

        //Poligon noktalar dizisi.
        Point[] polygonDizi = new Point[100];
        

        public int index = 0;
        

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }


        //Lineer çizgi.
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics gObject = canvas.CreateGraphics();
            Brush red = new SolidBrush(Color.Red);
            
            String x1 = textBox1.Text;
            String y1 = textBox2.Text;
            String x2 = textBox3.Text;
            String y2 = textBox4.Text;
            String kalinlik = textBox5.Text;
            String kesikli = textBox12.Text;
            Pen redPen = new Pen(red, int.Parse(kalinlik));

            Point  point1 = new Point(int.Parse(x1),int.Parse(y1));
            Point point2 = new Point(int.Parse(x2), int.Parse(y2));
            if (kesikli == "evet" || kesikli == "EVET")
            {
                float[] dashValues = { 4, 4 };

                redPen.DashPattern = dashValues;

               

                gObject.DrawLine(redPen, point1, point2);

            }
            else
            {
                

                gObject.DrawLine(redPen, point1, point2);
            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Graphics gObject = canvas.CreateGraphics();
            gObject.Clear(Color.White);
            Array.Clear(polygonDizi, 0, index);
            index = 0;

        }

        //Polygon noktaları al.
        public void button2_Click(object sender, EventArgs e)
        {
            
            String xPolygon = textBox6.Text;
            String yPolygon = textBox7.Text;

            if (xPolygon != null && yPolygon != null)
            {
                polygonDizi[index] = new Point(int.Parse(xPolygon), int.Parse(yPolygon));
                index++;
            }
          
        }

        //Polygon çiz.
        public void button3_Click(object sender, EventArgs e)
        {
            Graphics gObject = canvas.CreateGraphics();

            

            string alpha = textBox11.Text;
            if (String.IsNullOrEmpty(alpha))
            {
                Brush red = new SolidBrush(Color.FromArgb(255, 255, 0, 0));

                Pen redPen = new Pen(red, 1);
                Point[] dizi = new Point[index];
                for (int i = 0; i < index; i++)
                {
                    dizi[i] = polygonDizi[i];
                }

                gObject.FillPolygon(red, dizi);
            }
            else
            {
                Brush red = new SolidBrush(Color.FromArgb(int.Parse(alpha), 255, 0, 0));

                Pen redPen = new Pen(red, 1);
                Point[] dizi = new Point[index];
                for (int i = 0; i < index; i++)
                {
                    dizi[i] = polygonDizi[i];
                }

                gObject.FillPolygon(red, dizi);

            }
            Array.Clear(polygonDizi, 0, index);
            index = 0;

        }

        //Nokta
        private void button4_Click(object sender, EventArgs e)
        {
            Graphics gObject = canvas.CreateGraphics();
            Brush red = new SolidBrush(Color.Red);
            

            string noktaX = textBox8.Text;
            string noktaY = textBox9.Text;
            string scale = textBox10.Text;

            gObject.FillRectangle(red, int.Parse(noktaX), int.Parse(noktaY), int.Parse(scale), int.Parse(scale));

        }

       

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            String xSize = textBox13.Text;
            String ySize = textBox14.Text;
            canvas.SetBounds(351, 22, int.Parse(xSize), int.Parse(ySize));
            label18.Text = String.Concat(canvas.Width);
            label19.Text = String.Concat(canvas.Height);
        }
    }
}
