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
using MyLOL.Helper;
using MyLOL.Models;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace MyLOL.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class CustomPage : PageBase
    {
        private static CustomToast toast = new CustomToast();
        int total, win, fail;
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
            Combo_Rank_Big.Items.Add("无段位");
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
            if (Combo_Rank_Big.SelectedIndex == 1 || Combo_Rank_Big.SelectedIndex == 0)
            {
                //不可选择小段位
                Combo_Rank_small.IsEnabled = false;
            }
        }

        //提交
        private void btn_commit_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(tbx_UserName.Text))
            {
                toast.Message = "用户信息未填写";
                toast.Show();
                return;
            }
            if (string.IsNullOrWhiteSpace(tbx_GameID.Text))
            {
                toast.Message = "游戏ID未填写";
                toast.Show();
                return;
            }
            if (string.IsNullOrWhiteSpace(tbx_total.Text))
            {
                if (!int.TryParse(tbx_total.Text, out total))
                {
                    toast.Message = "总场数未填写正确";
                    toast.Show();
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(tbx_win.Text))
            {
                if (!int.TryParse(tbx_win.Text, out win))
                {
                    toast.Message = "胜场数未填写正确";
                    toast.Show();
                    return;
                }
            }
            UserInfo userinfo = new UserInfo();
            userinfo.Level = 30;
            userinfo.UserName = tbx_UserName.Text;
            userinfo.GameID = tbx_GameID.Text;
            userinfo.TotalGame = int.Parse(tbx_total.Text);
            userinfo.WinGame = int.Parse(tbx_win.Text);
            userinfo.FailGame = userinfo.TotalGame - userinfo.WinGame;
            userinfo.GameStatus = ts_GameStatus.IsOn;


            userinfo.RankBig = RankBigState.Challenger;
            userinfo.RankSmall = RankSmallState.Ⅰ;
            userinfo.WinPro = 0.5;
            StrogeHelper.SavePeosonFile(userinfo);

        }

        private void tbx_win_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool isRight = false;
            //当输入胜场次变化时改变败场次
            //判断是否输入正确
            if (string.IsNullOrWhiteSpace(tbx_total.Text))
            {
                if (!int.TryParse(tbx_total.Text, out total))
                {
                   
                }
            }
            if (string.IsNullOrWhiteSpace(tbx_win.Text))
            {
                if (!int.TryParse(tbx_win.Text, out win))
                {
                    
                }
            }
        }
    }
}
