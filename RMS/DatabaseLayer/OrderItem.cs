//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderItem
    {
        public System.Guid ItemID { get; set; }
        public Nullable<System.Guid> OrderID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public System.Guid InventoryProductID { get; set; }
    
        public virtual InventoryProduct InventoryProduct { get; set; }
        public virtual Order Order { get; set; }
    }
}
