using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Converters
{
    public class UserTypeConverter
    {
        public DatabaseLayer.UserType ConverToEntity(UserTypeDTOs model, DatabaseLayer.UserType userType)
        {
            userType.Type = model.Type;
            return userType;
        }
        public UserTypeDTOs ConvertToModel(DatabaseLayer.UserType model)
        {
            UserTypeDTOs userType = new UserTypeDTOs();
            userType.UserTypeID = model.UserTypeID;
            userType.Type = model.Type;
            return userType;
        }
    }
}