using RekonAntasena.Models.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RekonAntasena.Models.Transaksi
{
    public class TrDataLHBU
    {
        [Key]
        public int Id { get; set; }
        public virtual Transaksis Transaksi { get; set; }
        public int? TransaksiId { get; set; }
        public virtual LHBU LHBU { get; set; }
        public int? DataLHBUId { get; set; }
    }
}