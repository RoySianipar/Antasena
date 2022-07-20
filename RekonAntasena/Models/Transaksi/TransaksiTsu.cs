using RekonAntasena.Models.Master;
using RekonAntasena.Models.Tsu;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RekonAntasena.Models.Transaksi
{
    public class TransaksiTsu
    {
        [Key]
        public int Id { get; set; }
        public virtual Status Status { get; set; }
        public int? statusId { get; set; }
        public virtual TsuAntasena TsuAntasena { get; set; }
        public int? TsuAntasenaId { get; set; }
        public virtual TsuLHBU TsuLHBU { get; set; }
        public int? TsuLHBUId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isDelete { get; set; }
    }
}