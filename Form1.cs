using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BodyMassIndex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); //Exits Application
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHeight.Text = " ";
            txtWeight.Text = " ";
            lblBMIdisplay.Text = " "; //Clears out form
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //vars declared
            double dblWeight;
            double dblHeight;
            double dblBMI;
        }
    }
}
