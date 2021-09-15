using DatabaseLayer;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Converters
{
    public class TableConverter
    {
        public Table ConvertToEntity(TableDTOs model, Table table)
        {
            table.TableName = model.TableName;
            return table;
        }

        public TableDTOs ConvertToModel(Table model)
        {
            TableDTOs table = new TableDTOs();
            table.TableID = model.TableID;
            table.TableName = model.TableName;
            return table;
        }
    }
}