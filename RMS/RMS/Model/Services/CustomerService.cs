using DatabaseLayer;
using RMS.Model.Converters;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Services
{
    public class CustomerService
    {
        private readonly CustomerConverter converter = new CustomerConverter();
        

       
        public bool Create(CustomerDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    DatabaseLayer.Customer customer = new DatabaseLayer.Customer();
                    customer.CustomerID = Guid.NewGuid();
                    customer = converter.ConverToEntity(model, customer);
                  
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public bool Update(CustomerDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    DatabaseLayer.Customer customer = db.Customers.FirstOrDefault(c => c.CustomerID == model.CustomerID);
                    if (customer != null)
                    {
                        customer = converter.ConverToEntity(model, customer);                      
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

        public CustomerDTOs GetById(Guid  customerId)
        {
            CustomerDTOs model = new CustomerDTOs();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    DatabaseLayer.Customer customer = db.Customers.FirstOrDefault(c => c.CustomerID == customerId);
                    if (customer != null)
                    {
                        model = converter.ConvertToModel(customer);
                       
                    }
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<CustomerDTOs> GetAll ()
        {
            List<CustomerDTOs> customers = new List<CustomerDTOs>();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    var dbCustomers = db.Customers.ToList();
                    foreach (var customer in dbCustomers)
                    {
                        customers.Add(converter.ConvertToModel(customer));

                    }
                    return customers;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public bool Delete(Guid customerId)
        {
            using (var db = new ResturantManagementDBEntities())
            {
                var customer = db.Customers.FirstOrDefault(x => x.CustomerID == customerId);
                if(customer != null)
                {
                    db.Customers.Remove(customer);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }


       
    }
}