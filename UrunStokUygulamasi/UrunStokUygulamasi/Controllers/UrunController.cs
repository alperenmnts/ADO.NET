using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using UrunStokUygulamasi.Models;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace UrunStokUygulamasi.Controllers
{
    [System.Web.Mvc.Authorize]
    public class UrunController : Controller
    {
        UrunStokEntities db = new UrunStokEntities();
        
        public ActionResult List(Urunler urun)
        {
            return View(db.Urunler.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Urunler urun)
        {
            try
            {
                if (db.Urunler.Any(x => x.UrunAdi == urun.UrunAdi))
                {
                    ViewBag.Notification = "Bu ürün zaten bulunmaktadır.";
                    return View();
                }
                else
                {
                    db.Urunler.Add(urun);
                    urun.Tarih = DateTime.Now;
                    db.SaveChanges();
                    TempData["InsertMsg"] = "<script>alert('Ekleme işlemi başarıyla tamamlandı.')</script>";
                    return RedirectToAction("List", "Urun");
                }
            }
            catch (Exception)
            {
                //ViewBag.Notification2 = "Ekleme işlemi sırasında hata oluştu!";
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            return View(db.Urunler.Where(x => x.Id == id).FirstOrDefault<Urunler>());
        }
        [HttpPost]
        public ActionResult Edit(Urunler urun)
        {
            try
            {
                if (db.Urunler.Any(x => x.UrunAdi == urun.UrunAdi))
                {
                    ViewBag.Notification = "Bu ürün zaten bulunmaktadır.";
                    return View();
                }
                else
                {
                    db.Entry(urun).State = EntityState.Modified;
                    urun.Tarih = DateTime.Now;
                    db.SaveChanges();
                    TempData["EditMsg"] = "<script>alert('Düzenleme işlemi başarıyla tamamlandı.')</script>";
                    return RedirectToAction("List", "Urun");
                }

            }
            catch (Exception)
            {
                TempData["EditErrorMsg"] = "<script>alert('Düzenleme işlemi sırasında hata oluştu.')</script>";
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                Urunler urun = db.Urunler.Where(x => x.Id == id).FirstOrDefault<Urunler>();
                db.Urunler.Remove(urun);
                db.SaveChanges();
                TempData["DeleteMsg"] = "<script>alert('Silme işlemi başarıyla tamamlandı.')</script>";
                return RedirectToAction("List", "Urun");
            }
            catch (Exception)
            {
                TempData["DeleteErrorMsg"] = "<script>alert('Silme işlemi sırasında hata oluştu.')</script>";
                return View();
            }  
        }
        
        public ActionResult Stok(int id)
        {
            Urunler urun = db.Urunler.Where(x => x.Id == id).FirstOrDefault<Urunler>();
            return View();
        }
        [HttpPost]
        public ActionResult Stok(/*[FromBody]*/ Urunler urun)
        {
            //ürünü çek db den id den
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            string komut = "select * from Urunler where Id=" + urun.Id;
            SqlCommand cmd = new SqlCommand(komut, con);
            con.Open();
            SqlDataReader adr = cmd.ExecuteReader();
            while (adr.Read())
            {
                urun.Id = Convert.ToInt32(adr["Id"]);
                urun.UrunAdi = adr["UrunAdi"].ToString();
                urun.Description = adr["Description"].ToString();
                urun.Stok = Convert.ToInt32(adr["Stok"]);
                urun.Tarih = Convert.ToDateTime(adr["Tarih"]);
            }
            // ürün stoktan requeste gelen stoğu çıkar
            int temp = Convert.ToInt32(urun.StokTemp);
            int stock = Convert.ToInt32(urun.Stok.Value);
            int result = stock - temp;
            
            //ürünü db den update et
            urun.Stok = Convert.ToDouble(result);
            urun.Tarih = DateTime.Now;
            db.Entry(urun).State = EntityState.Modified;
            db.SaveChanges();
            con.Close();
            return RedirectToAction("List", "Urun");
        }
    }
}