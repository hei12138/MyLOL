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
        public static List<Frame> framelist = new List<Frame>();
        
        public MainPage()
        {
            this.InitializeComponent();
            framelist.Add(pageFrame);
            framelist.Add(secondPageFrame);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            var view = ApplicationView.GetForCurrentView();
            //view.Title = "掌上英雄联盟";
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
            btn_info.IsClicked = true;

        }

        private void btn_frame_clicked(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Name.ToString())
            {
                case "btn_find":
                    btn_find.IsClicked = true;
                    btn_info.IsClicked = false;
                    btn_me.IsClicked = false;
                    btn_friend.IsClicked = false;
                    mainFrame.Navigate(typeof(DeservePage),framelist);
                    break;
                case "btn_me":
                    btn_find.IsClicked = false;
                    btn_info.IsClicked = false;
                    btn_me.IsClicked = true;
                    btn_friend.IsClicked = false;
                    mainFrame.Navigate(typeof(MePage), framelist);
                    break;
                case "btn_info":
                    btn_find.IsClicked = false;
                    btn_info.IsClicked = true;
                    btn_me.IsClicked = false;
                    btn_friend.IsClicked = false;
                    mainFrame.Navigate(typeof(InfoPage), framelist);
                    break;
                case "btn_friend":
                    btn_find.IsClicked = false;
                    btn_info.IsClicked = false;
                    btn_me.IsClicked = false;
                    btn_friend.IsClicked = true;
                    mainFrame.Content = FriendPage.GetSingle();
                    //mainFrame.Navigate(FriendPage.GetSingle().GetType(), framelist);
                    break;
            }
        }
    }
}
