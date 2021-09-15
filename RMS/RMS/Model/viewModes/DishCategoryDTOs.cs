using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class DishCategoryDTOs
    {
        public Guid DishCategoryID { get; set; }
        [Required(ErrorMessage = "Dish Category Name is required")]
        [StringLength(95, ErrorMessage = "Dish Category  Length should be between 3 to 95", MinimumLength = 3)]
        public string DishCategoryName { get; set; }
    }
}