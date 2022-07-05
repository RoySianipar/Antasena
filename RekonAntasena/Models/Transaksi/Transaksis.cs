using RekonAntasena.Models.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RekonAntasena.Models.Transaksi
{
    public class Transaksis
    {
        [Key]
        public int Id { get; set; }
        public virtual Status Status { get; set; }
        public int? statusId { get; set; }
        public virtual DataAntasena DataAntasena { get; set; }
        public int? DataAntasenaId { get; set; }
        public virtual LHBU LHBU { get; set; }
        public int? LHBUId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isDelete { get; set; }
    }
}