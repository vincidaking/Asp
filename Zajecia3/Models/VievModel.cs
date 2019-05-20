using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zajecia3.Models
{
    public class VievModel
    {
        public IEnumerable<RSSItem> RSSItem { get; set; }
        public IEnumerable<ImageModel> ImageModel { get; set; }
    }
}