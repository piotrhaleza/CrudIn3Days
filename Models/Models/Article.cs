using Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Article :BaseModel<int>
    {
        [IsRequiredStringAttribute]
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }
        private string _Name;


        public int? NettoValue
        {
            get { return _NettoValue; }
            set
            {
                _NettoValue = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(BruttoValue));
            }
        }
        private int? _NettoValue;

        public int? VatTax
        {
            get { return _VatTax; }
            set
            {
                _VatTax = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(BruttoValue));
            }
        }
        private int? _VatTax;

        [NotMapped]
        public int BruttoValue => NettoValue.HasValue && VatTax.HasValue ? NettoValue.Value + (VatTax.Value * NettoValue.Value)/100 : 0;
    }
}
