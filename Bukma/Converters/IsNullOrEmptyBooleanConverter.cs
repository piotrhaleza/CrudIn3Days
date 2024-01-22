using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace Bukma.Converters
{
    public class IsNullOrEmptyBooleanConverter : MarkupExtension, IValueConverter
    {
        public bool NullResult { get; set; } = false;

        public IsNullOrEmptyBooleanConverter()
        {
        }
        /// <summary>
        /// Obsługuje konwersję standardową.
        /// </summary>
        /// <param name="value">Wartość konwertowana.</param>
        /// <param name="targetType">Typ docelowy.</param>
        /// <param name="parameter">Parametr.</param>
        /// <param name="culture">Kultura.</param>
        /// <returns>Wartość skonwertowana.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return NullResult;
            if (value is string st && st == String.Empty)
                return NullResult;

            return !NullResult;
        }
        /// <summary>
        /// Obsługuje konwersję zwrotną.
        /// </summary>
        /// <param name="value">Wartość konwertowana.</param>
        /// <param name="targetType">Typ docelowy.</param>
        /// <param name="parameter">Parametr.</param>
        /// <param name="culture">Kultura.</param>
        /// <returns>Wartość skonwertowana.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Zwraca obiekt this jako wartość docelowa dla rozszerzenia znaczników (zaimplementowane przez MarkupExtension).
        /// </summary>
        /// <param name="serviceProvider">Obiekt IServiceProvider.</param>
        /// <returns>Wartość docelowa dla rozszerzenia znaczników.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
