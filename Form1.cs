using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomobileCost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtGas.Text = "";  txtInsurance.Text = ""; txtLoan.Text = "";
            txtMaint.Text = ""; txtOil.Text = ""; txtTires.Text = "";
            lblCostDisplay.Text = "";
           
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double dblGas; double dblInsurance; double dblLoan;
            double dblMaint; double dblOil; double dblTires;
            double dblCost;

            try
            {

                dblGas = double.Parse(txtGas.Text);
                dblInsurance = double.Parse(txtInsurance.Text);
                dblLoan = double.Parse(txtLoan.Text);
                dblMaint = double.Parse(txtMaint.Text);
                dblOil = double.Parse(txtOil.Text);
                dblTires = double.Parse(txtTires.Text);

                dblCost = dblGas + dblInsurance + dblLoan + dblMaint
                            + dblOil + dblTires;


              lblCostDisplay.Text = dblCost.ToString("c");

            }
            catch (Exception)
            {

               MessageBox.Show("Please enter a number");
            }
        }
    }
}
