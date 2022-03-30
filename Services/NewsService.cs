using System;
using TestAPI.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Guid;
using System.Linq;
using TestAPI.Collectors;

namespace TestAPI.Services{

    public class NewsService{

        NewsCollector collector = new NewsCollector();

        public List<NewsItem> getAllArticles(){

            return collector.GetListOfNews();
        }

        public NewsItem getArticle(Guid newsId){
            
            return collector.GetNewsItem(newsId);
        }

    }
}