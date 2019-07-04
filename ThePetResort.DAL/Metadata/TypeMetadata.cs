using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePetResort.DAL
{
    [MetadataType(typeof(TypeMetadata))]
    public partial class Type { }

    class TypeMetadata
    {

        public int TypeID { get; set; }

        [Display(Name = "Breed")]
        public string Name { get; set; }

        [Display(Name = "Is Exotic")]
        public bool IsExotic { get; set; }
    }
}
