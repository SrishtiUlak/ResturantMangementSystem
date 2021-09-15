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
    public class BookingService
    {
        private readonly BookingConverter bookingconverter = new BookingConverter();

        public BookingDTOs CreateSelectList(BookingDTOs model)
        {
            model.Customers = GetCustomerTypes();
            return model;
        }


        public List<BaseGuidSelect> GetCustomerTypes()
        {
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                return db.Customers.Select(u =>
                new BaseGuidSelect
                {
                    Id = u.CustomerID,
                    Name = u.CustomerName
                }).ToList();

              

            }
        }

        public BookingDTOs CreateSelectListTable(BookingDTOs model)
        {
            model.Tables = GetTableTypes();
            return model;
        }


        public List<BaseGuidSelect> GetTableTypes()
        {
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
               
                return db.Tables.Select(u =>
                new BaseGuidSelect
                {
                    Id = u.TableID,
                    Name = u.TableName
                }).ToList();

            }
        }

        public bool Create(BookingDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    DatabaseLayer.Booking booking = new DatabaseLayer.Booking();
                    booking.BookingID = Guid.NewGuid();
                    booking = bookingconverter.ConverToEntity(model, booking);
                    db.Bookings.Add(booking);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public bool Update(BookingDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    DatabaseLayer.Booking booking = db.Bookings.FirstOrDefault(c => c.BookingID == model.BookingID);
                    if (booking != null)
                    {
                        booking = bookingconverter.ConverToEntity(model, booking);
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

        public BookingDTOs GetById(Guid bookingId)
        {
            BookingDTOs model = new BookingDTOs();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    DatabaseLayer.Booking booking = db.Bookings.FirstOrDefault(c => c.BookingID == bookingId);
                    if (booking != null)
                    {
                        model = bookingconverter.ConvertToModel(booking);

                    }
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<BookingDTOs> GetAll()
        {
            List<BookingDTOs> bookings = new List<BookingDTOs>();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    var dbBookings = db.Bookings.ToList();
                    foreach (var booking in dbBookings)
                    {
                        bookings.Add(bookingconverter.ConvertToModel(booking));

                    }
                    return bookings;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public bool Delete(Guid bookingId)
        {
            using (var db = new ResturantManagementDBEntities())
            {
                var booking = db.Bookings.FirstOrDefault(x => x.BookingID == bookingId);
                if (booking != null)
                {
                    db.Bookings.Remove(booking);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }



    }
}