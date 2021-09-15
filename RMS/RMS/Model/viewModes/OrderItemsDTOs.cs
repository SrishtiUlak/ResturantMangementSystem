using RMS.Model.viewModes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class OrderItemsDTOs
    {
        public Guid OrderID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string Total { get; set; }
        public Guid? VendorID { get; set; }
        public TimeSpan? OrderTime { get; set; }
        public string OrderName { get; set; }

        public List<BaseGuidSelect> Vendors { get; set; }

        public string Vendor { get; set; }
    }
}