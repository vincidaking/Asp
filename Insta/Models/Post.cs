using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Insta.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<string> PhotoPath { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public Post()
        {
            Tags = new HashSet<Tag>();
        }
    }
}
