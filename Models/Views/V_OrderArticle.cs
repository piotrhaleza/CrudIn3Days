using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Views
{
    public class V_OrderArticle : BaseModel<int>
    {
        public string Name { get; set; }
        public string ArticleName { get; set; }
        public int Amount { get; set; }
        public int ValueNetto { get; set; }
        public int ValueBrutto { get; set; }

    }
}
