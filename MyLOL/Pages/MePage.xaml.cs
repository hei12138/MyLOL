using MyLOL.Pages;
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

        //TODO
        //考虑将此页面做成自定义面板


        Frame frame;
        object list;
        public MePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            list = e.Parameter;
            frame = (e.Parameter as List<Frame>)[0];
            Frame frame2= (e.Parameter as List<Frame>)[1];
        }

        private void btn_setting_Click(object sender, RoutedEventArgs e)
        {
            //meFrame.Navigate(typeof(SettingPage));
            frame.Navigate(typeof(SettingPage),list);
        }
    }
}
