using System;
using System.Globalization;

namespace Fasetto.Word
{
    public class TimeToDisplayTimeConverter : BaseValueConverter<TimeToDisplayTimeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = (DateTimeOffset) value;

            if (time.Date == DateTime.UtcNow.Date)
                return time.ToLocalTime().ToString("HH:mm");

            return time.ToLocalTime().ToString("HH:mm, dd MMM yyyy");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
