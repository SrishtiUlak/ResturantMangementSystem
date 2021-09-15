using DatabaseLayer;
using RMS.Model.Converters;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Services
{
    public class TableService
    {
        private readonly TableConverter converter = new TableConverter();
        public bool Create(TableDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    Table table = new Table();
                    table.TableID = Guid.NewGuid();
                    table = converter.ConvertToEntity(model, table);

                    db.Tables.Add(table);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public bool TableNameValidation(string tablename)
        {
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                return db.Tables.Any(t => t.TableName.Equals(tablename));
            }
        }

        public bool Update(TableDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    Table table = db.Tables.FirstOrDefault(t => t.TableID == model.TableID);
                    if (table != null)
                    {
                        table = converter.ConvertToEntity(model, table);
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

        public TableDTOs GetById(Guid tableId)
        {
            TableDTOs model = new TableDTOs();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    Table table = db.Tables.FirstOrDefault(t => t.TableID == tableId);
                    if (table != null)
                    {
                        model = converter.ConvertToModel(table);

                    }
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<TableDTOs> GetAll()
        {
            List<TableDTOs> tables = new List<TableDTOs>();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    var dbTables = db.Tables.ToList();
                    foreach (var table in dbTables)
                    {
                        tables.Add(converter.ConvertToModel(table));

                    }
                    return tables;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}