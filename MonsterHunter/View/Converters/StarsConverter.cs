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
    public class StarsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int nrStars = int.Parse(value.ToString());
            LinkedList <BitmapImage> stars = new LinkedList<BitmapImage>();

            for (int idx = 0; idx < nrStars; ++idx)
                stars.AddLast(new BitmapImage(new Uri($"pack://application:,,,/Resources/Img/UI/Star.png")));
            
            return stars;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
