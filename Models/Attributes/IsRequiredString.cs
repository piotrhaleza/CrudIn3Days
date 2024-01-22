using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Attributes
{
    public class IsRequiredStringAttribute : Attribute
    {
        public IsRequiredStringAttribute(bool canNull = false, bool canEmpty = false)
        {
            CanNull = canNull;
            CanEmpty = canEmpty;
        }
        public bool CanNull { get; set; }
        public bool CanEmpty { get; set; }
    }
}
