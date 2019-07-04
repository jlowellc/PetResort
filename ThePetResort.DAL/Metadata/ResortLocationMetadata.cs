using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePetResort.DAL
{
    [MetadataType(typeof(ResortLocationMetadata))]
    public partial class ResortLocation
    {
    }

    class ResortLocationMetadata
    {
        [Display(Name = "Resort Location")]
        public int ResortLocationID { get; set; }

        [Display(Name = "Resort Name")]
        public string ResortName { get; set; }


        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        public string Phone { get; set; }
    }
}
