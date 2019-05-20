using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Zajecia3.Models;

namespace Zajecia3.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {

            var myModel = new VievModel();

            //Galeria 
            WebClient wc = new WebClient();

            var url = "https://api.unsplash.com/photos/?page=1&client_id=3dd7fa37ed3bb1bd0cb7ac54a5f2941d2b18152277e74f4a5c1d7c3deacb4496";
            var json = wc.DownloadString(url);

            var apiResponse = JsonConvert.DeserializeObject<List<ApiResponse>>(json);

            var images = apiResponse.Select(n => new ImageModel
            {
                ThumUrl = n.ImageUrls.Thumb,
                RegularUrl = n.ImageUrls.Regular

            }).Take(3).ToList();

            myModel.ImageModel = images;

            //Newsy 
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

            myModel.RSSItem = items;
            return View(myModel);
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