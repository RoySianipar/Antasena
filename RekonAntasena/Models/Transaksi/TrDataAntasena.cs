using RekonAntasena.Models.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RekonAntasena.Models.Transaksi
{
    public class TrDataAntasena
    {
        [Key]
        public int Id { get; set; }
        public string NamaFile { get; set; }
        public int Jenis { get; set; }
        public DateTime UploadFile { get; set; }

        public bool isDelete { get; set; }

    }
}