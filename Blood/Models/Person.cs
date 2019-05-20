using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blood.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Pesel { get; set; }
        public BloodGroup BloodGroup { get; set; }

        public BloodType BloodType { get; set; }
        public virtual ICollection<EventBlood> EventBloods { get; set; }


        public Person()
        {
            this.EventBloods= new HashSet<EventBlood>();
        }

    }
}
