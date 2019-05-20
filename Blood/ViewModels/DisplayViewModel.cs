using Blood.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blood.ViewModel
{
    public class DisplayViewModel
    {


        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Pesel { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public BloodType BloodType { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        
        public IEnumerable<EventBlood> EventBloods { get; set; }
        [Display(Name = "Suma Donacji")]
        public float Sum { get; set; }




    }
}
