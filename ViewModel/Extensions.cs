using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMO_WPF.NET8.ViewModel
{
    public static class Extensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerableList)
        {
            return new ObservableCollection<T>(enumerableList);
        }
    }
}
