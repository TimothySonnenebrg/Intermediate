using System;
using System.Data;

namespace TJS.AutoRepair.BL
{
  public  class Car : Vehicle   /*, IComparable<Car>*/
    {

        public int ID { get; set; }


        public string Model { get; set; }

        public string Color { get; set; }

        public string Display
        {
            get { 
            
                return Year.ToString()+" "+ Make+" "+Model;
            }
        }

        public Car(string make, string model, int year)
        {
            Year = 2000;
            Model = model;
            Make = make;  

           
        }

        public Car(DataRow row) { 
            Year = Convert.ToInt32(row["Year"]);
            Model = Convert.ToString(row["Model"]);
            Make = Convert.ToString(row["Make"]); 
            
          }   
        public override string ToString()
        {
            return Year.ToString() + " " + Make + " " + Model;
        }

        public Car() { } //Pramless Const

    }
}
