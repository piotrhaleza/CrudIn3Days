using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukma.Filters
{
    public interface IFilter<T>
    {
        List<T> GetFiltredList(List<T> values);
        bool IsSetUp { get; set; }

    }
}
