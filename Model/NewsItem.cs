using System;
using static System.Guid;

namespace TestAPI
{
    public class NewsItem
    {
        
        public Guid NewsId {get;set;}
        public string NewsDate {get; set;} = "";
        public string NewsTitle {get;set;} = "";
        public string NewsLink {get;set;} = "";

    }
}