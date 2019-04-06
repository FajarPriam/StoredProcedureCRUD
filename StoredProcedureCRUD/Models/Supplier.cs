using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoredProcedureCRUD.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}