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
        Pen pen = new Pen(Color.Green, 3);


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
                panel1.CreateGraphics().DrawEllipse(pen,e.X, e.Y, 1,1);
            }
            if(contp==limitep)
            {
                DibujarFigura(puntos);
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
                    panel1.CreateGraphics().DrawLine(pen, puntos[i], puntos[i + 1]);
                }
                else
                {
                    panel1.CreateGraphics().DrawLine(pen, puntos[i], puntos[0]);
                }
            }
        }

    }
}
