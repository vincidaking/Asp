using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blood.Models
{
    public class EventBlood
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }       
        public virtual Person Person { get; set; }

        public int DonatedBlood { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        //public EventBlood()
        //{
        //    this.Person = new HashSet<Person>();
        //}


    }
}
