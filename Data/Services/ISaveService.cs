using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface ISaveService<T,V_T>
    {
        Task<bool> Save(T saveItem);
        bool CanSave(T saveItem);
        void UpdateItem(T saveItem);
        List<V_T> GetAllItems();
        T GetItem(int id);
    }
}
