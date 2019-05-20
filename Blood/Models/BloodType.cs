using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blood.Models
{


    public enum BloodType
    {
        [Display(Name = "Rh-")]
        Rh_Minus,
        [Display(Name = "Rh+")]
        Rh_Plus
    }


    public enum BloodGroup
    {
        [Display(Name = "0")]

        O,
        A,
        B,
        AB

    }

}
