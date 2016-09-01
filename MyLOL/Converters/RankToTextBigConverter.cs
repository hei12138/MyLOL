using MyLOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace MyLOL.Converters
{
    public class RankToTextBigConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch ((RankBigState)value)
            {
                case RankBigState.Challenger:
                    return "挑战者";
                    break;
                case RankBigState.Master:
                    
                    break;
                case RankBigState.DiaMond:
                    break;
                case RankBigState.Platinum:
                    break;
                case RankBigState.Gold:
                    break;
                case RankBigState.Silver:
                    break;
                case RankBigState.Bronze:
                  
                    break;
                case RankBigState.None:
                    break;
            }
            return "挑战者";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
