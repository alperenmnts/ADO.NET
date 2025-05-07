using EmployeeApp.DAL;
using EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL empDAL = new EmployeeDAL();
        public ActionResult List()
        {
            var data = empDAL.GetEmployees();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if (empDAL.InsertEmployee(emp))
            {
                TempData["InsertMsg"] = "<script>alert('Ekleme işlemi başarıyla tamamlandı.')</script>";
                return RedirectToAction("List");
            }
            else
            {
                TempData["InsertErrorMsg"] = "<script>alert('Ekleme işlemi sırasında hata oluştu.')</script>";
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            EmployeeDAL emp = new EmployeeDAL();
            return View(emp.GetEmployees(id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            if (empDAL.UpdateEmployee(emp))
            {
                TempData["UpdateMsg"] = "<script>alert('Güncelleme işlemi başarıyla tamamlandı.')</script>";

                return RedirectToAction("List");
            }
            else
            {
                TempData["UpdateErrorMsg"] = "<script>alert('Güncelleme işlemi sırasında hata oluştu.')</script>";
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            EmployeeDAL toner = new EmployeeDAL();
            if (empDAL.DeleteEmployee(id))
            {
                TempData["DeleteMsg"] = "<script>alert('Silme işlemi başarıyla tamamlandı.')</script>";
                return RedirectToAction("List");
            }
            else
            {
                TempData["DeleteErrorMsg"] = "<script>alert('Silme işlemi sırasında hata oluştu.')</script>";
            }
            return View();
        }
    }
}