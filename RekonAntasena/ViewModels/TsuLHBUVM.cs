using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RekonAntasena.ViewModels
{
    public class TsuLHBUVM
    {
        public string Id { get; set; }
        public string idPelapor { get; set; }
        public string periodeLaporan { get; set; }
        public string periodeData { get; set; }
        public string nomorRefTransaksi { get; set; }
        public string underlyingTransaksi { get; set; }
        public string nominalValutaDasarPerUnderlying { get; set; }
        public string jnsDokumenUnderlying { get; set; }
        public string keteranganJnsDokumenUnderlying { get; set; }
        public string nomorDokumenUnderlying { get; set; }
        public string nominalDokumenUnderlying { get; set; }
        public string valutaDokumenUnderlying { get; set; }
        public string tanggalJatuhTempoDokumenUnderlying { get; set; }
        public string nomorRefTransaksi2 { get; set; }

    }
}