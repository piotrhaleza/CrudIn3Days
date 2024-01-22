using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Client : BaseModel<int>
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

        [IsRequiredStringAttribute]
        public string Surname
        {
            get { return _Surname; }
            set
            {
                _Surname = value;
                OnPropertyChanged();
            }
        }
        private string _Surname;

        public string City { get; set; }
        public string PostCode { get; set; }
        public string HouseNumber { get; set; }
    }
}
