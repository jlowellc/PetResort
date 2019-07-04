using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ThePetResort.DAL;

namespace ThePetResort.UI.Models
{
    public class ReservationModel
    {
        [Display(Name = "Reservation ID")]
        public int ReservationID { get; set; }

        [Display(Name = "Loaction")]
        public int ResortLocationID { get; set; }

        [Display(Name = "Pet Name")]
        public int PetID { get; set; }

        [Display(Name = "Reservation Date")]
        [DataType(DataType.Date)]
        public System.DateTime ReservationDate { get; set; }

        public virtual Pet Pet { get; set; }
        public virtual ResortLocation ResortLocation { get; set; }
    }
}