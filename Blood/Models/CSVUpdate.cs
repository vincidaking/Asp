using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blood.Models
{
    public class CSVUpdate
    {
        public IFormFile CSVUrl { get; set; }
    }
}
