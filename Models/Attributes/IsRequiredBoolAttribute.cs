using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Attributes
{
    public class IsRequiredBoolAttribute : Attribute
    {
        public IsRequiredBoolAttribute(bool expecteValue = true)
        {
            ExpecteValue = expecteValue;
        }
        public bool ExpecteValue { get; set; }
    }
}
