using DatabaseLayer;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Converters
{
    public class CustomerConverter
    {
        public DatabaseLayer.Customer ConverToEntity(CustomerDTOs model, DatabaseLayer.Customer customer)
        {
            customer.CustomerName = model.CustomerName;
            customer.Address = model.Address;
            customer.Contact = model.Contact;
            return customer;
        }
        public CustomerDTOs ConvertToModel(DatabaseLayer.Customer model)
        {
            CustomerDTOs customer = new CustomerDTOs();
            customer.CustomerID = model.CustomerID;
            customer.CustomerName = model.CustomerName;
            customer.Address = model.Address;
            customer.Contact = model.Contact;
            return customer;
        }

    }
}