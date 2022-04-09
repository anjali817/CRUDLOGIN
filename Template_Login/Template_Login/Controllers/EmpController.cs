using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Template_Login.Db_Connect;
using Template_Login.Models;

namespace Template_Login.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Loginmodel empobj)
        {
            EMPLOYEEINFOEntities dbobj = new EMPLOYEEINFOEntities();
            var resdata = dbobj.logins.Where(m => m.Email == empobj.Email).FirstOrDefault();
            if(resdata==null)
            {
                TempData["invalid"] = "Inavalid Email";
            }
            else
            {
                if(resdata.Email==empobj.Email && resdata.Password==empobj.Password)
                {
                    FormsAuthentication.SetAuthCookie(resdata.Email, false);

                    Session["email"] = resdata.Email;
                    return RedirectToAction("Dashboard", "Emp");
                }
                else
                {
                    TempData["pass"] = "invalid Password";
                }
            }
            return View();
        }
        [Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}