using RMS.Model.viewModes.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class DishSubCategoryDTOs
    {
        public DishSubCategoryDTOs()
        {
            DishCategorys = new List<BaseGuidSelect>();
        }
        public Guid SubCategoryId { get; set; }

        [Required (ErrorMessage="Sub Category name is required")]
        [StringLength(95, ErrorMessage = "Dish Category  Length should be between 3 to 95", MinimumLength = 3)]
        public string SubCategoryName { get; set; }

        public Guid DishCategoryId { get; set; }

        public List<BaseGuidSelect> DishCategorys { get; set; }

        public string DishCategory { get; set; }

     


    }
}