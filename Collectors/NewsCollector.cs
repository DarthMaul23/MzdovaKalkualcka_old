using static System.Guid;
using HtmlAgilityPack;

namespace TestAPI.Collectors
{
    public class NewsCollector
    {
        
        static List<NewsItem> newsList = new List<NewsItem>();
        private HtmlWeb web = new HtmlWeb();

        private string url = "https://edition.cnn.com";

        public NewsCollector(){
            CollectNews();
        }

        public List<NewsItem> GetListOfNews(){

            return newsList;
        }

        public NewsItem GetNewsItem(Guid id){

            return newsList.Where(n => n.NewsId == id).FirstOrDefault();
        }

        private void CollectNews(){

            HtmlDocument html = web.Load(url + "/BUSINESS");

            HtmlNode newsNode = html.DocumentNode.SelectSingleNode("//div[@class='column zn__column--idx-0']/ul");
            HtmlNodeCollection news = newsNode.SelectNodes(".//li");

            foreach (HtmlNode item in news){

                string link = getNode(item).Attributes["href"].Value;
                string articleName = getNode(item).SelectNodes("//span[@class='cd__headline-text vid-left-enabled']")[news.IndexOf(item)].InnerText.Trim();

                AddNewItem(Guid.NewGuid(), GetDate(link), articleName, url + link);

            }

        }

        private HtmlNode getNode(HtmlNode item){

            return item.SelectSingleNode(".//a");
        }

        private string GetDate(string link){

            return (link.Substring(1,6) != "videos") ? link.Substring(1, 10) : link.Substring(17, 10);
        }

        private void AddNewItem(Guid id, string date, string name, string link){

            newsList.Add(new NewsItem(){ NewsId = id, NewsDate = date, NewsTitle = name, NewsLink = link});

        }

    }
}