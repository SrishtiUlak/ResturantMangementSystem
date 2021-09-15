using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class CategoryDTOs
    {
        public Guid CategoryID { get; set; }
        [Required(ErrorMessage = "Category Name is required")]
        [StringLength(95, ErrorMessage = "Category Name Should be between 3 to 9", MinimumLength = 3)]
        public string CategoryName { get; set; }

    }
}