﻿using System;
using System.Diagnostics;
using System.Globalization;
using Fasetto.Word.Core;

namespace Fasetto.Word
{
    public class IoCConverter : BaseValueConverter<IoCConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string) value)
            {
                case nameof(ApplicationViewModel):
                    return IoC.Get<ApplicationViewModel>();
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
