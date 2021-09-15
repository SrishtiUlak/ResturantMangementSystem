using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes.Base
{
    public class BaseGuidSelect
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TimeSpan OrderTime {get; set;}
    }

    public class BaseIdSelect
    {
        public int Id { get; set; }
    }
}