using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class MyTask : BaseModel<int>
    {
        public string Name { get; set; }
        public string  Descryption { get; set; }

    }
}
