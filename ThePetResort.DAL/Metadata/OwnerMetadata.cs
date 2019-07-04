using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThePetResort.DAL
{
    [MetadataType(typeof(OwnerMetadata))]
    public partial class Owner
    {
    }

    public class OwnerMetadata
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int OwnerID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "* Required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "* Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Phone { get; set; }

        [Display(Name = "Sign Up Date")]
        [Required(ErrorMessage = "* Required")]
        [DataType(DataType.Date)]
        public System.DateTime DateCreated { get; set; }

    }
}
