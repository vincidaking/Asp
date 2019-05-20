using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zajecia3.Models
{
    
        public class ApiResponse
        {
            [JsonProperty(propertyName: "Urls")]
            public Urls ImageUrls { get; set; }

            public class Urls
            {
                public string Regular { get; set; }
                public string Thumb { get; set; }
            }
        }
    
}