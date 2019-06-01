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
        int limitep, Escalado, Grados, TrasladadoX, TrasladadoY;
        int contp=0;
        List<Point> puntos;
        Pen verde = new Pen(Color.Green, 3);
        Pen rojo = new Pen(Color.Red, 3);
        Point Max;
        Point Min;
        Point Centro;
        double teta = 0;



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
        private void button7_Click(object sender, EventArgs e)//Limpiar
        {
            contp = 0;
            puntos.Clear();
            panel1.Refresh();
            comboBox1.Text = "";
            comboBox3.Text = "";
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//CantidadPuntos
        {
            limitep = Convert.ToInt32(comboBox1.Text);
            contp = 0;
            puntos.Clear();
            panel1.Refresh();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)//Error
        {
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)//Escalado
        {
            Escalado = Convert.ToInt32(comboBox3.Text);
        }
        private void button5_Click(object sender, EventArgs e)//Trasladar X,Y Boton
        {
            List<Point> traslacion;
            traslacion = Trasladar(puntos, TrasladadoX,TrasladadoY);
            puntos = traslacion;
            GCentro(puntos);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)//Trasladar X
        {
            TrasladadoX = Convert.ToInt32(textBox1.Text);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)//Trasladar Y
        {
            TrasladadoY = Convert.ToInt32(textBox2.Text);
        }
        private void button3_Click(object sender, EventArgs e)//Proyeccion X
        {
            List<Point> proyeccionX;
            proyeccionX = ProyeccionX(puntos);
            puntos = proyeccionX;
            GCentro(puntos);
        }
        private void button4_Click(object sender, EventArgs e)//Proyeccion Y
        {
            List<Point> proyeccionY;
            proyeccionY = ProyeccionY(puntos);
            puntos = proyeccionY;
            GCentro(puntos);
        }
        private void button2_Click(object sender, EventArgs e)//Escalar
        {
            List<Point> centro, escalar, origen;
            centro = MovCentro(puntos);
            escalar = Escalar(centro,Escalado);
            origen = MovOrigen(escalar);
            puntos = origen;
            GCentro(puntos);
        }
        private void button1_Click(object sender, EventArgs e)//Rotacion
        {
            List<Point> centro, rotacion, origen;
            centro = MovCentro(puntos);
            rotacion = Rotacion(centro, Grados);
            origen = MovOrigen(rotacion);
            puntos = origen;
            GCentro(puntos);
        }
        private void textBox3_TextChanged(object sender, EventArgs e)//Rotacion en grados text.box
        {
            Grados = Convert.ToInt32(textBox3.Text);
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

            panel1.CreateGraphics().DrawEllipse(rojo, Centro.X, Centro.Y, 1, 1);         
        }
        public List<Point> Trasladar(List<Point> puntos, int tx, int ty)
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
            return traslacion;
        }
        public List<Point> ProyeccionX(List<Point> puntos)
        {
            List<Point> proyeccionX = new List<Point>();
            Point PointP;
            for (int i = 0; i < puntos.Count; i++)
            {
                PointP = new Point();
                PointP.Y = (puntos[i].Y - ((puntos[i].Y - Centro.Y) * 2));
                PointP.X = puntos[i].X;
                proyeccionX.Add(PointP);
            }
            panel1.Refresh();
            DibujarFigura(proyeccionX);
            return proyeccionX;
        }
        public List<Point> ProyeccionY(List<Point> puntos)
        {
            List<Point> proyeccionY = new List<Point>();
            Point PointP;
            for (int i = 0; i < puntos.Count; i++)
            {
                PointP = new Point();
                PointP.X = (puntos[i].X - ((puntos[i].X - Centro.X) * 2));
                PointP.Y = puntos[i].Y;
                proyeccionY.Add(PointP);
            }
            panel1.Refresh();
            DibujarFigura(proyeccionY);
            return proyeccionY;
        }
        public List<Point> MovCentro(List<Point> puntos)
        {
            List<Point> cerocentro = new List<Point>(); ;
            int jy = Centro.Y;
            int jx = Centro.X;
            int cx=0;
            for (int i = 0 ; i <= jx ; i++)
            {
                cerocentro = Trasladar(puntos, -i, 0);
                cx = -i;
            }
            for (int j = 0; j <= jy; j++)
            {
                cerocentro = Trasladar(puntos, cx, -j);
            }
            return cerocentro;
        }
        public List<Point> MovOrigen(List<Point> puntos)
        {
            List<Point> origen = new List<Point>(); ;
            int jy = Centro.Y;
            int jx = Centro.X;
            int cx = 0;
            for (int i = 0; i <= Centro.X; i++)
            {
                origen = Trasladar(puntos, i, 0);
                cx = i;
            }
            for (int j = 0; j <= jy; j++)
            {
                origen = Trasladar(puntos, cx, j);
            }
            return origen;
        }
        public List<Point> Rotacion(List<Point> puntos, int grados)
        {
            List<Point> rotarlp = new List<Point>();
            Point PRotar;
            teta = 0;

            for (int i = 0; i < puntos.Count; i++)
            {
                PRotar = new Point();
                teta = (Math.PI * grados) / 180;
                PRotar.X = (int)((Math.Cos(teta) * puntos[i].X) - (Math.Sin(teta) * puntos[i].Y));
                PRotar.Y = (int)((Math.Sin(teta) * puntos[i].X) + (Math.Cos(teta) * puntos[i].Y));
                rotarlp.Add(PRotar);
            }
            DibujarFigura(rotarlp);
            return rotarlp;
        }
        public List<Point> Escalar(List<Point> puntos, int Escalado)
        {
            List<Point> escalado = new List<Point>();
            Point PEscalado;
            for (int i = 0; i < puntos.Count; i++)
            {
                PEscalado = new Point();
                PEscalado.X = puntos[i].X * Escalado;
                PEscalado.Y = puntos[i].Y * Escalado;
                escalado.Add(PEscalado);
            }
            DibujarFigura(escalado);
            return escalado;
        }
    }
}