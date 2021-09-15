using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class OrderModel
    {
        public Guid OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderNumber { get; set; }
    }
}