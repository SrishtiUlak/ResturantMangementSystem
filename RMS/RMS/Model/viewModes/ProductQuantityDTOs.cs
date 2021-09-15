using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class ProductQuantityDTOs
    {
        public Guid ProductQuantityID { get; set; }
        public int Quantity { get; set; }
        public Guid InventoryProductID { get; set; }


    }
}