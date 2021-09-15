using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class CustomerDTOs
    {
        public Guid CustomerID { get; set; }

        [StringLength(50,ErrorMessage ="Name should be between 3 - 50", MinimumLength = 3)]
        [Required(ErrorMessage = "Customer Name is required")]
        public string CustomerName { get; set; }

        [StringLength(50,ErrorMessage ="Address should be between 3 - 50" , MinimumLength = 3)]
        [Required(ErrorMessage ="Address is required")]
        public string Address { get; set; }

       /* [MinLength(10,ErrorMessage = "Number should be of 10 digits")]*/
        [Required(ErrorMessage ="Contact no is required")]
        public string Contact { get; set; }
    }
}