using DatabaseLayer;
using RMS.Model.Converters;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Services
{
    public class VendorService
    {
        private readonly VendorConverter converter = new VendorConverter();
        public bool Create(VendorDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    Vendor vendor = new Vendor();
                    vendor.VendorID = Guid.NewGuid();
                    vendor = converter.ConvertToEntity(model, vendor);

                    db.Vendors.Add(vendor);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public bool VendorNameValidation(string vendorname)
        {
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                return db.Vendors.Any(v => v.VendorName.Equals(vendorname));
            }
        }

        public bool Update(VendorDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    Vendor vendor = db.Vendors.FirstOrDefault(v => v.VendorID == model.VendorID);
                    if (vendor != null)
                    {
                        vendor = converter.ConvertToEntity(model, vendor);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public VendorDTOs GetById(Guid vendorId)
        {
            VendorDTOs model = new VendorDTOs();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    Vendor vendor = db.Vendors.FirstOrDefault(c => c.VendorID == vendorId);
                    if (vendor != null)
                    {
                        model = converter.ConvertToModel(vendor);

                    }
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<VendorDTOs> GetAll()
        {
            List<VendorDTOs> vendors = new List<VendorDTOs>();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    var dbVendors = db.Vendors.ToList();
                    foreach (var vendor in dbVendors)
                    {
                        vendors.Add(converter.ConvertToModel(vendor));

                    }
                    return vendors;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}