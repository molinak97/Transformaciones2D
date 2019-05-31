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
        int limitep, Escalado, Rotacion;
        int contp=0;
        List<Point> puntos;
        Pen verde = new Pen(Color.Green, 3);
        Pen rojo = new Pen(Color.Red, 3);
        Point Max;
        Point Min;
        Point Centro;


        public Form1()
        {
            puntos = new List<Point>();
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rotacion = Convert.ToInt32(comboBox2.Text);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if(contp < limitep)
            {
                puntos.Add(new Point(e.X, e.Y));
                contp++;
                panel1.CreateGraphics().DrawEllipse(verde,e.X, e.Y, 1,1);
            }
            if(contp==limitep)
            {
                DibujarFigura(puntos);
                GCentro(puntos);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            limitep = Convert.ToInt32(comboBox1.Text);
            contp = 0;
            puntos.Clear();
            panel1.Refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            contp = 0;
            puntos.Clear();
            panel1.Refresh();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Escalado = Convert.ToInt32(comboBox2.Text);
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
        }
    }
}
