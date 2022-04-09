using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template_Login.Db_Connect;
using Template_Login.Models;

namespace Template_Login.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            EMPLOYEEINFOEntities obj = new EMPLOYEEINFOEntities();
            List<EmpModel> empobj = new List<EmpModel>();
            var res = obj.EMPLOYEEs.ToList();
            foreach (var item in res)
            {
                empobj.Add(new EmpModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Mobile = item.Mobile,
                    Salary = item.Salary
                });
            }
            return View(empobj);
        }
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult About(EmpModel empobj)
        {
            EMPLOYEEINFOEntities obj = new EMPLOYEEINFOEntities();
            EMPLOYEE tblobj = new EMPLOYEE();
            tblobj.Id = empobj.Id;
            tblobj.Name = empobj.Name;
            tblobj.Email = empobj.Email;
            tblobj.Mobile = empobj.Mobile;
            tblobj.Salary = empobj.Salary;
            if (empobj.Id== 0)
            {
                obj.EMPLOYEEs.Add(tblobj);
                obj.SaveChanges();
            }
            else
            {
                obj.Entry(tblobj).State = System.Data.Entity.EntityState.Modified;
                obj.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
            
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            EMPLOYEEINFOEntities obj = new EMPLOYEEINFOEntities();
            var deleteitem = obj.EMPLOYEEs.Where(m => m.Id==id).First();
            obj.EMPLOYEEs.Remove(deleteitem);
            obj.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            EmpModel empobj = new EmpModel();
            EMPLOYEEINFOEntities obj = new EMPLOYEEINFOEntities();
            var edit = obj.EMPLOYEEs.Where(m => m.Id == id).First();
            
            
                empobj.Id = edit.Id;
                empobj.Name = edit.Name;
                empobj.Email = edit.Email;
                empobj.Mobile = edit.Mobile;
                empobj.Salary = edit.Salary;

            //ViewBag.Id = edit.Id;
            
             return View("About",empobj);
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}