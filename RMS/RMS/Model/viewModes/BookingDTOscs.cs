using RMS.Model.viewModes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class BookingDTOs
    {
        public Guid BookingID { get; set; }
        public DateTime Date { get; set; }
        public string TableNumber { get; set; }
        public string Description { get; set; }
        public Guid CustomerID { get; set; }

        public List<BaseGuidSelect> Customers { get; set; }

        public string Customer { get; set; }

        public Guid TableID { get; set; }

        public List<BaseGuidSelect> Tables { get; set; }

        public string Table { get; set; }

    }


}