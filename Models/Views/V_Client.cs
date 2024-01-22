using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Views
{
    public class V_Client : BaseModel<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string HouseNumber { get; set; }
    }
}
