using DatabaseLayer;
using RMS.Model.Converters;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Services
{
    public class CategoryService
    {
        private readonly CategoryConverter converter = new CategoryConverter();
        public bool Create(CategoryDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    Category category = new Category();
                    category.CategoryID = Guid.NewGuid();
                    category = converter.ConverToEntity(model, category);

                    db.Categories.Add(category);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public bool CategoryNameValidation(string categoryname)
        {
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                return db.Categories.Any(u => u.CategoryName.Equals(categoryname));
            }
        }

        public bool Update(CategoryDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    Category category = db.Categories.FirstOrDefault(ca => ca.CategoryID == model.CategoryID);
                    if (category != null)
                    {
                        category = converter.ConverToEntity(model, category);
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

        public CategoryDTOs GetById(Guid categoryId)
        {
            CategoryDTOs model = new CategoryDTOs();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    Category category = db.Categories.FirstOrDefault(c => c.CategoryID == categoryId);
                    if (category != null)
                    {
                        model = converter.ConvertToModel(category);

                    }
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<CategoryDTOs> GetAll()
        {
            List<CategoryDTOs> categorys = new List<CategoryDTOs>();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    var dbCategorys = db.Categories.ToList();
                    foreach (var category in dbCategorys)
                    {
                        categorys.Add(converter.ConvertToModel(category));

                    }
                    return categorys;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}