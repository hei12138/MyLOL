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


// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace MyLOL
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class InfoPage : Page
    {
        Frame frame;
        public InfoViewModel NewsViewModel { get; set; }
        public InfoPage()
        {
            NewsViewModel = new InfoViewModel();
            //NewsViewModel.NewsInfo = new NewsInfo();
            this.InitializeComponent();
        }

        //TODO 添加ProgressBar


        HttpClient client = new HttpClient();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            
            frame = (e.Parameter as List<Frame>)[0];
            NewsViewModel.IsActive = true;
            var str = await Helper.NewsHelper.GetNews();
            if (str != null)
            {
                NewsViewModel.NewsInfo = JsonConvert.DeserializeObject<NewsInfo>(str);
            }
            
            var str2 = await Helper.NewsHelper.GetNews("c13", "1");
            if (str2 != null)
            {
                NewsViewModel.RecommendNews = JsonConvert.DeserializeObject<NewsInfo>(str2);
            }
           
            NewsViewModel.IsActive = false;
           
            DataContext = NewsViewModel;
            flipView.SelectedItem = flipView.Items.FirstOrDefault();
            //flipView.SelectedIndex = -1;
            //flipView.SelectedIndex = 0;

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
            NewsViewModel.IsActive = true;
            var index = (sender as Pivot).SelectedIndex;
            switch (index)
            {
                case 1:
                    //赛事
                    //判断是否为空
                    if (NewsViewModel.MatchNews == null)
                    {
                        var str2 = await Helper.NewsHelper.GetNews("c73", "1");
                        NewsViewModel.MatchNews = JsonConvert.DeserializeObject<NewsInfo>(str2);
                    }

                    break;
                case 2:
                    //活动
                    if (NewsViewModel.ActiveNews == null)
                    {
                        var str3 = await Helper.NewsHelper.GetNews("c23", "1");
                        NewsViewModel.ActiveNews = JsonConvert.DeserializeObject<NewsInfo>(str3);
                    }
                    break;
                case 3:
                    //视频
                    if (NewsViewModel.VideoNews == null)
                    {
                        var str4 = await Helper.NewsHelper.GetNews("c73", "1");
                        NewsViewModel.VideoNews = JsonConvert.DeserializeObject<NewsInfo>(str4);
                    }
                    break;
                case 4:
                    //娱乐
                    if (NewsViewModel.EntertainmentNews == null)
                    {
                        var str5 = await Helper.NewsHelper.GetNews("c18", "1");
                        NewsViewModel.EntertainmentNews = JsonConvert.DeserializeObject<NewsInfo>(str5);
                    }
                    break;
                case 5:
                    //官方
                    if (NewsViewModel.OfficialNews == null)
                    {
                        var str6 = await Helper.NewsHelper.GetNews("c3", "1");
                        NewsViewModel.OfficialNews = JsonConvert.DeserializeObject<NewsInfo>(str6);
                    }
                    break;
                case 6:
                    //美女
                    if (NewsViewModel.BeautyNews == null)
                    {
                        var str7 = await Helper.NewsHelper.GetNews("c17", "1");
                        NewsViewModel.BeautyNews = JsonConvert.DeserializeObject<NewsInfo>(str7);
                    }
                    break;
                case 7:
                    //攻略
                    if (NewsViewModel.RaidersNews == null)
                    {
                        var str8 = await Helper.NewsHelper.GetNews("c10", "1");
                        NewsViewModel.RaidersNews = JsonConvert.DeserializeObject<NewsInfo>(str8);
                    }
                    break;
            }
            NewsViewModel.IsActive = false;
        }
    }
}
