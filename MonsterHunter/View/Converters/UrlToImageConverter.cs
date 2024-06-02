using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MonsterHunter.View.Converters
{
    public class UrlToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return new BitmapImage(new Uri("pack://application:,,,/Resources/Img/monsters/Anjanath.png"));


            string name = value.ToString();
            name= name.Replace(" ", "-").ToLower();
            try
            {
                return new BitmapImage(new Uri($"pack://application:,,,/Resources/Img/monsters/{name}.png"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new BitmapImage(new Uri("pack://application:,,,/Resources/Img/monsters/Anjanath.png"));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
