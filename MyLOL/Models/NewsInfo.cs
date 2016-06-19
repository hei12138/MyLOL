using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLOL.Models
{
    public class NewsInfo
    {
        public NewsInfo()
        {
            //previous = "测试1";
            //next = "测试2";
            //list = new List<NewsList>() { new NewsList { title = "测试title", channel_id = "测试", summary = "测试简介", publication_date = "2016-06-04 10:22:44" }, new NewsList { title = "测试title2", channel_id = "测试2", summary = "测试简介2", publication_date = "2016-06-04 10:22:44" } };
        }

        public string previous { get; set; }
        public string next { get; set; }
        public int this_page_num { get; set; }
        public ObservableCollection<NewsList> list { get; set; }
    }
    public class NewsList
    {
        public string channel_id { get; set; }
        public string channel_desc { get; set; }
        public int article_id { get; set; }
        public string insert_date { get; set; }
        public string publication_date { get; set; }
        public string is_direct { get; set; }
        public string is_top { get; set; }
        public string article_url { get; set; }
        public string title { get; set; }
        public string image_url_small { get; set; }
        public string image_url_big { get; set; }
        public int image_spec { get; set; }
        public string image_with_btn { get; set; }
        public int score { get; set; }
        public string summary { get; set; }
        public string targetid { get; set; }
        public int is_act { get; set; }
        public int is_hot { get; set; }
        public int is_subject { get; set; }
        public string is_report { get; set; }
        public int is_new { get; set; }
    }
}
