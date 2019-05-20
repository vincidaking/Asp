using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zajecia3.Models;

namespace Zajecia3.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            WebClient wc = new WebClient();

            var url = "https://api.unsplash.com/photos/?page=1&client_id=3dd7fa37ed3bb1bd0cb7ac54a5f2941d2b18152277e74f4a5c1d7c3deacb4496";
            var json = wc.DownloadString(url);

            var apiResponse = JsonConvert.DeserializeObject<List<ApiResponse>>(json);

            var images = apiResponse.Select(n => new ImageModel
            {
                ThumUrl = n.ImageUrls.Thumb,
                RegularUrl = n.ImageUrls.Regular

            }).Take(3).ToList();
            return View(images);
        }
    }
}