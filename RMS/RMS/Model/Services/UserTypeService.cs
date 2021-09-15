using DatabaseLayer;
using RMS.Model.Converters;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Services
{
    public class UserTypeService
    {
        private readonly UserTypeConverter userTypeConverter = new UserTypeConverter();
        public bool UserTypeValidation(string type)
        {
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                return db.UserTypes.Any(u => u.Type.Equals(type));
            }
        }

        public bool Create(UserTypeDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    DatabaseLayer.UserType userType  = new DatabaseLayer.UserType();
                    userType.UserTypeID = Guid.NewGuid();
                    userType = userTypeConverter.ConverToEntity(model, userType);

                    db.UserTypes.Add(userType);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public bool Update(UserTypeDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    DatabaseLayer.UserType userType = db.UserTypes.FirstOrDefault(c => c.UserTypeID == model.UserTypeID);
                    if (userType != null)
                    {
                        userType = userTypeConverter.ConverToEntity(model, userType);
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
        public UserTypeDTOs GetById(Guid userTypeId)
        {
            UserTypeDTOs model = new UserTypeDTOs();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    DatabaseLayer.UserType userType = db.UserTypes.FirstOrDefault(c => c.UserTypeID == userTypeId);
                    if (userType != null)
                    {
                        model = userTypeConverter.ConvertToModel(userType);

                    }
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<UserTypeDTOs> GetAll()
        {
            List<UserTypeDTOs> userTypes = new List<UserTypeDTOs>();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    var dbUserTypes = db.UserTypes.ToList();
                    foreach (var userType in dbUserTypes)
                    {
                        userTypes.Add(userTypeConverter.ConvertToModel(userType));

                    }
                    return userTypes;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public bool Delete(Guid userTypeId)
        {           
           
                using (var db = new ResturantManagementDBEntities())
                {

                var userType = db.UserTypes.FirstOrDefault(x => x.UserTypeID == userTypeId);
                    if (userType != null)
                    {
                        db.UserTypes.Remove(userType);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
        }
}