using MyLOL.Controls;
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

namespace MyLOL.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class CustomPage : PageBase
    {
        public CustomPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //设置combobox的内容
            Combo_Rank_Big.Items.Add("最强王者");
            Combo_Rank_Big.Items.Add("超凡大师");
            Combo_Rank_Big.Items.Add("璀璨钻石");
            Combo_Rank_Big.Items.Add("华贵铂金");
            Combo_Rank_Big.Items.Add("荣耀黄金");
            Combo_Rank_Big.Items.Add("不屈白银");
            Combo_Rank_Big.Items.Add("英勇黄铜");
            Combo_Rank_small.Items.Add("Ⅰ");
            Combo_Rank_small.Items.Add("Ⅱ");
            Combo_Rank_small.Items.Add("Ⅲ");
            Combo_Rank_small.Items.Add("Ⅳ");
            Combo_Rank_small.Items.Add("Ⅴ");
        }


        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Content = null;
        }

        private void Combo_Rank_Big_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Combo_Rank_small.IsEnabled = true;
            //超凡大师 最强王者没有段位
            if (Combo_Rank_Big.SelectedIndex == 1||Combo_Rank_Big.SelectedIndex==0)
            {
                //不可选择小段位
                Combo_Rank_small.IsEnabled = false;
            }
        }
    }
}
