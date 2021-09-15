using DatabaseLayer;
using RMS.Model.Converters;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Services
{
    public class DishCategoryService
    {
        private readonly DishCategoryConverter converter = new DishCategoryConverter();
        public bool Create(DishCategoryDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    DishCategory dishCategory = new DishCategory();
                    dishCategory.DishCategoryID = Guid.NewGuid();
                    dishCategory = converter.ConverToEntity(model, dishCategory);

                    db.DishCategories.Add(dishCategory);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public bool Update(DishCategoryDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    DishCategory dishCategory = db.DishCategories.FirstOrDefault(ca => ca.DishCategoryID == model.DishCategoryID);
                    if (dishCategory != null)
                    {
                        dishCategory = converter.ConverToEntity(model, dishCategory);
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
        public DishCategoryDTOs GetById(Guid dishCategoryId)
        {
            DishCategoryDTOs model = new DishCategoryDTOs();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    DishCategory dishCategory = db.DishCategories.FirstOrDefault(c => c.DishCategoryID == dishCategoryId);
                    if (dishCategory != null)
                    {
                        model = converter.ConvertToModel(dishCategory);

                    }
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<DishCategoryDTOs> GetAll()
        {
            List<DishCategoryDTOs> dishCategories = new List<DishCategoryDTOs>();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    var dbDishCategorys = db.DishCategories.ToList();
                    foreach (var dishcategory in dbDishCategorys)
                    {
                        dishCategories.Add(converter.ConvertToModel(dishcategory));

                    }
                    return dishCategories;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}