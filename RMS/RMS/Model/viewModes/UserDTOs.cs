using RMS.Model.viewModes.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class UserDTOs
    {
        public UserDTOs()
        {
            UserTypes = new List<BaseGuidSelect>();
        }
        public Guid UserId { get; set; }
        [StringLength(50, ErrorMessage = "First Name Length should be between 3 to 50", MinimumLength = 3)]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [StringLength(50, ErrorMessage = "Last Name Length should be between 3 to 50", MinimumLength = 3)]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [MinLength(10, ErrorMessage = "Number should be of 10 digits")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        [StringLength(50, ErrorMessage = "User Length should be between 3 to 50", MinimumLength = 3)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(50, ErrorMessage = "Address Length should be between 3 to 50", MinimumLength = 3)]
        public string Address { get; set; }
        public Guid UserTypeID { get; set; }

        public List<BaseGuidSelect> UserTypes { get; set; }

        public string UserType { get; set; }

    }
}