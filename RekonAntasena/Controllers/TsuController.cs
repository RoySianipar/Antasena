using Dapper;
using RekonAntasena.Models;
using RekonAntasena.Models.Transaksi;
using RekonAntasena.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _excel = Microsoft.Office.Interop.Excel;


namespace RekonAntasena.Controllers
{
    public class TsuController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["RekonAntasena"].ToString());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DataMatchTsu()
        {
            return View();
        }

        public ActionResult UnmatchTsuAntasena()
        {
            return View();
        }

        public ActionResult UnmatchTsuLHBU()
        {
            return View();
        }
        public ActionResult GetTsuLhbuList()
        {
            var result = _context.TsuLHBU.Include("Status")
                   .Where(x => x.isDelete == false && x.StatusId == 1 && EntityFunctions.TruncateTime(x.CreateDate) == EntityFunctions.TruncateTime(DateTime.Now)).ToList();

            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataTsuAntasenaList()
        {
            var result = _context.TsuAntasena.Include("Status")
                   .Where(x => x.isDelete == false && x.StatusId == 1 && EntityFunctions.TruncateTime(x.CreateDate) == EntityFunctions.TruncateTime(DateTime.Now)).ToList();
           
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTransaksiTsu()
        {

            var result = _context.TransaksiTsu.Include("Status").Include("TsuLHBU").Include("TsuAntasena")
                .Where(x => x.isDelete == false && x.statusId == 2 && EntityFunctions.TruncateTime(x.CreatedDate) == EntityFunctions.TruncateTime(DateTime.Now)).ToList();
            //var result = _context.Transaksi.Include("Status").Include("TsuAntasena").Include("TsuLHBU")
                   //.Where(x => x.isDelete == false && x.statusId == 2 && EntityFunctions.TruncateTime(x.CreatedDate) == EntityFunctions.TruncateTime(DateTime.Now)).ToList();

            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UploadTsuFiles(HttpPostedFileBase[] files, int Id)
        {
            var tabel = "";
            if (Id == 1)
            {
                tabel = "TsuAntasenas";
            }
            else
            {
                tabel = "TsuLHBUs";
            }

            TrDataLHBU trans = new TrDataLHBU();
            foreach (var item in files)
            {
                trans.NamaFile = item.FileName;
                trans.Jenis = Id;
                trans.UploadFile = DateTime.Now;
            }

            _context.TrDataLHBU.Add(trans);
            _context.SaveChanges();

            var resultupload = new TsuAntasenaVM();
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
                                    string underlyingTransaksi = words[4].ToString();
                                    string nominalValutaDasarPerUnderlying = words[5].ToString();
                                    string jnsDokumenUnderlying = words[6].ToString();
                                    string keteranganJnsDokumenUnderlying = words[7].ToString();
                                    string nomorDokumenUnderlying = words[8].ToString();
                                    string nominalDokumenUnderlying = words[9].ToString();
                                    string valutaDokumenUnderlying = words[10].ToString();
                                    string tanggalJatuhTempoDokumenUnderlying = words[11].ToString();
                                    string nomorRefTransaksi2 = words[3].ToString().ToUpper();
                                    

                                    #region Cek Data
                                    var checkData = _con.QueryFirst<int>("SELECT COUNT(*) FROM " + tabel + " WHERE  idPelapor = @idPelapor AND periodeLaporan = @periodeLaporan " +
                                        "AND periodeData = @periodeData AND nomorRefTransaksi2 = @nomorRefTransaksi2 AND underlyingTransaksi = @underlyingTransaksi AND nominalValutaDasarPerUnderlying = @nominalValutaDasarPerUnderlying AND jnsDokumenUnderlying = @jnsDokumenUnderlying " +
                                        "AND keteranganJnsDokumenUnderlying = @keteranganJnsDokumenUnderlying AND nomorDokumenUnderlying = @nomorDokumenUnderlying AND nominalDokumenUnderlying = @nominalDokumenUnderlying AND valutaDokumenUnderlying = @valutaDokumenUnderlying AND tanggalJatuhTempoDokumenUnderlying = @tanggalJatuhTempoDokumenUnderlying ",
                                                  new
                                                    {
                                                        idPelapor = idPelapor,
                                                        periodeLaporan = periodeLaporan,
                                                        periodeData = periodeData,
                                                        nomorRefTransaksi2 = nomorRefTransaksi2,
                                                        underlyingTransaksi = underlyingTransaksi,
                                                        nominalValutaDasarPerUnderlying = nominalValutaDasarPerUnderlying,
                                                        jnsDokumenUnderlying = jnsDokumenUnderlying,
                                                        keteranganJnsDokumenUnderlying = keteranganJnsDokumenUnderlying,
                                                        nomorDokumenUnderlying = nomorDokumenUnderlying,
                                                        nominalDokumenUnderlying = nominalDokumenUnderlying,
                                                        valutaDokumenUnderlying = valutaDokumenUnderlying,
                                                        tanggalJatuhTempoDokumenUnderlying = tanggalJatuhTempoDokumenUnderlying,                                                                                                      
                                                    });

                                    if (checkData == 0)
                                    {

                                        var CreateDate = DateTime.Now;
                                        int StatusId = 1;
                                        bool IsDelete = false;
                                        string sql = "INSERT INTO " + tabel + " (StatusId, idPelapor, periodeLaporan, " +
                                        "periodeData, nomorRefTransaksi, underlyingTransaksi, nominalValutaDasarPerUnderlying, jnsDokumenUnderlying, " +
                                        "keteranganJnsDokumenUnderlying, nomorDokumenUnderlying, nominalDokumenUnderlying, valutaDokumenUnderlying, tanggalJatuhTempoDokumenUnderlying, nomorRefTransaksi2, isDelete, IsDeleted, CreateDate) " +
                                        "VALUES (@StatusId, @idPelapor, @periodeLaporan, @periodeData, @nomorRefTransaksi, @underlyingTransaksi, @nominalValutaDasarPerUnderlying, @jnsDokumenUnderlying, " +
                                        "@keteranganJnsDokumenUnderlying, @nomorDokumenUnderlying, @nominalDokumenUnderlying, @valutaDokumenUnderlying, @tanggalJatuhTempoDokumenUnderlying, @nomorRefTransaksi2, @isDelete, @IsDeleted, @CreateDate)";
                                        _con.Execute(sql, new
                                        {
                                            StatusId = StatusId,
                                            idPelapor = idPelapor,
                                            periodeLaporan = periodeLaporan,
                                            periodeData = periodeData,
                                            nomorRefTransaksi = nomorRefTransaksi,
                                            underlyingTransaksi = underlyingTransaksi,
                                            nominalValutaDasarPerUnderlying = nominalValutaDasarPerUnderlying,
                                            jnsDokumenUnderlying = jnsDokumenUnderlying,
                                            keteranganJnsDokumenUnderlying = keteranganJnsDokumenUnderlying,
                                            nomorDokumenUnderlying = nomorDokumenUnderlying,
                                            nominalDokumenUnderlying = nominalDokumenUnderlying,
                                            valutaDokumenUnderlying = valutaDokumenUnderlying,
                                            tanggalJatuhTempoDokumenUnderlying = tanggalJatuhTempoDokumenUnderlying,
                                            nomorRefTransaksi2 = nomorRefTransaksi2,
                                            isDelete = IsDelete,
                                            IsDeleted = false,
                                            CreateDate = DateTime.Now,
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
        public ActionResult ResetTsuAntasena()
        {
            var result = false;
            var delTrans = "DELETE FROM TransaksiTsus";
            var delAnta = "DELETE FROM TsuAntasenas";
            var delLhbu = "DELETE FROM TsuLHBUs";
            _con.Open();
            _con.Execute(delTrans);
            _con.Execute(delAnta);
            _con.Execute(delLhbu);
            _con.Close();

            return Json(result = true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ResetTsuLHBU()
        {
            var datas = _context.TsuLHBU.Where(x => x.isDelete == false);
            var result = false;
            foreach (var item in datas)
            {
                item.isDelete = true;
                _context.Entry(item).State = EntityState.Modified;
            }
            _context.SaveChanges();
            return Json(result = true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ResetTransaksiTsu()
        {
            var datas = _context.TransaksiTsu.Where(x => x.isDelete == false);
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
            var result = _context.TrDataLHBU.Where(x => x.isDelete == false && DbFunctions.TruncateTime(x.UploadFile) == DbFunctions.TruncateTime(DateTime.Now));

            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Rekon()
        {
            var result = false;
            var getAntasena = _con.Query<TsuAntasenaVM>("SELECT * FROM TsuAntasenas WHERE StatusId = @StatusId AND isDelete = @isDelete", new { StatusId = 1, isDelete = false });
            var updateDataAntasena = "UPDATE TsuAntasenas SET StatusId = @StatusId WHERE Id = @AntaId";
            var updateDataLhbu = "UPDATE TsuLHBUs SET StatusId = @StatusId WHERE Id = @lhbuId";
            var InsertTransaksi = "INSERT INTO TransaksiTsus(statusId ,TsuAntasenaId ,TsuLHBUId, isDelete, CreatedDate) VALUES (@StatusId, @TsuAntasenaId, @TsuLHBUId, @isDelete, @CreatedDate)";

            foreach (var item in getAntasena)
            {
                var getLhbu = _con.QueryFirstOrDefault<TsuLHBUVM>("SELECT * FROM TsuLHBUs WHERE StatusId = @StatusId AND  idPelapor = @idPelapor AND periodeLaporan = @periodeLaporan " +
                                        "AND periodeData = @periodeData AND underlyingTransaksi = @underlyingTransaksi AND nominalValutaDasarPerUnderlying = @nominalValutaDasarPerUnderlying AND jnsDokumenUnderlying = @jnsDokumenUnderlying " +
                                        "AND keteranganJnsDokumenUnderlying = @keteranganJnsDokumenUnderlying AND nomorDokumenUnderlying = @nomorDokumenUnderlying AND nominalDokumenUnderlying = @nominalDokumenUnderlying AND valutaDokumenUnderlying = @valutaDokumenUnderlying AND tanggalJatuhTempoDokumenUnderlying = @tanggalJatuhTempoDokumenUnderlying ",
                                                    new
                                                    {
                                                        StatusId = 1,
                                                        idPelapor = item.idPelapor,
                                                        periodeLaporan = item.periodeLaporan,
                                                        periodeData = item.periodeData,
                                                        //nomorRefTransaksi = item.nomorRefTransaksi,
                                                        underlyingTransaksi = item.underlyingTransaksi,
                                                        nominalValutaDasarPerUnderlying = item.nominalValutaDasarPerUnderlying,
                                                        jnsDokumenUnderlying = item.jnsDokumenUnderlying,
                                                        keteranganJnsDokumenUnderlying = item.keteranganJnsDokumenUnderlying,
                                                        nomorDokumenUnderlying = item.nomorDokumenUnderlying,
                                                        nominalDokumenUnderlying = item.nominalDokumenUnderlying,
                                                        valutaDokumenUnderlying = item.valutaDokumenUnderlying,
                                                        tanggalJatuhTempoDokumenUnderlying = item.tanggalJatuhTempoDokumenUnderlying,
                                                        //nomorRefTransaksi2 = item.nomorRefTransaksi2
                                                    });

                if (getLhbu != null)
                {
                    _con.Open();
                    using (var transaction = _con.BeginTransaction())
                    {
                        _con.Execute(updateDataAntasena, new { StatusId = 2, AntaId = item.Id }, transaction: transaction);
                        _con.Execute(updateDataLhbu, new { StatusId = 2, lhbuId = getLhbu.Id }, transaction: transaction);
                        _con.Execute(InsertTransaksi, new { StatusId = 2, TsuAntasenaId = item.Id, TsuLHBUId = getLhbu.Id, isDelete = false, IsDeleted = false, CreatedDate = DateTime.Now }, transaction: transaction);

                        transaction.Commit();
                    }
                    _con.Close();
                }

            }
            var reset = _context.TrDataLHBU.Where(x => x.isDelete == false).ToList();
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
            var data = _context.TsuAntasena.Where(x => DbFunctions.TruncateTime(x.CreateDate) == DbFunctions.TruncateTime(DateTime.Now));

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