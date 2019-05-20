using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Models
{

    public enum ConferenceType
    {
        [Display(Name = "Wykład")]
        Lecture,
        [Display(Name = "Warsztaty")]
        WorkShop,
        [Display(Name = "Dyskusja")]
        Discussion

    }

    public class ConferenceUsers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Imie")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }      
        public string Email { get; set; }   
        [Display(Name = "Rodzaj zajec")]
        public ConferenceType? ConferenceType { get; set; }
        public string Avatar { get; set; }


    }
}
