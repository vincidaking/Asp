using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Zajecia3v2.Models;

namespace Zajecia3v2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var url1 = "https://news.google.com/rss?hl=pl&gl=PL&ceid=PL:pl";
            var url2 = "http://www.benchmark.pl/rss/aktualnosci-pliki.xml";
            var url3 = "https://www.gry-online.pl/rss/news.xml";




            //XElement rss1 = XElement.Load(url1);
            XElement rss1 = XElement.Load(url1);
            XElement rss2 = XElement.Load(url2);
            XElement rss3 = XElement.Load(url3);





            var query1 = rss1.Descendants("item").Select(item =>
            new RSSItem
            {
                Title = item.Element("title").Value,
                PubDate = item.Element("pubDate").Value,
                Description = item.Element("description").Value,
                //Link = item.Element("link").Value
            }).ToList();

            var query2 = rss2.Descendants("item").Select(item =>
            new RSSItem
            {
                Title = item.Element("title").Value,
                PubDate = item.Element("pubDate").Value,
                //Description = item.Element("description").Value
                Link = item.Element("link").Value
            }).ToList();

            var query3 = rss3.Descendants("item").Select(item =>
            new RSSItem
            {
                Title = item.Element("title").Value,
                PubDate = item.Element("pubDate").Value,
                Description = item.Element("description").Value
                //Link = item.Element("link").Value
            }).ToList();



            var items = new List<RSSItem>();
            var random = new Random();

            for (int i = 0; i < 4; i++)
            {
                items.Add(query1.ElementAt(random.Next(query1.Count)));
                items.Add(query2.ElementAt(random.Next(query2.Count)));
                items.Add(query3.ElementAt(random.Next(query3.Count)));

            }

            return View(items);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}