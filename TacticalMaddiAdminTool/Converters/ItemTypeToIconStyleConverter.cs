using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using TacticalMaddiAdminTool.Models;
using TacticalMaddiAdminTool.ViewModels;

namespace TacticalMaddiAdminTool.Converters
{
    public class ItemTypeToIconStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Style style = new Style();
            string iconSymbol;
            Brush iconBackground;
            if (value is SetInfo)
            {
                iconSymbol = "s";
                iconBackground = new SolidColorBrush(Colors.DarkGreen);
            }
            else if (value is CollectionInfo)
            {
                iconSymbol = "c";
                iconBackground = new SolidColorBrush(Colors.Brown);
            }
            else if (value is FragmentInfo)
            {
                iconSymbol = "f";
                iconBackground = new SolidColorBrush(Colors.Navy);
            }
            else return style;

            style.TargetType = typeof(TextBlock);
            style.Setters.Add(new Setter { Property = TextBlock.BackgroundProperty, Value = iconBackground });
            style.Setters.Add(new Setter { Property = TextBlock.TextProperty, Value = iconSymbol });
            return style;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}
