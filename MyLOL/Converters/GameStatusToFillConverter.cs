using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace MyLOL.Converters
{
    public class GameStatusToFillConverter : IValueConverter
    {
        public SolidColorBrush solid = new SolidColorBrush();
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((bool)value)
            {
                solid.Color = Colors.Green;
            }
            else
            {
                solid.Color = Colors.Gray;
            }
            return solid;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
