using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class TableDTOs
    {
        public Guid TableID { get; set; }
        [Required(ErrorMessage = "Table Name is required")]
        //[StringLength(95, ErrorMessage = "Table Name Should be between 3 to 9", MinimumLength = 3)]
        public string TableName { get; set; }
    }
}