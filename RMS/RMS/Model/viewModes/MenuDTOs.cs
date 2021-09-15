using RMS.Model.viewModes.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class MenuDTOs
    {
        public MenuDTOs()
        {
            DishSubCategories = new List<BaseGuidSelect>();
        }
        public Guid MenuID { get; set; }
        [StringLength(50, ErrorMessage = "Menu Name Length should be between 3 to 50", MinimumLength = 3)]
        [Required(ErrorMessage = "Menu Name is required")]
        public string MenuName { get; set; }
        [Required(ErrorMessage = "Menu Price is required")]

        public decimal MenuPrice { get; set; }

        public string ImagePath { get; set; }

        public Guid SubCategoryID { get; set; }

        public List<BaseGuidSelect> DishSubCategories { get; set; }

        public string DishSubCategory { get; set; }
    }
}