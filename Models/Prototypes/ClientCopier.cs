using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Prototypes
{
    public class ClientCopier : ILowCopier<Client>
    {
        public void LowCopy(Client Source, Client Result)
        {
            Result.Name = Source.Name;
            Result.Surname = Source.Surname;
            Result.City = Source.City;
            Result.PostCode = Source.PostCode;
            Result.HouseNumber = Source.HouseNumber;
        }
    }
}
