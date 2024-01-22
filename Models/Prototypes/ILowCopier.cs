using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Prototypes
{
    public interface ILowCopier<T>
        where T: class
    {
        void LowCopy(T Source, T Result);
    }
}
