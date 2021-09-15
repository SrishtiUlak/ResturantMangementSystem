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
    public class DishSubCategoryService
    {

        private readonly DishSubCategoryConverter converter = new DishSubCategoryConverter();

        public DishSubCategoryDTOs CreateSelectList( DishSubCategoryDTOs dishSub)
        {
            dishSub.DishCategorys = GetDishCategory();
            return dishSub;
        }

        public List<BaseGuidSelect> GetDishCategory()
        {
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                return db.DishCategories.Select(c =>

               new BaseGuidSelect
               {
                   Id = c.DishCategoryID,
                   Name = c.DishCategoryName
               }).ToList();
            }


        }


        public bool Create(DishSubCategoryDTOs dishSub)
        {
            try
            {
                using(ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    DishSubCategory dishSubCategory = new DishSubCategory();
                    dishSubCategory.SubCategoryID = Guid.NewGuid();
                    dishSubCategory = converter.ConvertToEntity(dishSub, dishSubCategory);

                    db.DishSubCategories.Add(dishSubCategory);
                    db.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        

        public bool Update(DishSubCategoryDTOs dishSub)
        {
            try
            {
                using(ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    DishSubCategory dishSubCategory = db.DishSubCategories.FirstOrDefault(dsc => dsc.SubCategoryID == dishSub.SubCategoryId);
                    if(dishSubCategory != null)
                    {
                        dishSubCategory = converter.ConvertToEntity(dishSub, dishSubCategory);
                        db.SaveChanges();
                        return true;

                    }
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public DishSubCategoryDTOs GetById(Guid dishSubCategoryId)
        {
            DishSubCategoryDTOs model = new DishSubCategoryDTOs();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    DishSubCategory dishSubCategory = db.DishSubCategories.FirstOrDefault(c => c.SubCategoryID == dishSubCategoryId);
                    if (dishSubCategory != null)
                    {
                        model = converter.ConvertToModel(dishSubCategory);

                    }
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<DishSubCategoryDTOs> GetAll()
        {
            List<DishSubCategoryDTOs> dishsubCategories = new List<DishSubCategoryDTOs>();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    var dbDishSubCategorys = db.DishSubCategories.ToList();
                    foreach (var dishsubcategory in dbDishSubCategorys)
                    {
                        dishsubCategories.Add(converter.ConvertToModel(dishsubcategory));

                    }
                    return dishsubCategories;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }




    }
}