using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ToolWebApp.Domain;
using ToolWebApp.Service;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace ToolWebApp.Controllers
{
    public class TurretController : Controller
    {

        TurretService turretService = new TurretService();
        // GET: Turret
        public ActionResult GetAll()
        {
            var turret = turretService.GetAll(); 
            return View(turret);
        }
        [System.Web.Mvc.Route("Turret/{id}/Detail")]
        public ActionResult Detail(string id)
        {
            var turret = turretService.GetById(id);
            if (turret != null)
            {
                return View("Detail", turret);
            }


            return View("GetAll");
        }

        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Turret turret)
        {
            turretService.Add(turret);
            ViewBag.Message = "Turret inserito";
            return View();
        }



        [HttpGet]
        public ActionResult Edit(string id)
        {
            var data = turretService.GetById(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Turret turret)
        {
            if (turret != null)
            {
                turretService.Modify(turret);
                ViewBag.Message = "Turret modificato";
                return View();
            }
            return RedirectToAction("GetAll");
        }

        public ActionResult Delete(string id)
        {
            turretService.Remove(id);
            ViewBag.Message = "Turret eliminato";
            return RedirectToAction("GetAll");
        }
    }
    
}