using DatabaseLayer;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Converters
{
    public class InvoiceConverter
    {
        public DatabaseLayer.Invoice ConverToEntity(InvoiceDTOs model, Invoice invoice)
        {          
            invoice.Status = model.Status;         
            return invoice;
        }

        public InvoiceDTOs ConvertToModel(DatabaseLayer.Invoice model)
        {
            InvoiceDTOs invoice = new InvoiceDTOs();
            invoice.InvoiceID = model.InvoiceID;            
            invoice.Status = model.Status;
            invoice.OrderCartID = model.OrderCartID;          
            return invoice;
        }
    }
}