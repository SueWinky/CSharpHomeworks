using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace program1
{

    public class Crawler
    {
        //private Hashtable urls = new Hashtable();
        private Queue<String> urls = new Queue<string>();
        private int count = 0;
        private string html;
        /// <summary>
        /// 
        ///
        /// </summary>
        /// <param name="url">网页爬取的起点</param>
        public Crawler(string url)
        {
            html = "";
            if (url.Length > 0)
            {
                urls.Enqueue(url);
            }
        }

        public void Crawl()
        {
            Console.WriteLine("开始爬行了……");
            while (true)
            {
                if(urls.Count==0)
                {
                    continue;
                }
                string current = urls.Peek();
                if (current == null || count > 100)
                {
                    break;
                }
                Console.WriteLine("爬行" + current + "页面");
                DownLoad(current);
                //Parse();
                Thread thread = new Thread(Parse);
                thread.Start();
            }
            Console.WriteLine("爬行结束");
        }

        private void Parse()
        {
            lock(html)
            {
                //Console.WriteLine("开始解析");
                string strRef = @"(href|HREF)[ ]*=[ ]*[""'][^""'#(img)]+[""']";
                MatchCollection matches = new Regex(strRef).Matches(html);
                foreach (Match match in matches)
                {
                    strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\\', '#', ' ', '>');
                    if (strRef.Length == 0)
                    {
                        continue;
                    }
                    urls.Enqueue(strRef);
                }
            }
        }

        public void DownLoad(String url)
        {
                try
                {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string content = webClient.DownloadString(url);
                string fileName = count.ToString();
                urls.Dequeue();
                count++;
                File.WriteAllText(fileName + ".html", content, Encoding.UTF8);
                lock(html)
                {
                    html = content;
                }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    urls.Dequeue();
                }
            
        }
    }
}
