using MyLOL.Controls;
using MyLOL.Models;
using MyLOL.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace MyLOL.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public InfoViewModel NewsViewModel { get; set; }
        public BlankPage1()
        {
            NewsViewModel = new InfoViewModel();
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            HttpClient client = new HttpClient();
            //await Task.Delay(1000);
            //this.Frame.Navigate(typeof(MainPage));
            //得到推荐页
            var str= await Helper.NewsHelper.GetNews("c13", "1");
            NewsViewModel.RecommendNews = JsonConvert.DeserializeObject<NewsInfo>(str);
            //此处已经可以获得viewmodel
            //NewsViewModel.NewsInfo = new NewsInfo();
            
            DataContext = NewsViewModel.RecommendNews;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //aaa.Point = new Point(200, 200);
        }
    }

    public class MyDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate JishuDataTemplate { get; set; }
        public DataTemplate OushuDataTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            //item为拿到的items的每一个对象
            var i = (int)item;
            if (i % 2 == 0)
            {
                return OushuDataTemplate;
            }
            else
            {
                return JishuDataTemplate;
            }
            //return base.SelectTemplateCore(item, container);
        }
    }


    public class Pointk
    {
        private Point pointks;
        public Point Pointks
        {
            get { return new Point(100,40); }
            set { this.pointks = value; }
        }
    }


    public class GlobalResource
    {
        private ObservableCollection<string> _items;
        public ObservableCollection<string> Items
        {
            get
            {
                return _items = _items ?? new ObservableCollection<string>
                {
                    Guid.NewGuid().ToString(),
                    Guid.NewGuid().ToString(),
                    Guid.NewGuid().ToString(),
                    Guid.NewGuid().ToString(),
                };
            }
            set
            {
                _items = value;
               
            }
        }
    }
}
