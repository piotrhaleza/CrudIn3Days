using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Views
{
    public class V_Article : BaseModel<int>
    {
        public string Name { get; set; }
        public int? NettoValue { get; set; }
        public int? BruttoValue { get; set; }
        public int? VatTax { get; set; }

        [NotMapped]
        public string DisplayVatTax => VatTax != null? VatTax + "%" : "brak informacji";
    }
}
