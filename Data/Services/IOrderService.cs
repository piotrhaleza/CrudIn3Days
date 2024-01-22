using Models.Models;
using Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface IOrderService : ISaveService<Order, V_Order>
    {
    }
}
