using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJS.AutoRepair.PL;

namespace TJS.AutoRepair.BL
{
    public delegate void CustomerAdded();

   public class CustomerCollection : List<Customer>
    {
        public CustomerAdded OnCustomerAdded { get; set; }


        public void LoadTestCustomers()
        {
            Customer cust;

            cust = new Customer();
            cust.ID = 1;
            cust.FirstName = "rayn";
            cust.LastName = "A";
            cust.Phone = "7237239";
            cust.Cars.Add(new Car("ford", "mustang", 2000));
            base.Add(cust);

            cust = new Customer();
            cust.ID = 2;
            cust.FirstName = "t";
            cust.LastName = "s";
            cust.Phone = "7273239";
            base.Add(cust);

            cust = new Customer();
            cust.ID = 3;
            cust.FirstName = "d";
            cust.LastName = "d";
            cust.Phone = "7272339";
            base.Add(cust);


           
        }

        public new void Add(Customer customer)
        {
            base.Add(customer);

            if (OnCustomerAdded != null)OnCustomerAdded();           
                
           
        }


       public void LoadFromDB()
        {
            DataAccess.ConnectionString = "Server=tcp:timsonnenberg.database.windows.net,1433;Initial Catalog=AutoRepair;Persist Security Info=False;User ID=Tim;Password=Test123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


            string sql = "SELECT * FROM customers";
            DataTable table = DataAccess.Select(sql, null, false );

            foreach (DataRow row in table.Rows)
            {
                Add(new Customer(row));
            }
            DataAccess.CloseConnection();
        }

        public int GetNextId()
        { int highest = 0;

            foreach(Customer c in this)
            {
                if (c.ID > highest)
                {
                    highest = c.ID;

                }
            } return highest + 1;
        }

    }
}
