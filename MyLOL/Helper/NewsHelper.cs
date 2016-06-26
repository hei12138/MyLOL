using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using MyLOL.Controls;
using System.Threading;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace MyLOL.Helper
{
    public class NewsHelper
    {
        public static CustomToast toast = new CustomToast() { Message = "网络连接失败" };

        public static async Task<string> GetNews(string page,string list)
        {
            //获取数据
            HttpClient client = new HttpClient();


            //client.Encoding = System.Text.Encoding.UTF8;
            //获取战队数据
            //var json = await client.GetStringAsync(new Uri("http://qt.qq.com/php_cgi/lol_mobile/club/varcache_team_entrancev2.php?plat=android&version=9676"));

            //http://apps.game.qq.com/lol/act/website2013/videoApp.php?page=1&p1=0&p2=0&p3=0&p4=0&p5=0 精彩视频
            //http://apps.game.qq.com/lol/act/website2013/videoApp.php?page=2&p1=0&p2=0&p3=0&p4=0&p5=0 
            //http://apps.game.qq.com/lol/act/website2013/videoApp.php?page=1&p1=0&p2=0&p3=0&p4=9999&p5=0 解说
            //http://apps.game.qq.com/lol/act/website2013/videoApp.php?page=1&p1=0&p2=9999&p3=0&p4=0&p5=0 职业联赛
            //http://apps.game.qq.com/lol/act/website2013/videoApp.php?page=1&p1=2&p2=0&p3=0&p4=0&p5=0  娱乐


            //http://ossweb-img.qq.com/upload/qqtalk/lol_hero/hero_22.js 返回英雄数据 格式为json
            //http://ossweb-img.qq.com/upload/qqtalk/lol_hero/goods_list.js  返回物品列表 格式为json


            //list_2 3 4代表页面 c12代表常规页面 c13代表推荐页面 c73赛事 c18娱乐 c3官方 c17美女 c10攻略 c23活动
            //拼接字符串
            var apiUrl = string.Format("http://qt.qq.com/static/pages/news/phone/{0}_list_{1}.shtml",page,list);
            try
            {
                var json2 = await client.GetBufferAsync(new Uri(apiUrl));
                //将ibuffer转变为byte[];
                byte[] bytes = WindowsRuntimeBufferExtensions.ToArray(json2, 0, (int)json2.Length);
                //设置请求头
                //从byte[]转为字符串;
                string str = System.Text.Encoding.UTF8.GetString(bytes);

                //返回的str带有/r换行符，无法识别
                var str2 = cleanString(str);
                str2 = str2.Replace(" ", "");
                return str2;
            }
            catch (Exception e)
            {
                toast.Show();
                return null;
            }
           
           
        }



        //替换字符串中的/n/r
        public static string cleanString(string newStr)
        {
            string tempStr = newStr.Replace((char)13, ' ');
            return tempStr.Replace((char)10, ' ');
        }


    }
}
