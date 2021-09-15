using DatabaseLayer;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Converters
{
    public class DishCategoryConverter
    {
        public DishCategory ConverToEntity(DishCategoryDTOs model, DishCategory dishCategory)
        {
            dishCategory.DishCategoryName = model.DishCategoryName;
            return dishCategory;
        }
        public DishCategoryDTOs ConvertToModel(DishCategory model)
        {
            DishCategoryDTOs dishCategory = new DishCategoryDTOs();
            dishCategory.DishCategoryID = model.DishCategoryID;
            dishCategory.DishCategoryName = model.DishCategoryName;

            return dishCategory;
        }
    }
}