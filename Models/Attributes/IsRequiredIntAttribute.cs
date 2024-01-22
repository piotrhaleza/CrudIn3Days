using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Attributes
{
    public class IsRequiredIntAttribute : Attribute
    {
        public IsRequiredIntAttribute(bool canNull = false, bool canZero = true)
        {
            CanNull = canNull;
            CanZero = canZero;
        }
        public bool CanNull { get; set; }
        public bool CanZero { get; set; }
    }
}
