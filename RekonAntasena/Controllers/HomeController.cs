using Dapper;
using RekonAntasena.Models;
using RekonAntasena.Models.Master;
using RekonAntasena.Models.Transaksi;
using RekonAntasena.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _excel = Microsoft.Office.Interop.Excel;

namespace RekonAntasena.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["RekonAntasena"].ToString());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DataMatch()
        {
            return View();
        }

        public ActionResult UnmatchAntasena()
        {
            return View();
        }

        public ActionResult UnmatchLHBU()
        {
            return View();
        }
        public ActionResult GetLhbuList()
        {
            var result = _context.LHBU.Include("Status")
                   .Where(x => x.isDelete == false && x.StatusId ==1 && EntityFunctions.TruncateTime(x.CreateDate) == EntityFunctions.TruncateTime(DateTime.Now)).ToList();

            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataAntasenaList()
        {
            var result = _context.DataAntasena.Include("Status")
                   .Where(x => x.isDelete == false && x.StatusId == 1 && EntityFunctions.TruncateTime(x.CreateDate) == EntityFunctions.TruncateTime(DateTime.Now)).ToList();

            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTransaksi()
        {
            var result = _context.Transaksi.Include("Status").Include("DataAntasena").Include("LHBU")
                   .Where(x => x.isDelete == false && x.statusId == 2 && EntityFunctions.TruncateTime(x.CreatedDate) == EntityFunctions.TruncateTime(DateTime.Now)).ToList();

            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UploadFiles(HttpPostedFileBase[] files, int Id)
        {
            var tabel = "";
            if (Id == 1)
            {
                tabel = "DataAntasenas";
            }
            else
            {
                tabel = "LHBUs";
            }

            TrDataAntasena trans = new TrDataAntasena();
            foreach (var item in files)
            {
                trans.NamaFile = item.FileName;
                trans.Jenis = Id;
                trans.UploadFile = DateTime.Now;
            }

            _context.TrDataAntasena.Add(trans);
            _context.SaveChanges();

            var resultupload = new DataAntasenaVM();
            if (ModelState.IsValid)
            {
                #region Upload
                foreach (HttpPostedFileBase file in files)
                {
                    if (file != null)
                    {
                        if (file.FileName.EndsWith("xlsx") || file.FileName.EndsWith("xls") || file.FileName.EndsWith("csv"))
                        {
                            _excel.Application application = new _excel.Application();
                            _excel.Workbooks workbooks = application.Workbooks;
                            _excel.Workbook workbook = null;
                            _excel.Worksheet worksheet = null;
                            _excel.Range range = null;
                            string path = Server.MapPath("~/Content/Files/" + file.FileName);

                            try
                            {
                                file.SaveAs(path);
                                string tanggalEfektif = null;
                                string tanggalAwalForward = null;
                                string tanggalValuta = null;
                                string tanggalJatuhTempo = null;
                                workbook = workbooks.Open(path);
                                worksheet = workbook.ActiveSheet;
                                range = worksheet.UsedRange;
                                for (int i = 1; i <= range.Rows.Count; i++)
                                {
                                    string data = ((_excel.Range)range.Cells[i, 1]).Text;
                                    string[] words = data.Split('|');

                                    string idPelapor = words[0].ToString();
                                    string periodeLaporan = words[1].ToString();
                                    string periodeData = words[2];
                                    string nomorRefTransaksi = words[3].ToString();
                                    string idPihakLawan = words[4].ToString();
                                    string kontrak = words[5].ToString();
                                    string variabelMendasari = words[6].ToString();
                                    string peranPelapor = words[7].ToString();
                                    string jamTransaksi = words[8].ToString();
                                    tanggalEfektif = words[9];
                                    tanggalAwalForward = words[10];
                                    tanggalValuta = words[11];
                                    tanggalJatuhTempo = words[12];                               
                                    string valutaDasar = words[13].ToString();
                                    string valutaLawan = words[14].ToString();
                                    string nominalValutaDasar = words[15].ToString();
                                    string kursTransaksi = words[16].ToString();
                                    string strikePrice2 = words[17].ToString();
                                    string baseRate = words[18].ToString();
                                    string premiSwap = words[19].ToString();
                                    string premiOption = words[20].ToString();
                                    string styleOption = words[21].ToString();
                                    string periodePembayaranBunga = words[22].ToString();
                                    string valutaDasarJnsSukuBunga = words[23].ToString();
                                    string valutaDasarJnsSukuBungaAcuan = words[24].ToString();
                                    string valutaDasarTenorSukuBungaAcuan = words[25].ToString();
                                    string valutaDasarPremiumSukuBungaAcuan = words[26].ToString();
                                    string valutaDasarSukuBungaTetap = words[27].ToString();
                                    string valutaLawanJnsSukuBunga = words[28].ToString();
                                    string valutaLawanJnsSukuBungaAcuan = words[29].ToString();
                                    string valutaLawanTenorSukuBungaAcuan = words[30].ToString();
                                    string valutaLawanPremiumSukuBungaAcuan = words[31].ToString();
                                    string valutaLawanSukuBungaTetap = words[32].ToString();
                                    string hargaFutures = words[33].ToString();
                                    string keteranganTransaksi = words[34].ToString();
                                    string transaksiPihakAsing = words[35].ToString();
                                    string lcsNegaraMitra = words[36].ToString();
                                    string nettingNomorReferensiTransaksiTerakhir = words[37].ToString();
                                    string nettingTujuan = words[38].ToString();
                                    string nettingVolume = words[39].ToString();
                                    string dynamicHedgingNomorReferensiTransaksiTerakhir = words[40].ToString();
                                    string nomorRefTransaksi2 = words[3].ToString().ToUpper();
                                    string kontrak2 = words[5].ToString().ToUpper();



                                    #region Cek Data
                                    var checkData = _con.QueryFirst<int>("SELECT COUNT(*) FROM "+tabel+ " WHERE  idPelapor = @idPelapor AND periodeLaporan = @periodeLaporan "+
                                        "AND periodeData = @periodeData AND nomorRefTransaksi2 = @nomorRefTransaksi2 AND idPihakLawan = @idPihakLawan AND kontrak2 = @kontrak2 AND variabelMendasari = @variabelMendasari " +
                                        "AND peranPelapor = @peranPelapor AND jamTransaksi = @jamTransaksi AND tanggalEfektif = @tanggalEfektif AND tanggalAwalForward = @tanggalAwalForward AND tanggalValuta = @tanggalValuta " +
                                        "AND tanggalJatuhTempo = @tanggalJatuhTempo AND valutaDasar = @valutaDasar AND valutaLawan = @valutaLawan AND nominalValutaDasar = @nominalValutaDasar AND kursTransaksi = @kursTransaksi " +
                                        "AND strikePrice2 = @strikePrice2 AND baseRate = @baseRate AND premiSwap = @premiSwap AND premiOption = @premiOption AND styleOption = @styleOption AND periodePembayaranBunga = @periodePembayaranBunga " +
                                        "AND valutaDasarJnsSukuBunga = @valutaDasarJnsSukuBunga AND valutaDasarJnsSukuBungaAcuan = @valutaDasarJnsSukuBungaAcuan AND valutaDasarTenorSukuBungaAcuan = @valutaDasarTenorSukuBungaAcuan " +
                                        "AND valutaDasarPremiumSukuBungaAcuan = @valutaDasarPremiumSukuBungaAcuan AND valutaDasarSukuBungaTetap = @valutaDasarSukuBungaTetap AND valutaLawanJnsSukuBunga = @valutaLawanJnsSukuBunga AND valutaLawanJnsSukuBungaAcuan = @valutaLawanJnsSukuBungaAcuan " +
                                        "AND valutaLawanTenorSukuBungaAcuan = @valutaLawanTenorSukuBungaAcuan AND valutaLawanPremiumSukuBungaAcuan = @valutaLawanPremiumSukuBungaAcuan AND valutaLawanSukuBungaTetap = @valutaLawanSukuBungaTetap " +
                                        "AND hargaFutures = @hargaFutures AND keteranganTransaksi = @keteranganTransaksi AND transaksiPihakAsing = @transaksiPihakAsing AND lcsNegaraMitra = @lcsNegaraMitra AND nettingNomorReferensiTransaksiTerakhir = @nettingNomorReferensiTransaksiTerakhir " +
                                        "AND nettingTujuan = @nettingTujuan AND nettingVolume = @nettingVolume AND dynamicHedgingNomorReferensiTransaksiTerakhir = @dynamicHedgingNomorReferensiTransaksiTerakhir ",
                                                    new {idPelapor = idPelapor, periodeLaporan = periodeLaporan, periodeData = periodeData, nomorRefTransaksi2 = nomorRefTransaksi2,
                                                        idPihakLawan = idPihakLawan, kontrak2 = kontrak2, variabelMendasari = variabelMendasari, peranPelapor = peranPelapor, jamTransaksi = jamTransaksi,
                                                        tanggalEfektif = tanggalEfektif, tanggalAwalForward = tanggalAwalForward, tanggalValuta = tanggalValuta, tanggalJatuhTempo = tanggalJatuhTempo, valutaDasar = valutaDasar, valutaLawan = valutaLawan,
                                                        nominalValutaDasar = nominalValutaDasar, kursTransaksi = kursTransaksi, strikePrice2 = strikePrice2, baseRate = baseRate, premiSwap = premiSwap, premiOption = premiOption, styleOption = styleOption,
                                                        periodePembayaranBunga = periodePembayaranBunga, valutaDasarJnsSukuBunga = valutaDasarJnsSukuBunga, valutaDasarJnsSukuBungaAcuan = valutaDasarJnsSukuBungaAcuan, valutaDasarTenorSukuBungaAcuan = valutaDasarTenorSukuBungaAcuan,
                                                        valutaDasarPremiumSukuBungaAcuan = valutaDasarPremiumSukuBungaAcuan, valutaDasarSukuBungaTetap = valutaDasarSukuBungaTetap, valutaLawanJnsSukuBunga = valutaLawanJnsSukuBunga, valutaLawanJnsSukuBungaAcuan = valutaLawanJnsSukuBungaAcuan,
                                                        valutaLawanTenorSukuBungaAcuan = valutaLawanTenorSukuBungaAcuan, valutaLawanPremiumSukuBungaAcuan = valutaLawanPremiumSukuBungaAcuan, valutaLawanSukuBungaTetap = valutaLawanSukuBungaTetap, hargaFutures = hargaFutures,
                                                        keteranganTransaksi = keteranganTransaksi, transaksiPihakAsing = transaksiPihakAsing, lcsNegaraMitra = lcsNegaraMitra, nettingNomorReferensiTransaksiTerakhir = nettingNomorReferensiTransaksiTerakhir,
                                                        nettingTujuan = nettingTujuan, nettingVolume = nettingVolume, dynamicHedgingNomorReferensiTransaksiTerakhir = dynamicHedgingNomorReferensiTransaksiTerakhir});

                                    if (checkData == 0)
                                    {
                                         
                                        var CreateDate = DateTime.Now;
                                        int StatusId = 1;
                                        bool IsDelete = false;
                                        string sql = "INSERT INTO " + tabel + " (StatusId, idPelapor, periodeLaporan, periodeData, nomorRefTransaksi, idPihakLawan, kontrak, variabelMendasari, peranPelapor, jamTransaksi, tanggalEfektif, " +
                                            "tanggalAwalForward, tanggalValuta, tanggalJatuhTempo, valutaDasar, valutaLawan, nominalValutaDasar, kursTransaksi, strikePrice2, baseRate, premiSwap, premiOption, styleOption, periodePembayaranBunga, valutaDasarJnsSukuBunga, "+
                                            "valutaDasarJnsSukuBungaAcuan, valutaDasarTenorSukuBungaAcuan, valutaDasarPremiumSukuBungaAcuan, valutaDasarSukuBungaTetap, valutaLawanJnsSukuBunga, valutaLawanJnsSukuBungaAcuan, valutaLawanTenorSukuBungaAcuan, "+
                                            "valutaLawanPremiumSukuBungaAcuan, valutaLawanSukuBungaTetap, hargaFutures, keteranganTransaksi, transaksiPihakAsing, lcsNegaraMitra, nettingNomorReferensiTransaksiTerakhir, nettingTujuan, nettingVolume, dynamicHedgingNomorReferensiTransaksiTerakhir, CreateDate, nomorRefTransaksi2, kontrak2, isDelete) " +
                                            "VALUES (@StatusId, @idPelapor, @periodeLaporan,@periodeData,@nomorRefTransaksi,@idPihakLawan,@kontrak,@variabelMendasari,@peranPelapor,@jamTransaksi,@tanggalEfektif,@tanggalAwalForward,@tanggalValuta,@tanggalJatuhTempo,@valutaDasar,@valutaLawan,@nominalValutaDasar, "+
                                            "@kursTransaksi,@strikePrice2,@baseRate,@premiSwap,@premiOption,@styleOption,@periodePembayaranBunga,@valutaDasarJnsSukuBunga,@valutaDasarJnsSukuBungaAcuan,@valutaDasarTenorSukuBungaAcuan,@valutaDasarPremiumSukuBungaAcuan,@valutaDasarSukuBungaTetap,@valutaLawanJnsSukuBunga, "+
                                            "@valutaLawanJnsSukuBungaAcuan,@valutaLawanTenorSukuBungaAcuan,@valutaLawanPremiumSukuBungaAcuan,@valutaLawanSukuBungaTetap,@hargaFutures,@keteranganTransaksi,@transaksiPihakAsing,@lcsNegaraMitra,@nettingNomorReferensiTransaksiTerakhir,@nettingTujuan,@nettingVolume,@dynamicHedgingNomorReferensiTransaksiTerakhir,@CreateDate, @nomorRefTransaksi2, @kontrak2, @isDelete)";
                                        _con.Execute(sql, new
                                        {
                                            StatusId = StatusId,
                                            idPelapor = idPelapor,
                                            periodeLaporan = periodeLaporan,
                                            periodeData = periodeData,
                                            nomorRefTransaksi = nomorRefTransaksi,
                                            idPihakLawan = idPihakLawan,
                                            kontrak = kontrak,
                                            variabelMendasari = variabelMendasari,
                                            peranPelapor = peranPelapor,
                                            jamTransaksi = jamTransaksi,
                                            tanggalEfektif = tanggalEfektif,
                                            tanggalAwalForward = tanggalAwalForward,
                                            tanggalValuta = tanggalValuta,
                                            tanggalJatuhTempo = tanggalJatuhTempo,
                                            valutaDasar = valutaDasar,
                                            valutaLawan = valutaLawan,
                                            nominalValutaDasar = nominalValutaDasar,
                                            kursTransaksi = kursTransaksi,
                                            strikePrice2 = strikePrice2,
                                            baseRate = baseRate,
                                            premiSwap = premiSwap,
                                            premiOption = premiOption,
                                            styleOption = styleOption,
                                            periodePembayaranBunga = periodePembayaranBunga,
                                            valutaDasarJnsSukuBunga = valutaDasarJnsSukuBunga,
                                            valutaDasarJnsSukuBungaAcuan = valutaDasarJnsSukuBungaAcuan,
                                            valutaDasarTenorSukuBungaAcuan = valutaDasarTenorSukuBungaAcuan,
                                            valutaDasarPremiumSukuBungaAcuan = valutaDasarPremiumSukuBungaAcuan,
                                            valutaDasarSukuBungaTetap = valutaDasarSukuBungaTetap,
                                            valutaLawanJnsSukuBunga = valutaLawanJnsSukuBunga,
                                            valutaLawanJnsSukuBungaAcuan = valutaLawanJnsSukuBungaAcuan,
                                            valutaLawanTenorSukuBungaAcuan = valutaLawanTenorSukuBungaAcuan,
                                            valutaLawanPremiumSukuBungaAcuan = valutaLawanPremiumSukuBungaAcuan,
                                            valutaLawanSukuBungaTetap = valutaLawanSukuBungaTetap,
                                            hargaFutures = hargaFutures,
                                            keteranganTransaksi = keteranganTransaksi,
                                            transaksiPihakAsing = transaksiPihakAsing,
                                            lcsNegaraMitra = lcsNegaraMitra,
                                            nettingNomorReferensiTransaksiTerakhir = nettingNomorReferensiTransaksiTerakhir,
                                            nettingTujuan = nettingTujuan,
                                            nettingVolume = nettingVolume,
                                            dynamicHedgingNomorReferensiTransaksiTerakhir = dynamicHedgingNomorReferensiTransaksiTerakhir,
                                            CreateDate= CreateDate,
                                            nomorRefTransaksi2 = nomorRefTransaksi2,
                                            kontrak2= kontrak2,
                                            isDelete = IsDelete
                                        });






                                    }
                                    else
                                    {
                                        //cfails++;
                                    }
                                    #endregion
                                }



                            }
                            catch (Exception ex)
                            {
                                workbooks.Close();
                                application.Quit();
                                System.IO.File.Delete(path);
                                return new HttpStatusCodeResult(500, ex.Message);
                            }
                            finally
                            {
                                workbooks.Close();
                                application.Quit();
                                System.IO.File.Delete(path);

                                GC.Collect();
                                GC.WaitForPendingFinalizers();
                            }
                        }
                    }
                }
                #endregion
            }

            return Json(new { ResultUpload = resultupload }, JsonRequestBehavior.AllowGet);


        }

        public ActionResult ResetAntasena()
        {
            var result = false;
            var delTrans = "DELETE FROM Transaksis";
            var delAnta = "DELETE FROM DataAntasenas";
            var delLhbu = "DELETE FROM LHBUs";
            _con.Open();
            _con.Execute(delTrans);
            _con.Execute(delAnta);
            _con.Execute(delLhbu);
            _con.Close();

            return Json(result = true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ResetLHBU()
        {
            var datas = _context.LHBU.Where(x => x.isDelete == false);
            var result = false;
            foreach (var item in datas)
            {
                item.isDelete = true;
                _context.Entry(item).State = EntityState.Modified;
            }
            _context.SaveChanges();
            return Json(result = true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ResetTransaksi()
        {
            var datas = _context.Transaksi.Where(x => x.isDelete == false);
            var result = false;
            foreach (var item in datas)
            {
                item.isDelete = true;
                _context.Entry(item).State = EntityState.Modified;
            }
            _context.SaveChanges();
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult getTrans()
        {
            var result = _context.TrDataAntasena.Where(x => x.isDelete == false && DbFunctions.TruncateTime(x.UploadFile) == DbFunctions.TruncateTime(DateTime.Now));

            return Json(new {data = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Rekon()
        {
            var result = false;
            var getAntasena = _con.Query<DataAntasenaVM>("SELECT * FROM DataAntasenas WHERE StatusId = @StatusId AND isDelete = @isDelete", new { StatusId = 1 , isDelete = false});
            var updateDataAntasena = "UPDATE DataAntasenas SET StatusId = @StatusId WHERE Id = @AntaId";
            var updateDataLhbu = "UPDATE LHBUs SET StatusId = @StatusId WHERE Id = @lhbuId";
            var InsertTransaksi = "INSERT INTO Transaksis(statusId ,DataAntasenaId ,LHBUId, isDelete, CreatedDate) VALUES (@StatusId, @DataAntasenaId, @LHBUId, @isDelete, @CreatedDate)";

            foreach (var item in getAntasena)
            {
                var getLhbu = _con.QueryFirstOrDefault<DataLHBUVM>("SELECT * FROM LHBUs WHERE StatusId = @StatusId AND idPelapor = @idPelapor AND periodeLaporan = @periodeLaporan " +
                                        "AND periodeData = @periodeData AND idPihakLawan = @idPihakLawan AND kontrak2 = @kontrak2 AND variabelMendasari = @variabelMendasari " +
                                        "AND peranPelapor = @peranPelapor AND tanggalEfektif = @tanggalEfektif AND tanggalAwalForward = @tanggalAwalForward AND tanggalValuta = @tanggalValuta " +
                                        "AND tanggalJatuhTempo = @tanggalJatuhTempo AND valutaDasar = @valutaDasar AND valutaLawan = @valutaLawan AND nominalValutaDasar = @nominalValutaDasar AND kursTransaksi = @kursTransaksi " +
                                        "AND strikePrice2 = @strikePrice2 AND baseRate = @baseRate AND premiSwap = @premiSwap AND premiOption = @premiOption AND styleOption = @styleOption AND periodePembayaranBunga = @periodePembayaranBunga " +
                                        "AND valutaDasarJnsSukuBunga = @valutaDasarJnsSukuBunga AND valutaDasarJnsSukuBungaAcuan = @valutaDasarJnsSukuBungaAcuan AND valutaDasarTenorSukuBungaAcuan = @valutaDasarTenorSukuBungaAcuan " +
                                        "AND valutaDasarPremiumSukuBungaAcuan = @valutaDasarPremiumSukuBungaAcuan AND valutaDasarSukuBungaTetap = @valutaDasarSukuBungaTetap AND valutaLawanJnsSukuBunga = @valutaLawanJnsSukuBunga AND valutaLawanJnsSukuBungaAcuan = @valutaLawanJnsSukuBungaAcuan " +
                                        "AND valutaLawanTenorSukuBungaAcuan = @valutaLawanTenorSukuBungaAcuan AND valutaLawanPremiumSukuBungaAcuan = @valutaLawanPremiumSukuBungaAcuan AND valutaLawanSukuBungaTetap = @valutaLawanSukuBungaTetap " +
                                        "AND hargaFutures = @hargaFutures AND keteranganTransaksi = @keteranganTransaksi AND transaksiPihakAsing = @transaksiPihakAsing AND lcsNegaraMitra = @lcsNegaraMitra AND nettingNomorReferensiTransaksiTerakhir = @nettingNomorReferensiTransaksiTerakhir " +
                                        "AND nettingTujuan = @nettingTujuan AND nettingVolume = @nettingVolume AND dynamicHedgingNomorReferensiTransaksiTerakhir = @dynamicHedgingNomorReferensiTransaksiTerakhir ",
                                                    new
                                                    {
                                                        StatusId = 1,
                                                        idPelapor = item.idPelapor,
                                                        periodeLaporan = item.periodeLaporan,
                                                        periodeData = item.periodeData,
                                                        //nomorRefTransaksi2 = item.nomorRefTransaksi2.ToLower(),
                                                        idPihakLawan = item.idPihakLawan,
                                                        kontrak2 = item.kontrak2.ToLower(),
                                                        variabelMendasari = item.variabelMendasari,
                                                        peranPelapor = item.peranPelapor,
                                                        
                                                        tanggalEfektif = item.tanggalEfektif,
                                                        tanggalAwalForward = item.tanggalAwalForward,
                                                        tanggalValuta = item.tanggalValuta,
                                                        tanggalJatuhTempo = item.tanggalJatuhTempo,
                                                        valutaDasar = item.valutaDasar,
                                                        valutaLawan = item.valutaLawan,
                                                        nominalValutaDasar = item.nominalValutaDasar,
                                                        kursTransaksi = item.kursTransaksi,
                                                        strikePrice2 = item.strikePrice2,
                                                        baseRate = item.baseRate,
                                                        premiSwap = item.premiSwap,
                                                        premiOption = item.premiOption,
                                                        styleOption = item.styleOption,
                                                        periodePembayaranBunga = item.periodePembayaranBunga,
                                                        valutaDasarJnsSukuBunga = item.valutaDasarJnsSukuBunga,
                                                        valutaDasarJnsSukuBungaAcuan = item.valutaDasarJnsSukuBungaAcuan,
                                                        valutaDasarTenorSukuBungaAcuan = item.valutaDasarTenorSukuBungaAcuan,
                                                        valutaDasarPremiumSukuBungaAcuan = item.valutaDasarPremiumSukuBungaAcuan,
                                                        valutaDasarSukuBungaTetap = item.valutaDasarSukuBungaTetap,
                                                        valutaLawanJnsSukuBunga = item.valutaLawanJnsSukuBunga,
                                                        valutaLawanJnsSukuBungaAcuan = item.valutaLawanJnsSukuBungaAcuan,
                                                        valutaLawanTenorSukuBungaAcuan = item.valutaLawanTenorSukuBungaAcuan,
                                                        valutaLawanPremiumSukuBungaAcuan = item.valutaLawanPremiumSukuBungaAcuan,
                                                        valutaLawanSukuBungaTetap = item.valutaLawanSukuBungaTetap,
                                                        hargaFutures = item.hargaFutures,
                                                        keteranganTransaksi = item.keteranganTransaksi,
                                                        transaksiPihakAsing = item.transaksiPihakAsing,
                                                        lcsNegaraMitra = item.lcsNegaraMitra,
                                                        nettingNomorReferensiTransaksiTerakhir = item.nettingNomorReferensiTransaksiTerakhir,
                                                        nettingTujuan = item.nettingTujuan,
                                                        nettingVolume = item.nettingVolume,
                                                        dynamicHedgingNomorReferensiTransaksiTerakhir = item.dynamicHedgingNomorReferensiTransaksiTerakhir
                                                    });

                if (getLhbu != null)
                {
                    _con.Open();
                    using (var transaction = _con.BeginTransaction())
                    { 
                        _con.Execute(updateDataAntasena, new { StatusId = 2, AntaId = item.Id }, transaction: transaction);
                        _con.Execute(updateDataLhbu, new { StatusId = 2, lhbuId = getLhbu.Id }, transaction: transaction);
                        _con.Execute(InsertTransaksi, new { StatusId = 2, DataAntasenaId = item.Id, LHBUId = getLhbu.Id , isDelete = false, CreatedDate = DateTime.Now}, transaction: transaction);

                        transaction.Commit();
                    }
                    _con.Close();
                }

            }
            var reset = _context.TrDataAntasena.Where(x => x.isDelete == false).ToList();
            foreach (var item in reset)
            {
                item.isDelete = true;
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return Json(result = true, JsonRequestBehavior.AllowGet);
        }
       
        public bool CekDataAntasena()
        {
            var result = false;
            var data = _context.DataAntasena.Where(x => DbFunctions.TruncateTime(x.CreateDate) == DbFunctions.TruncateTime(DateTime.Now));

            if (data.Count() == 0)
            {
                result = false;
            }
            else
            {
                result = true;
            }

            return result;
        }

    }
}