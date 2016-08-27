using MyLOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace MyLOL.Converters
{
    public class RankToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            BitmapImage bmp = new BitmapImage(new Uri("ms-appx:///Resources/MePage/rankImage/dan_none.png"));
            switch ((RankBigState)value)
            {
                case RankBigState.Challenger:
                    bmp.UriSource = new Uri("ms-appx:///Resources/MePage/rankImage/dan_challenger.png");
                    return bmp;
                    //return "ms-appx:///Resources/MePage/rankImage/dan_challenger.png";
                case RankBigState.Master:
                    bmp.UriSource = new Uri("ms-appx:///Resources/MePage/rankImage/dan_master.png");
                    return bmp;
                case RankBigState.DiaMond:
                    bmp.UriSource = new Uri("ms-appx:///Resources/MePage/rankImage/dan_diamond.png");
                    return bmp;
                case RankBigState.Platinum:
                    bmp.UriSource = new Uri("ms-appx:///Resources/MePage/rankImage/dan_platinum.png");
                    return bmp;
                case RankBigState.Gold:
                    bmp.UriSource = new Uri("ms-appx:///Resources/MePage/rankImage/dan_gold.png");
                    return bmp;
                case RankBigState.Silver:
                    bmp.UriSource = new Uri("ms-appx:///Resources/MePage/rankImage/dan_silver.png");
                    return bmp;
                case RankBigState.Bronze:
                    bmp.UriSource = new Uri("ms-appx:///Resources/MePage/rankImage/dan_bronze.png");
                    return bmp;
                case RankBigState.None:
                    return bmp;
            }
            return bmp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
