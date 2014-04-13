using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using TacticalMaddiAdminTool.ViewModels;

namespace TacticalMaddiAdminTool.Converters
{
    public class ItemTypeToIconStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var itemViewModel = (ItemViewModel)value;
            var style = new Style();
            string iconSymbol;
            Brush iconBackground;
            switch (itemViewModel.ItemType)
            {
                case "Fragments":
                    iconSymbol = "F";
                    iconBackground = new SolidColorBrush(Color.FromRgb(197, 215, 249));
                    break;
                case "Sets":
                    iconSymbol = "S";
                    iconBackground = new SolidColorBrush(Color.FromRgb(238, 213, 186));
                    break;
                case "Collections":
                    iconSymbol = "C";
                    iconBackground = new SolidColorBrush(Color.FromRgb(208, 231, 199));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }


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
