using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using MyLOL.Helper;
using MyLOL.Models;
using Windows.Data.Json;
using Newtonsoft.Json;
using MyLOL.ViewModels;
using MyLOL.Pages;
using System.ComponentModel;
using MyLOL.Controls;


// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace MyLOL
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class InfoPage : Page, INotifyPropertyChanged
    {
        Frame frame;
        public InfoViewModel NewsViewModel { get; set; }
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
       
        public InfoPage()
        {
            NewsViewModel = new InfoViewModel();

            this.InitializeComponent();
            
        }



        //属性变更通知
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            
            frame = (e.Parameter as List<Frame>)[0];

            var str1 = await Helper.NewsHelper.GetNews("c13", "1");
            if (str1 != null)
            {
                NewsViewModel.RecommendNews = JsonConvert.DeserializeObject<NewsInfo>(str1);
            }
            DataContext = NewsViewModel;
            flipView.SelectedItem = flipView.Items.FirstOrDefault();
            listBox.SelectedItem = listBox.Items.FirstOrDefault();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //获取到页面所代表的地址
            var str = (((sender as Button).DataContext) as MyLOL.Models.NewsList).article_url;
            //拼接字符串
            var apiUrl = string.Format("http://101.226.76.163/static/pages/news/phone/{0}", str);
           //跳转到新闻页面
            frame.Navigate(typeof(NewsPage), apiUrl);
        }

        private async void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsActive = true;
            var index = (sender as Pivot).SelectedIndex;
            switch (index)
            {
                case 0:
                    var str = await Helper.NewsHelper.GetNews("c12","1");
                    if (str != null)
                    {
                        NewsViewModel.NewsInfo = JsonConvert.DeserializeObject<NewsInfo>(str);
                    }
                    break;
                case 1:
                    //赛事
                    //判断是否为空
                    if (NewsViewModel.MatchNews == null)
                    {
                        var str2 = await Helper.NewsHelper.GetNews("c73", "1");
                        if (str2 != null)
                        {
                            NewsViewModel.MatchNews = JsonConvert.DeserializeObject<NewsInfo>(str2);
                        }
                        
                    }

                    break;
                case 2:
                    //活动
                    if (NewsViewModel.ActiveNews == null)
                    {
                        var str3 = await Helper.NewsHelper.GetNews("c23", "1");
                        if (str3 != null)
                        {
                            NewsViewModel.ActiveNews = JsonConvert.DeserializeObject<NewsInfo>(str3);
                        }
                    }
                    break;
                case 3:
                    //视频
                    if (NewsViewModel.VideoNews == null)
                    {
                        var str4 = await Helper.NewsHelper.GetNews("c73", "1");
                        if (str4 != null)
                        {
                            NewsViewModel.VideoNews = JsonConvert.DeserializeObject<NewsInfo>(str4);
                        }
                       
                    }
                    break;
                case 4:
                    //娱乐
                    if (NewsViewModel.EntertainmentNews == null)
                    {
                        var str5 = await Helper.NewsHelper.GetNews("c18", "1");
                        if (str5 != null)
                        {
                            NewsViewModel.EntertainmentNews = JsonConvert.DeserializeObject<NewsInfo>(str5);
                        }
                       
                    }
                    break;
                case 5:
                    //官方
                    if (NewsViewModel.OfficialNews == null)
                    {
                        var str6 = await Helper.NewsHelper.GetNews("c3", "1");
                        if (str6 != null)
                        {
                            NewsViewModel.OfficialNews = JsonConvert.DeserializeObject<NewsInfo>(str6);
                        }
                       
                    }
                    break;
                case 6:
                    //美女
                    if (NewsViewModel.BeautyNews == null)
                    {
                        var str7 = await Helper.NewsHelper.GetNews("c17", "1");
                        if (str7 != null)
                        {
                            NewsViewModel.BeautyNews = JsonConvert.DeserializeObject<NewsInfo>(str7);
                        }
                    }
                    break;
                case 7:
                    //攻略
                    if (NewsViewModel.RaidersNews == null)
                    {
                        var str8 = await Helper.NewsHelper.GetNews("c10", "1");
                        if (str8 != null)
                        {
                            NewsViewModel.RaidersNews = JsonConvert.DeserializeObject<NewsInfo>(str8);
                        }
                    }
                    break;
            }
            IsActive = false;
        }
    }
}
