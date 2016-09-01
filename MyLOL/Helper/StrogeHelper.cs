using MyLOL.Controls;
using MyLOL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MyLOL.Helper
{
    public class StrogeHelper
    {
        private static CustomToast toast = new CustomToast() { Message = "保存成功" };


        //个人数据和战绩数据分割
        /// <summary>
        /// 保存个人数据
        /// </summary>
        /// <param name="userinfo">传入的用户信息</param>
        public static async void SavePeosonFile(UserInfo userinfo)
        {
            //获取到文件夹
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            //获取到文件
            var file = await folder.CreateFileAsync("UserInfo.json", CreationCollisionOption.ReplaceExisting);
            //将用户信息序列化
            var str = JsonConvert.SerializeObject(userinfo);
            using (var stream = await file.OpenStreamForWriteAsync())
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(str);
                }
            }
            toast.Show();
        }

        /// <summary>
        /// 获取个人数据
        /// </summary>
        public static async Task<UserInfo> GetPersonFile()
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;

            var file = await folder.CreateFileAsync("UserInfo.json", CreationCollisionOption.OpenIfExists);
            
            using (var stream = await file.OpenStreamForReadAsync())
            {
                using (var reader = new StreamReader(stream))
                {
                    var str = await reader.ReadToEndAsync();
                    if (!String.IsNullOrEmpty(str))
                    {
                        return JsonConvert.DeserializeObject<UserInfo>(str);
                    }
                    else
                    {
                        return null;
                    }
                }
            }


        }

        /// <summary>
        /// 保存战绩数据
        /// </summary>
        public static void SaveMatchFile()
        {

        }

        public static void GetMatchFile()
        {

        }
    }
}
