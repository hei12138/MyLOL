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
        //用户名
        public string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                RaisePropertyChanged("UserName");
            }
        }
        //游戏ID
        public string gameID;
        public string GameID
        {
            get { return gameID; }
            set
            {
                gameID = value;
                RaisePropertyChanged("GameID");
            }
        }
        //大段位
        public string rankBig;
        public string RankBig
        {
            get { return rankBig; }
            set
            {
                rankBig = value;
                RaisePropertyChanged("RankBig");
            }
        }
        //小duanw
        public string rankSmall;
        public string RankSmall
        {
            get { return rankSmall; }
            set
            {
                rankSmall = value;
                RaisePropertyChanged("RankSmall");
            }
        }
        //总场次
        public string totalGame;
        public string TotalGame
        {
            get { return totalGame; }
            set
            {
                totalGame = value;
                RaisePropertyChanged("TotalGame");
            }
        }
        //胜场次
        public string winGame;
        public string WinGame
        {
            get { return winGame; }
            set
            {
                winGame = value;
                RaisePropertyChanged("WinGame");
            }
        }
        //败场次
        public string failGame;
        public string FailGame
        {
            get { return failGame; }
            set
            {
                failGame = value;
                RaisePropertyChanged("FailGame");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  
        }
    }
}
