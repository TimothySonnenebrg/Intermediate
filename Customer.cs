
using System;
using System.Collections.Generic;
using System.Data;
using TJS.AutoRepair.PL;

namespace TJS.AutoRepair.BL
{
    public class Customer : IComparable<Customer>
    {

        private string firstName;
        private string lastName;

        public int ID { get; set; }

        public string FirstName {
            get { return firstName; }
            set {
                if (value.Trim() != "") firstName = value;
                
            }
        }
        public string LastName
        {
            get { return lastName; }
            set { if(value.Trim() != "") lastName = value; }
            
        }
        public string Phone { get; set; }

        public List <Car> Cars { get; set; }


        public Customer()
        {   
            
            //Be back here
            Cars = new List<Car>();


        }

        public Customer(DataRow row)
        {
            ID = Convert.ToInt32(row["CustomerID"]);
            FirstName = Convert.ToString(row["FirstName"]);
            LastName = Convert.ToString(row["LastName"]);
                 Cars = new List<Car>();
            string sql = "SELECT * FROM cars";
            DataTable table = DataAccess.Select(sql, null, false);

            foreach (DataRow carRow in table.Rows)
            {
                Cars.Add(new Car(carRow));
            }
        }

        public override string ToString()
        {

            //if(FirstName == ""|| LastName =="")
            //{

            //    BlankNameException e = new BlankNameException();
            //    e.IsFirstNameSet = (FirstName != "");
            //    e.IsLastNAmeSet = (LastName != "");
            //    e.Customer = this;

            //    throw e; 


            //}

            return FirstName + " " + LastName;
        }

        public int CompareTo(Customer other)
        {
            if (FirstName == other.FirstName)
                return LastName.CompareTo(other.LastName);


            return FirstName.CompareTo(other.FirstName);
        }
    }
}
