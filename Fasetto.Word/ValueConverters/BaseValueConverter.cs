﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Fasetto.Word
{
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        #region Private Members

        private static T _converter = null;

        #endregion

        #region Markup Extension Methods

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = new T());
        }

        #endregion

        #region Value Converter Methods

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion

    }
}
