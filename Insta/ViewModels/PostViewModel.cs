using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insta.ViewModels
{
    public class PostViewModel
    {

        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string CommaSeperatedTags { get; set; }
        [Required]
        public List<IFormFile> PostedPhoto { get; set; }

        
    }
}
