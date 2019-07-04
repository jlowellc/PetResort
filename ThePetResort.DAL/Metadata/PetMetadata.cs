using System.ComponentModel.DataAnnotations;

namespace ThePetResort.DAL
{
    [MetadataType(typeof(PetMetadata))]
    public partial class Pet
    {
    }

    public class PetMetadata
    {

        [Display(Name = "Pet Name")]
        [Required(ErrorMessage = "* Required")]
        public string Name { get; set; }

        [Display(Name = "Breed")]
        [Required(ErrorMessage = "* Required")]
        public int TypeID { get; set; }

        [Display(Name = "Photo")]
        public string PetPhoto { get; set; }

        [Display(Name = "Special Notes")]
        public string SpecialNotes { get; set; }

        [Display(Name = "VIP")]
        public bool IsVIP { get; set; }

        [Display(Name = "Today's Date")]
        [Required(ErrorMessage = "* Required")]
        [DataType(DataType.Date)]
        public System.DateTime DateAdded { get; set; }
    }
}
