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
        int limite, Escalado, Rotacion;
        int contc = 0;
        Pen pen = new Pen(Color.Green, 3);


        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rotacion = Convert.ToInt32(comboBox2.Text);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            limite = Convert.ToInt32(comboBox1.Text);
            contc = 0;
            panel1.Refresh();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Escalado = Convert.ToInt32(comboBox2.Text);
        }

    }
}
