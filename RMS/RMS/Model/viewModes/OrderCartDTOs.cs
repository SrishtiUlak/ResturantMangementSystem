using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class OrderCartDTOs
    {
        public Guid MenuID { get; set; }

        public string MenuName { get; set; }

        public string MenuPrice { get; set; }

        public string Description { get; set; }

        public DateTime OrderTime { get; set; }
        public DateTime OrderDate { get; set; }

        public string SubCategory { get; set; }
        public string ImagePath { get; set; }


    }
}