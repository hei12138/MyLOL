using MyLOL.Controls;
using MyLOL.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace MyLOL
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Frame> framelist = new List<Frame>();
        
        public MainPage()
        {
            this.InitializeComponent();
            framelist.Add(pageFrame);
            framelist.Add(secondPageFrame);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            var view = ApplicationView.GetForCurrentView();
            view.Title = "MyLOL";
            //活动时的TitleBar
            view.TitleBar.BackgroundColor = Color.FromArgb(255, 36, 41, 55);
            view.TitleBar.ForegroundColor = Colors.White;
            //inactive TitleBar Color
            view.TitleBar.InactiveBackgroundColor = Colors.LightGray;
            view.TitleBar.InactiveForegroundColor = Colors.Gray;

            //Button in TitleBar Color
            view.TitleBar.ButtonBackgroundColor = Color.FromArgb(255, 36, 41, 55);
            view.TitleBar.ButtonForegroundColor = Colors.White;
            //Hover悬停状态
            view.TitleBar.ButtonHoverBackgroundColor = Colors.LightSkyBlue;
            view.TitleBar.ButtonHoverForegroundColor = Colors.White;
            //Press按下状态
            view.TitleBar.ButtonPressedBackgroundColor = Color.FromArgb(255, 0, 0, 120);
            view.TitleBar.ButtonPressedForegroundColor = Colors.White;
            //Inactive 非活动状态
            view.TitleBar.ButtonInactiveBackgroundColor = Colors.LightGray;
            view.TitleBar.ButtonInactiveForegroundColor = Colors.Gray;

            mainFrame.Navigate(typeof(InfoPage),framelist);
            btn_info.Foreground = new SolidColorBrush(Color.FromArgb(255, 68, 135, 194));
            btn_info.Background = new SolidColorBrush(Color.FromArgb(255, 214, 224, 233));

        }

        private void btn_frame_clicked(object sender, RoutedEventArgs e)
        {
            //取消所有btn_frame的前景颜色
            btn_find.Foreground = new SolidColorBrush(Colors.Black);
            btn_friend.Foreground = new SolidColorBrush(Colors.Black);
            btn_info.Foreground = new SolidColorBrush(Colors.Black);
            btn_me.Foreground = new SolidColorBrush(Colors.Black);
            //取消所有按钮的背景色
            btn_find.Background = new SolidColorBrush(Colors.Transparent);
            btn_friend.Background = new SolidColorBrush(Colors.Transparent);
            btn_info.Background = new SolidColorBrush(Colors.Transparent);
            btn_me.Background = new SolidColorBrush(Colors.Transparent);
            //给选中的btn赋值前景颜色
            (sender as Button).Foreground = new SolidColorBrush(Color.FromArgb(255, 68,135,194));
            //赋背景色
            (sender as Button).Background = new SolidColorBrush(Color.FromArgb(255, 214, 224, 233));
            //改变按钮的图片
            BitmapImage bitmap = new BitmapImage(new Uri("ms-appx:///Resources/MainPage/tab_discovery.png"));
            btn_find.SetValue(TapButton.SourceProperty, bitmap);
            BitmapImage bitmap2 = new BitmapImage(new Uri("ms-appx:///Resources/MainPage/tab_news.png"));
            btn_info.SetValue(TapButton.SourceProperty, bitmap2);
            BitmapImage bitmap3 = new BitmapImage(new Uri("ms-appx:///Resources/MainPage/tab_me.png"));
            btn_me.SetValue(TapButton.SourceProperty, bitmap3);
            BitmapImage bitmap4 = new BitmapImage(new Uri("ms-appx:///Resources/MainPage/tab_friend.png"));
            btn_friend.SetValue(TapButton.SourceProperty, bitmap4);

            switch ((sender as Button).Name.ToString())
            {
                case "btn_find":
                    bitmap.UriSource = new Uri("ms-appx:///Resources/MainPage/tab_discovery_checked.png");
                    //btn_find.SetValue(TapButton.SourceProperty, bitmap);
                    mainFrame.Navigate(typeof(DeservePage),framelist);
                    break;
                case "btn_me":
                    bitmap3.UriSource = new Uri("ms-appx:///Resources/MainPage/tab_me_checked.png");
                    //btn_me.SetValue(TapButton.SourceProperty, bitmap);
                    mainFrame.Navigate(typeof(MePage), framelist);
                    break;
                case "btn_info":
                    bitmap2.UriSource = new Uri("ms-appx:///Resources/MainPage/tab_news_checked.png");
                    //btn_info.SetValue(TapButton.SourceProperty, bitmap);
                    mainFrame.Navigate(typeof(InfoPage), framelist);
                    break;
                case "btn_friend":
                    bitmap4.UriSource = new Uri("ms-appx:///Resources/MainPage/tab_friend_checked.png");
                    //btn_friend.SetValue(TapButton.SourceProperty, bitmap);
                    mainFrame.Navigate(typeof(FriendPage), framelist);
                    break;
            }
        }
    }
}
