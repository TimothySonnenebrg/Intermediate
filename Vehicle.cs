using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJS.AutoRepair.BL
{
   public abstract class Vehicle
    {
        public string VIN { get; set; }

        public string Make { get; set; }

        public int Year { get; set; }


        public override string ToString()
        {
            //return base.ToString();
            return "VIN #" + VIN;
        }




    }
}
