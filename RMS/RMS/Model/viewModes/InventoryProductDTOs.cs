using RMS.Model.viewModes.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class InventoryProductDTOs
    {
        public InventoryProductDTOs()
        {
            Categories = new List<BaseGuidSelect>();
            ProductQuantities = new List<BaseGuidSelect>();
        }
        public Guid InventoryProductID { get; set; }
        [StringLength(95, ErrorMessage = "Products Name Should be between 3 to 9", MinimumLength = 3)]
        [Required(ErrorMessage = "Products Name is required")]
        public string ProductsName { get; set; }
        public DateTime ManufactureDate{ get; set; }
        public DateTime ExpDate { get; set; }
        public string Description { get; set; }
        public Guid CategoryID { get; set; }
        public Guid ProductQuantityID { get; set; }

        public List<BaseGuidSelect> Categories { get; set; }
        public string Category { get; set; }
        public List<BaseGuidSelect> ProductQuantities { get; set; }
        public int Quantity { get; set; }
    }
}