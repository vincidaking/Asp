using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insta.ViewModels
{
    public class DisplayPostViewModel
    {
        public string Title { get; set; }
        public List<string> PhotoPath { get; set; }
        public List<string> Tags { get; set; }

    }
}
