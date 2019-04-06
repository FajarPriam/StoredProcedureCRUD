using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using StoredProcedureCRUD.Models;

namespace StoredProcedureCRUD.Controllers
{
    public class SuppliersController : Controller
    {
        Data_Access.DB context = new Data_Access.DB();

        // GET: Suppliers
        public ActionResult Index()
        {
            DataSet ds = context.show_data();
            ViewBag.spl = ds.Tables[0];
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(FormCollection fc)
        {
            Supplier supplier = new Supplier();
            supplier.Name = fc["Name"];
            supplier.CreateDate = DateTimeOffset.Now.LocalDateTime;
            context.add_record(supplier);
            TempData["msg"] = "Inserted";
            return View();
        }
        public ActionResult Update(int id)
        {
            DataSet ds = context.show_record_byid(id);
            ViewBag.record = ds.Tables[0];
            return View();
        }
        [HttpPost]
        public ActionResult Update(int id, FormCollection fc)
        {
            Supplier supplier = new Supplier();
            supplier.Id = id;
            supplier.Name = fc["Name"];
            context.update_record(supplier);
            TempData["msg"] = "Updated";
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            context.delete_record(id);
            TempData["msg"] = "Deleted";
            return RedirectToAction("Index");
        }
    }
}