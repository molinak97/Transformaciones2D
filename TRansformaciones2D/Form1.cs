using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRansformaciones2D
{
    public partial class Form1 : Form
    {
        int limitep, Escalado, Rotacion, TrasladadoX, TrasladadoY;
        int contp=0;
        List<Point> puntos;
        Pen verde = new Pen(Color.Green, 3);
        Pen rojo = new Pen(Color.Red, 3);
        Point Max;
        Point Min;
        Point Centro;
        Point CeroCentro;


        public Form1()
        {
            puntos = new List<Point>();
            InitializeComponent();
        }
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                if (contp < limitep)
                {
                    puntos.Add(new Point(e.X, e.Y));
                    contp++;
                    panel1.CreateGraphics().DrawEllipse(verde, e.X, e.Y, 1, 1);
                }
                if (contp == limitep)
                {
                    DibujarFigura(puntos);
                    GCentro(puntos);
                }
            }
            else
            {
                MessageBox.Show("Selecionar Puntos a Dibujar");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//CantidadPuntos
        {
            limitep = Convert.ToInt32(comboBox1.Text);
            contp = 0;
            puntos.Clear();
            panel1.Refresh();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)//Rotacion en grados
        {
            Rotacion = Convert.ToInt32(comboBox2.Text);
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)//Escalado
        {
            Escalado = Convert.ToInt32(comboBox2.Text);
        }



        private void button7_Click(object sender, EventArgs e)//Limpiar
        {
            contp = 0;
            puntos.Clear();
            panel1.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)//Trasladar X,Y Boton
        {
            Trasladar(puntos, TrasladadoX,TrasladadoY);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//Trasladar X
        {
            TrasladadoX = Convert.ToInt32(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)//Trasladar Y
        {
            TrasladadoY = Convert.ToInt32(textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProyeccionX(puntos);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProyeccionY(puntos);
        }

        void DibujarFigura(List<Point> puntos)
        {
            for(int i=0 ; i < puntos.Count; i++)
            {
                if (i < puntos.Count-1)
                {
                    panel1.CreateGraphics().DrawLine(verde, puntos[i], puntos[i + 1]);
                }
                else
                {
                    panel1.CreateGraphics().DrawLine(verde, puntos[i], puntos[0]);
                }
            }
        }
        void GCentro(List<Point> puntos)
        {
            Max = puntos[0];
            Min = puntos[0];

            for (int i = 0; i < puntos.Count; i++)
            {
                if (Max.X < puntos[i].X)
                {
                    Max.X = puntos[i].X;
                }
                if (Max.Y < puntos[i].Y)
                {
                    Max.Y = puntos[i].Y;
                }
            }

            for (int i = 0; i < puntos.Count; i++)
            {
                if (Min.X > puntos[i].X)
                {
                    Min.X = puntos[i].X;
                }
                if (Min.Y > puntos[i].Y)
                {
                    Min.Y = puntos[i].Y;
                }
            }
            Centro.X = (Max.X + Min.X) / 2;
            Centro.Y = (Max.Y + Min.Y) / 2;

            panel1.CreateGraphics().DrawEllipse(rojo, Centro.X, Centro.Y, 2, 2);
            //MovCentro(puntos);
        }
        void Trasladar(List<Point> puntos, int tx, int ty)
        {
            List<Point> traslacion = new List<Point>();
            Point PointT;
            for (int i=0; i < puntos.Count; i++)
            {

                PointT = new Point();
                PointT.X = puntos[i].X + tx;
                PointT.Y = puntos[i].Y + ty;

                traslacion.Add(PointT);
            }
            panel1.Refresh();
            DibujarFigura(traslacion);
            GCentro(traslacion);
            puntos = traslacion;
        }
        void ProyeccionX(List<Point> puntos)
        {
            List<Point> proyeccionX = new List<Point>();
            Point PointP;
            for (int i = 0; i < puntos.Count; i++)
            {

                PointP = new Point();
                PointP.X = (puntos[i].X - ((puntos[i].X - Centro.X) * 2));
                PointP.Y = puntos[i].Y;
                proyeccionX.Add(PointP);
            }
            panel1.Refresh();
            DibujarFigura(proyeccionX);
            GCentro(proyeccionX);
            //puntos = proyeccionX;
        }
        void ProyeccionY(List<Point> puntos)
        {
            MovCentro(puntos);
            //List<Point> proyeccionY = new List<Point>();
            //Point PointP;
            //for (int i = 0; i < puntos.Count; i++)
            //{

            //    PointP = new Point();
            //    PointP.Y = (puntos[i].Y - ((puntos[i].Y - Centro.Y) * 2));
            //    PointP.X = puntos[i].X;
            //    proyeccionY.Add(PointP);
            //}
            //panel1.Refresh();
            //DibujarFigura(proyeccionY);
            //GCentro(proyeccionY);
            ////puntos = proyeccionY;
        }
        void MovCentro(List<Point> punto)
        {
            int jy = Centro.Y;
            int jx = Centro.X;
            int cx=0;
            for (int i = 0 ; i <= jx ; i++)
                {
                    Trasladar(punto, -i, 0);
                    cx = -i;
                }
            for (int j = 0; j <= jy; j++)
            {
                Trasladar(punto, cx, -j);
            }
        }
        
    }
}
