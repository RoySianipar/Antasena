using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RekonAntasena.ViewModels
{
    public class DataAntasenaVM
    {
        public string Id { get; set; }
        public string idPelapor { get; set; }
        public string periodeLaporan { get; set; }
        public string periodeData { get; set; }
        public string nomorRefTransaksi { get; set; }
        public string idPihakLawan { get; set; }
        public string kontrak { get; set; }
        public string variabelMendasari { get; set; }
        public string peranPelapor { get; set; }
        public string jamTransaksi { get; set; }
        public string tanggalEfektif { get; set; }
        public string tanggalAwalForward { get; set; }
        public string tanggalValuta { get; set; }
        public string tanggalJatuhTempo { get; set; }
        public string valutaDasar { get; set; }
        public string valutaLawan { get; set; }
        public string nominalValutaDasar { get; set; }
        public string kursTransaksi { get; set; }
        public string strikePrice2 { get; set; }
        public string baseRate { get; set; }
        public string premiSwap { get; set; }
        public string premiOption { get; set; }
        public string styleOption { get; set; }
        public string periodePembayaranBunga { get; set; }
        public string valutaDasarJnsSukuBunga { get; set; }
        public string valutaDasarJnsSukuBungaAcuan { get; set; }
        public string valutaDasarTenorSukuBungaAcuan { get; set; }
        public string valutaDasarPremiumSukuBungaAcuan { get; set; }
        public string valutaDasarSukuBungaTetap { get; set; }
        public string valutaLawanJnsSukuBunga { get; set; }
        public string valutaLawanJnsSukuBungaAcuan { get; set; }
        public string valutaLawanTenorSukuBungaAcuan { get; set; }
        public string valutaLawanPremiumSukuBungaAcuan { get; set; }
        public string valutaLawanSukuBungaTetap { get; set; }
        public string hargaFutures { get; set; }
        public string keteranganTransaksi { get; set; }
        public string transaksiPihakAsing { get; set; }
        public string lcsNegaraMitra { get; set; }
        public string nettingNomorReferensiTransaksiTerakhir { get; set; }
        public string nettingTujuan { get; set; }
        public string nettingVolume { get; set; }
        public string dynamicHedgingNomorReferensiTransaksiTerakhir { get; set; }
        public string nomorRefTransaksi2 { get; set; }
        public string kontrak2 { get; set; }
    }
}