using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class UserTypeDTOs
    {
        public Guid UserTypeID { get; set; }
        [Required(ErrorMessage = "User Type is required")]

        [StringLength(95, ErrorMessage = "User Type Length should be between 3 to 95", MinimumLength = 3)]
        public string Type { get; set; }

    }
}