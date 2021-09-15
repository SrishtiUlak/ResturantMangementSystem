using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class VendorDTOs
    {
        public Guid VendorID { get; set; }
        [Required(ErrorMessage = "Vendor Name is required")]
        [StringLength(95, ErrorMessage = "Vendor Name Should be between 3 to 9", MinimumLength = 3)]
        public string VendorName { get; set; }
    }
}