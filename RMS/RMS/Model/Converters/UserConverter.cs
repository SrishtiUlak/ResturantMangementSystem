using DatabaseLayer;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Converters
{
    public class UserConverter
    {
        public User ConverToEntity(UserDTOs model, User user)
        {
            user.FristName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.Password = model.Password;
            user.Address = model.Address;
            user.UserTypeID = model.UserTypeID;
            return user;
        }
        public UserDTOs ConvertToModel(DatabaseLayer.User model)
        {
            UserDTOs user = new UserDTOs();
            user.UserId = model.UserId;
            user.FirstName = model.FristName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.Password = model.Password;
            user.Address = model.Address;
            user.UserTypeID = model.UserTypeID;
            user.UserType = model.UserType.Type;
            return user;
        }

    }
}