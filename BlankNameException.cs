using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJS.AutoRepair.BL
{
    public class BlankNameException : Exception
    {
        public BlankNameException()
            : base("Name Not Set")
        {

        }


        public bool IsFirstNameSet { get; set; }
        public bool IsLastNAmeSet { get; set; }

        public Customer Customer { get; set; }
    }
}
