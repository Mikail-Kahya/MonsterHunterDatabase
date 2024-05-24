using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MonsterHunter.View.Converters
{
    public class UrlToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imageUrl = value.ToString();
            BitmapImage result = new BitmapImage(new Uri($"http://static.pokemonpets.com/images/monsters-images-800-800/{imageUrl}.png", UriKind.Absolute));
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
