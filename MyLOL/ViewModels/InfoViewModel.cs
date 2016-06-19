using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLOL.Models;
using Windows.ApplicationModel;
using System.ComponentModel;

namespace MyLOL.ViewModels
{
    public class InfoViewModel: INotifyPropertyChanged
    {
        public InfoViewModel()
        {

        }
        //最新
        private NewsInfo newsInfo;
        public NewsInfo NewsInfo
        {
            get { return newsInfo; }
            set
            {
                newsInfo = value;
                RaisePropertyChanged("NewsInfo");
            }
        }
        //进度环是否显示
        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;
                RaisePropertyChanged("IsActive");
            }
        }



        //推荐
        private NewsInfo recommendNews;
        public NewsInfo RecommendNews
        {
            get { return recommendNews; }
            set
            {
                recommendNews = value;
                RaisePropertyChanged("RecommendNews");
            }
        }
        //赛事
        private NewsInfo matchNews;
        public NewsInfo MatchNews
        {
            get { return matchNews; }
            set {
                matchNews = value;
                RaisePropertyChanged("MatchNews");
            }
        }

        //活动
        private NewsInfo activeNews;
        public NewsInfo ActiveNews
        {
            get { return activeNews; }
            set
            {
                activeNews = value;
                RaisePropertyChanged("ActiveNews");
            }
        }
        //视频
        private NewsInfo videoNews;
        public NewsInfo VideoNews
        {
            get { return videoNews; }
            set
            {
                videoNews = value;
                RaisePropertyChanged("VideoNews");
            }
        }
        //娱乐
        private NewsInfo entertainmentNews;
        public NewsInfo EntertainmentNews
        {
            get { return entertainmentNews; }
            set
            {
                entertainmentNews = value;
                RaisePropertyChanged("EntertainmentNews");
            }
        }
        //官方
        private NewsInfo officialNews;
        public NewsInfo OfficialNews
        {
            get { return officialNews; }
            set
            {
                officialNews = value;
                RaisePropertyChanged("OfficialNews");
            }
        }
        //美女
        private NewsInfo beautyNews;
        public NewsInfo BeautyNews
        {
            get { return beautyNews; }
            set
            {
                beautyNews = value;
                RaisePropertyChanged("BeautyNews");
            }
        }
        //攻略
        private NewsInfo raidersNews;
        public NewsInfo RaidersNews
        {
            get { return raidersNews; }
            set
            {
                raidersNews = value;
                RaisePropertyChanged("RaidersNews");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
