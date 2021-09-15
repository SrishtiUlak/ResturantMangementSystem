using DatabaseLayer;
using RMS.Model.Converters;
using RMS.Model.viewModes;
using RMS.Model.viewModes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Services
{
    public class InvoiceService
    {
        private readonly InvoiceConverter converter = new InvoiceConverter();
      

        public bool Create(InvoiceDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    DatabaseLayer.Invoice invoice = new DatabaseLayer.Invoice();
                    invoice.InvoiceID = Guid.NewGuid();
                    invoice = converter.ConverToEntity(model, invoice);

                    db.Invoices.Add(invoice);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public bool Update(InvoiceDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    DatabaseLayer.Invoice invoice = db.Invoices.FirstOrDefault(cd => cd.InvoiceID == model.InvoiceID);
                    if (invoice != null)
                    {
                        invoice = converter.ConverToEntity(model, invoice);
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

        public InvoiceDTOs GetById(Guid invoiceId)
        {
            InvoiceDTOs model = new InvoiceDTOs();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    DatabaseLayer.Invoice invoice = db.Invoices.FirstOrDefault(cd => cd.InvoiceID == invoiceId);
                    if (invoice != null)
                    {
                        model = converter.ConvertToModel(invoice);
                    }
                    return model;
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public List<InvoiceDTOs> GetAll()
        {
            List<InvoiceDTOs> invoices = new List<InvoiceDTOs>();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    var dbInvoice = db.Invoices.ToList();
                    foreach (var invoice in dbInvoice)
                    {

                        invoices.Add(converter.ConvertToModel(invoice));
                    }
                    return invoices;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public bool Delete(Guid invoiceId)
        {

            using (var db = new ResturantManagementDBEntities())
            {

                var invoice = db.Invoices.FirstOrDefault(cd => cd.InvoiceID == invoiceId);
                if (invoice != null)
                {
                    db.Invoices.Remove(invoice);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

    }
}