using RMS.Model.viewModes;
using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Converters
{
    public class CategoryConverter
    {
        public Category ConverToEntity(CategoryDTOs model, Category category)
        {
            category.CategoryName = model.CategoryName;
            return category;
        }
        public CategoryDTOs ConvertToModel(Category model)
        {
            CategoryDTOs category = new CategoryDTOs();
            category.CategoryID = model.CategoryID;
            category.CategoryName = model.CategoryName;
           
            return category;
        }
    }
}