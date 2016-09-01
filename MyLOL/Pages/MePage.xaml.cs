using MyLOL.Pages;
using MyLOL.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace MyLOL
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MePage : Page
    {
        //TODO 自定义的imageButton 可以显示图像，以及按下的图像


        //考虑将此页面做成自定义面板
        public MeViewModel MeViewModel { get; set; }
        private TranslateTransform _tt;


        Frame frame;
        object list;
        public MePage()
        {
            MeViewModel = new MeViewModel();
            InitializeComponent();
            flip.AddHandler(PointerWheelChangedEvent, new PointerEventHandler(OnChanged), true);
            _tt = header.RenderTransform as TranslateTransform;
            if (_tt == null)
            {
                //似乎是在这里将位移值给页面
               header.RenderTransform = _tt = new TranslateTransform();
            }
        }
        private void OnChanged(object sender, PointerRoutedEventArgs e)
        {
            if (e.GetCurrentPoint(flip).Properties.MouseWheelDelta < 0)
            {
                scroll.ChangeView(0, scroll.VerticalOffset + 75, 1);
            }
            else
            {
                scroll.ChangeView(0, scroll.VerticalOffset - 75, 1);
            }
            e.Handled = true;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            list = e.Parameter;
            frame = (e.Parameter as List<Frame>)[0];
            Frame frame2 = (e.Parameter as List<Frame>)[1];

            var info= await Helper.StrogeHelper.GetPersonFile();
            if (info != null)
            {
                MeViewModel.UserInfo = info;
            }
            DataContext = MeViewModel;
        }

        private void btn_setting_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(SettingPage), list);
        }

        private void scroll_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {

            if (scroll.VerticalOffset >= 130)
            {
                _tt.Y = -130;
            }
            else
            {
                _tt.Y = -scroll.VerticalOffset;
            }
        }

        //胜率详情
        private void btn_Winpro_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(WinProPage), list);
        }

        //用户详情
        private void btn_Userinfo_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(UserInfoEditer), list);
        }
    }

}
