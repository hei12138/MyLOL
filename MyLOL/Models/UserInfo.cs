using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLOL.Models
{
    public class UserInfo: INotifyPropertyChanged
    {
        public UserInfo()
        {
            UserName = "hei123";
            GameID = "ceshiyong";
            Level = 30;
            GameStatus = false;
            TotalGame = 2478;
            WinGame = 1388;
            FailGame = 1090;
            winPro = 0.56;
        }


        //用户名
        private string userName;
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
        private string gameID;
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
        private int level;
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
        private RankBigState rankBig;
        public RankBigState RankBig
        {
            get { return rankBig; }
            set
            {
                rankBig = value;
                RaisePropertyChanged("RankBig");
            }
        }
        //小duanw
        private RankSmallState rankSmall;
        public RankSmallState RankSmall
        {
            get { return rankSmall; }
            set
            {
                rankSmall = value;
                RaisePropertyChanged("RankSmall");
            }
        }
        //总场次
        private int totalGame;
        public int TotalGame
        {
            get { return totalGame; }
            set
            {
                totalGame = value;
                RaisePropertyChanged("TotalGame");
            }
        }
        //胜场次
        private int winGame;
        public int WinGame
        {
            get { return winGame; }
            set
            {
                winGame = value;
                RaisePropertyChanged("WinGame");
            }
        }
        //败场次
        private int failGame;
        public int FailGame
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
        private bool gameStatus;
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
    public enum RankBigState
    {
        Challenger,Master,DiaMond,Platinum,Gold,Silver,Bronze,None
    }
    public enum RankSmallState
    {
        Ⅰ,
        Ⅱ,
        Ⅲ,
        Ⅳ,
        Ⅴ
    }
}
