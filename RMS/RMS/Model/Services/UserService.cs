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
    public class UserService
    {
        private readonly UserConverter userConverter = new UserConverter();
        public UserDTOs CreateSelectList(UserDTOs model)
        {
            model.UserTypes = GetUserTypes();
            return model;
        }

        public List<BaseGuidSelect> GetUserTypes()
        {
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                return db.UserTypes.Select(u =>
                new BaseGuidSelect
                {
                    Id = u.UserTypeID,
                    Name = u.Type
                }).ToList();

            }
        }
        public bool UserNameValidation(string username)
        {
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                return db.Users.Any(u => u.UserName.Equals(username));
            }
        }


        public bool EmailValidation(string email)
        {
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                return db.Users.Any(u => u.Email.Equals(email));
            }
        }

        public bool PhoneNoValidation(string phoneNumber)
        {
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                return db.Users.Any(u => u.PhoneNumber.Equals(phoneNumber));
            }
        }

        public bool Create(UserDTOs model, string ConfirmPassword)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {


                    if (model.Password == ConfirmPassword)
                    {
                        DatabaseLayer.User user = new DatabaseLayer.User();
                        user.UserId = Guid.NewGuid();
                        user = userConverter.ConverToEntity(model, user);
                        db.Users.Add(user);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public bool Update(UserDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    DatabaseLayer.User user = db.Users.FirstOrDefault(c => c.UserId == model.UserId);
                    if (user != null)
                    {
                        user = userConverter.ConverToEntity(model, user);
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


        public UserDTOs GetById(Guid userId)
        {
            UserDTOs model = new UserDTOs();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    DatabaseLayer.User user = db.Users.FirstOrDefault(c => c.UserId == userId);
                    if (user != null)
                    {
                        model = userConverter.ConvertToModel(user);
                    }
                    return model;
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<UserDTOs> GetAll()
        {
            List<UserDTOs> users = new List<UserDTOs>();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    var dbUser = db.Users.ToList();
                    foreach (var user in dbUser)
                    {

                        users.Add(userConverter.ConvertToModel(user));
                    }
                    return users;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public bool Delete(Guid userId)
        {

            using (var db = new ResturantManagementDBEntities())
            {

                var user = db.Users.FirstOrDefault(x => x.UserId == userId);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }


        public bool Login(string password, string email)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    DatabaseLayer.User user = db.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
                    if (user != null)
                    {
                        return true;
                    }
                    else { return false; }

                }

            }
            catch (Exception ex)
            {
                throw;
            }


        }


    }
}