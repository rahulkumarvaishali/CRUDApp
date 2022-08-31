using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Database;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Table()
        {
            RajaEntities obj = new RajaEntities();
            var tbldata = obj.RajTbls.ToList();
            List<Test> clsobj = new List<Test>();
            foreach (var tbl in tbldata)
            {
                clsobj.Add(new Test
                {
                    Id = tbl.Id,
                    Name = tbl.Name,
                    Email = tbl.Email,
                    Salary=tbl.Salary,
                    Mobile=tbl.Mobile,
                    Pincode=tbl.Pincode
                });
            }
            return View(clsobj);
        }

        public ActionResult Delete(int Id)
        {
            RajaEntities delobj = new RajaEntities();
            var delitem= delobj.RajTbls.Where(m=>m.Id==Id).First();
            delobj.RajTbls.Remove(delitem);
            delobj.SaveChanges();
            return RedirectToAction("Table");
        }

        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        public ActionResult Form(Test obj)
        {
            RajaEntities rajaEntities = new RajaEntities();
            RajTbl tblobj = new RajTbl();

            tblobj.Id = obj.Id;
            tblobj.Name = obj.Name;
            tblobj.Email = obj.Email;
            tblobj.Salary = obj.Salary;
            tblobj.Mobile = obj.Mobile;
            tblobj.Pincode = obj.Pincode;
            if (obj.Id == 0)
            {
                rajaEntities.RajTbls.Add(tblobj);
                rajaEntities.SaveChanges();
            }
            else
            {
                rajaEntities.Entry(tblobj).State=System.Data.Entity.EntityState.Modified;
                rajaEntities.SaveChanges();
            }
            return RedirectToAction("Form");
        }

        public ActionResult Edit(int Id)
        {
            RajaEntities dbObjs = new RajaEntities();
            var edititem=dbObjs.RajTbls.Where(m=>m.Id==Id).First();
            RajTbl objcls = new RajTbl();

            objcls.Id = edititem.Id;
            objcls.Name = edititem.Name;
            objcls.Email = edititem.Email;
            objcls.Salary = edititem.Salary;
            objcls.Mobile = edititem.Mobile;
            objcls.Pincode = edititem.Pincode;

            return View("Form", objcls);

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
