using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TJS.AutoRepair.BL;
using TJS.AutoRepair.PL;

namespace TJS.AutoRepair.UI
{
    public partial class Form1 : Form
    {
        private string filename = "Customers.xml";

        private Type type = typeof(CustomerCollection);

        private CustomerCollection customers = new CustomerCollection();

        public CustomerCollection cc { get; set; }

        public Form1()
        {
            InitializeComponent();


            customers.OnCustomerAdded += ReBindCustomers;
            customers.LoadFromDB();
            //populate method
           // customers.LoadTestCustomers();
           // customers = DataAccess.LoadFromXML(filename, type) as CustomerCollection;
            
            //Refresh
           // ReBindCustomers();
           
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Customer newCust = new Customer();
            newCust.FirstName = txtFirstName.Text;
            newCust.LastName = txtLastName.Text;
            newCust.Phone = txtPhone.Text;

            customers.Add(newCust);
           // ReBindCustomers();
           

        }

        private void ReBindCustomers()
        {
            customers.Sort();
            lstCustomer.DataSource = null;
            lstCustomer.DataSource = customers;


        }

        private void RebindCars(List<Car> cars)
        {
            lstCars.DataSource = null;
            lstCars.DataSource = cars ;

            lstCars.DisplayMember = "Display";
        }

        private void lstCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Customer selected = lstCustomer.SelectedItem as Customer;

            if (selected != null)
            {
                // MessageBox.Show(selected.Phone);
                txtFirstName.Text = selected.FirstName;
                txtLastName.Text = selected.LastName;
                txtPhone.Text = selected.Phone;

                RebindCars( selected.Cars);
            }


        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            Customer selected = lstCustomer.SelectedItem as Customer;

            if (selected != null)
            {
                try
                {

                selected.FirstName = txtFirstName.Text;
                selected.LastName = txtLastName.Text;
                selected.Phone = txtPhone.Text;
                }
                catch (BlankNameException)
                {

                    MessageBox.Show("Nooo Blank ");
                }

            }
            
            ReBindCustomers();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            customers.Sort();
            ReBindCustomers();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DataAccess.SaveToXML("Customers.xml", typeof(CustomerCollection), customers);
            }
            catch (Exception ex)
            {
               
               MessageBox.Show(ex.Message);
                e.Cancel = true;
            }
            
        }
    }
}
