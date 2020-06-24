using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace PasswordsManager.Converters
{
    public class TagsListToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<Models.PasswordTag> && value != null)
            {
                string str = "";
                foreach(var pt in value as List<Models.PasswordTag>)
                {
                    if(str != "")
                    {
                        str += ", ";
                    }
                    str += pt.Tag.Label;
                }
                return str;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
