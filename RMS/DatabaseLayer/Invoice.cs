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
    
    public partial class Invoice
    {
        public System.Guid InvoiceID { get; set; }
        public Nullable<bool> Status { get; set; }
        public int OrderCartID { get; set; }
    
        public virtual OrderCart OrderCart { get; set; }
    }
}
