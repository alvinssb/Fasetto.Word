using System;
using System.Globalization;

namespace Fasetto.Word
{
    public class BoolenInvertConverter : BaseValueConverter<BoolenInvertConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !(bool) value;

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
