using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Prototypes
{
    public class OrderCopier : ILowCopier<Order>
    {
        public void LowCopy(Order Source, Order Result)
        {
            Result.Date = Source.Date;
            Result.ClientId = Source.ClientId;
        }
    }
}
