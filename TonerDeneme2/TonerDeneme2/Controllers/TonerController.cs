using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TonerDeneme2.Models;

namespace TonerDeneme2.Controllers
{
    public class TonerController : Controller
    {
        TonerStokEntities1 db = new TonerStokEntities1();
        // GET: Toner
        public ActionResult Index(Tonerler toner)
        {
            return View(db.Tonerlers.ToList());
        }


        // GET: Toner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Toner/Create
        [HttpPost]
        public ActionResult Create(Tonerler toner)
        {
            try
            {
                // TODO: Add insert logic here
                toner.Tarih = DateTime.Now;
                db.Tonerlers.Add(toner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Toner/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.Tonerlers.Where(x => x.Id == id).FirstOrDefault());
        }

        // POST: Toner/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Tonerler toner)
        {
            try
            {
                // TODO: Add update logic here
                toner.Tarih = DateTime.Now;
                db.Entry(toner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Toner/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Tonerler toner = db.Tonerlers.Where(x => x.Id == id).FirstOrDefault();
                db.Tonerlers.Remove(toner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }            
        }        
    }
}
