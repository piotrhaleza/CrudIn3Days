using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Views
{
    public class V_Order:BaseModel<int>
    {
        public DateTime Date { get; set; }
        public int ValueBrutto { get; set; }
        public int ValueNetto { get; set; }
        public string  ClientName { get; set; }
    }
}
