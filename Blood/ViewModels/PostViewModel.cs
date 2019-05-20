using Blood.Models;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blood.ViewModel
{
    public class PostViewModel
    {
        [Required]
        [Index(2)]
        public string Pesel { get; set; }

        [Index(0)]
        [Required]
        public string FirstName { get; set; }

        [Index(1)]
        [Required]
        public string LastName { get; set; }

        [Index(4)]
        [Required]
        public BloodGroup BloodGroup { get; set; }

        [Index(3)]
        [Required]
        public BloodType BloodType { get; set; }

        [Index(5)]
        [Required]
        [DataType(DataType.Date)]

        public DateTime Date { get; set; }

        [Index(6)]
        [Required]
        public int DonatedBlood { get; set; }

    }
}
