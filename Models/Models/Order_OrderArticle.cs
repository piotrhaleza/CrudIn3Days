using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Order_OrderArticle:BaseModel<int>
    {
        public int OrderArticleId { get; set; }
        public int OrderId { get; set; }
    }
}
