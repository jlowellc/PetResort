using System.ComponentModel.DataAnnotations;

namespace ThePetResort.DAL
{
    [MetadataType(typeof(ReservationMetadata))]
    public partial class Reservation { }

    public class ReservationMetadata
    {

        [Display(Name = "Reservation Date")]
        [Required(ErrorMessage = "* Required")]
        [DataType(DataType.Date)]
        public System.DateTime ReservationDate { get; set; }
    }
}
