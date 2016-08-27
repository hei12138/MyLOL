using MyLOL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLOL.ViewModels
{
    public class MeViewModel : INotifyPropertyChanged
    {
        public MeViewModel()
        {
            UserInfo = new UserInfo();
            MatchInfo = new MatchInfo();

        }
        private MatchInfo matchInfo;
        public MatchInfo MatchInfo
        {
            get { return matchInfo; }
            set
            {
                matchInfo = value;
                RaisePropertyChanged("MatchInfo");
            }
        }
        private UserInfo userInfo;
        public UserInfo UserInfo
        {
            get { return userInfo; }
            set
            {
                userInfo = value;
                RaisePropertyChanged("UserInfo");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  
        }
    }
}
