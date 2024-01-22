using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalLibrary
{
    public static class CollectionHelper
    {
        public static void AddCollection<T>(this ObservableCollection<T> observable, IEnumerable<T> col)
        {
            foreach (var item in col)
                observable.Add(item);
        }
    }
}
