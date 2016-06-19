using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace MyLOL.Converters
{
    public class indexToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //value即为绑定的数据源
            //selectedindex为2 value也为2
            //该converter会循环遍历
            //var para = (parameter as ListBoxItem).IsSelected;
            //value如果不显式绑定的话，绑定的数据是数据源
            //var str = (value as ListBoxItem).IsSelected;
            return new SolidColorBrush(Colors.White);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
