using MyLOL.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace MyLOL.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SettingPage : PageBase
    {
        //此时的frame应为secondframe
        Frame frame;
        const string SETTING_IS_DISPLAY_STATUS = "is display statusbar";
        ApplicationDataContainer rootContainer = ApplicationData.Current.LocalSettings;
        public SettingPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //判断是否显示状态栏
            object isdisplay;
            if (rootContainer.Values.TryGetValue(SETTING_IS_DISPLAY_STATUS, out isdisplay))
            {
                //存在该键值
                toggleSwitch.IsOn = (bool)isdisplay;
            }
            else
            {
                //不存在该键值
                rootContainer.Values[SETTING_IS_DISPLAY_STATUS] = true;
                toggleSwitch.IsOn = true;
            }




            frame = (e.Parameter as List<Frame>)[1];
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Content = null;
        }

        private void btn_about_Click(object sender, RoutedEventArgs e)
        {
            //TODO
            //在此需要将pageFrame的页面内容设为不可用
            //var str= this.Frame.Name;
            //this.Frame.Focus(FocusState.Unfocused);
            //从此处入手，可设置不与用户交互
            //this.Frame.IsEnabled = false;
            //不可用
            //this.Frame.ManipulationMode = ManipulationModes.None;
            frame.Navigate(typeof(About));
            
           
        }

        private void toggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {

            if (toggleSwitch.IsOn)
            {
                //如果为true，那么说明刚从隐藏转换过来
                showStatus();
                //改写键值
                rootContainer.Values[SETTING_IS_DISPLAY_STATUS] = true;
            }
            else
            {
                hideStatus();
                rootContainer.Values[SETTING_IS_DISPLAY_STATUS] = false;
            }
        }

        /// <summary>
        /// 显示状态栏
        /// </summary>
        public async void showStatus()
        {
            //显示状态栏
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent(typeof(StatusBar).ToString()))
            {
                StatusBar statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 36, 41, 55);
                statusBar.ForegroundColor = Colors.White;
                statusBar.BackgroundOpacity = 1;
                await statusBar.ShowAsync();
            }
        }

        /// <summary>
        /// 隐藏状态栏
        /// </summary>
        public async void hideStatus()
        {
            //隐藏状态栏
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent(typeof(StatusBar).ToString()))
            {
                StatusBar statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 36, 41, 55);
                statusBar.ForegroundColor = Colors.White;
                statusBar.BackgroundOpacity = 1;
                await statusBar.HideAsync();
            }
        }

        private void btn_custom_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(CustomPage));
        }
    }
}
