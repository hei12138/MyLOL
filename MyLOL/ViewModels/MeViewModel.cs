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
            UserName = "hei123";
            GameID = "ceshiyong";
            Level = 30;
            GameStatus = false;
            TotalGame = "2478";
            WinGame = "1388";
            FailGame = "1090";
            winPro = 0.56;
            MatchInfo = new MatchInfo();

        }
        public MatchInfo matchInfo;
        public MatchInfo MatchInfo
        {
            get { return matchInfo; }
            set
            {
                matchInfo = value;
                RaisePropertyChanged("MatchInfo");
            }
        }

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
        //等级
        public int level;
        public int Level
        {
            get { return level; }
            set
            {
                level = value;
                RaisePropertyChanged("Level");
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
        //胜率
        private double winPro;
        public double WinPro
        {
            get { return winPro; }
            set
            {
                winPro = value;
                RaisePropertyChanged("WinPro");
            }
        }

        //游戏状态
        public bool gameStatus;
        public bool GameStatus
        {
            get { return gameStatus; }
            set
            {
                gameStatus = value;
                RaisePropertyChanged("GameStatus");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  
        }
    }
}
