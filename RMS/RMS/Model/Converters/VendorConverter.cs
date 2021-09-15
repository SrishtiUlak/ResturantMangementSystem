using DatabaseLayer;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Converters
{
    public class VendorConverter
    {
        public Vendor ConvertToEntity(VendorDTOs model, Vendor vendor)
        {
            vendor.VendorName = model.VendorName;
            return vendor;
        }

        public VendorDTOs ConvertToModel(Vendor model)
        {
            VendorDTOs vendor = new VendorDTOs();
            vendor.VendorID = model.VendorID;
            vendor.VendorName = model.VendorName;
            return vendor;
        }
    }
}