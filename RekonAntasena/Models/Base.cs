using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RekonAntasena.Models
{
    public class Base
    {
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}