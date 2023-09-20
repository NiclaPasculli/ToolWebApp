using System;
using System.Collections.Generic;
using System.Linq;


using System.Threading.Tasks;
using System.Web;

using System.Web.Mvc;
using ToolWebApp.Dao;
using ToolWebApp.Domain;
using ToolWebApp.Service;


namespace ToolWebApp.Controllers
{
    public class ToolController : Controller
    {
        ToolService toolService = new ToolService();




        //public ActionResult GetAll()
        //{
        //    var tool = toolService.GetAll();

        //    return View(tool);
        //}
        public async Task<ActionResult> GetAll()
        {
            var toolTask = toolService.GetAll();
            var tools = await toolTask;

            return View(tools);
        }




        public async Task<ActionResult> GetSaveModal(string id = null)
        {
          Tool tool;

            if (string.IsNullOrEmpty(id))
            {
                tool = new Tool();
            }
            else
            {
                tool = await toolService.GetById(id);
            }

            List<KeyValuePair<string, string>> turretCodes =  toolService.GetAllTurretCodes();
            SelectList turretCodeList = new SelectList(turretCodes, "Key", "Value");
            ViewBag.TurretCodeList = turretCodeList;

            return PartialView("Save", tool);
        }

        [HttpPost]
        public async Task<ActionResult> Save(string IdTool, string BoschCode, string Description, string PrimarySupplier, string SecondarySupplier, string PrimarySharpener, string SecondarySharpener, int? Quantity, string TurretCode)
        {
            Tool tool = new Tool()
            {
                IdTool = IdTool,
                BoschCode = BoschCode,
                Description = Description,
                PrimarySupplier = PrimarySupplier,
                SecondarySupplier = SecondarySupplier,
                PrimarySharpener = PrimarySharpener,
                SecondarySharpener = SecondarySharpener,
                Quantity = Quantity,
                TurretCode = TurretCode
            };

            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(tool.IdTool))
                {
                    ModelState.AddModelError("IdTool", "Inserire il valore del campo IdTool");
                }
                else if (tool.IdTool.Length < 1 || tool.IdTool.Length > 8)
                {
                    ModelState.AddModelError("IdTool", "Il valore del campo IdTool deve essere composto da 1 a 8 cifre");
                }

                if (string.IsNullOrEmpty(tool.BoschCode))
                {
                    ModelState.AddModelError("BoschCode", "Inserire il valore del campo BoschCode");
                }
                if (string.IsNullOrEmpty(tool.TurretCode))
                {
                    tool.TurretCode = null;
                }

                if (ModelState.IsValid)
                {
                    await toolService.SaveTool(tool);
                    var tools = await toolService.GetAll();
                    return View("GetAll", tools);
                }
            }

            List<KeyValuePair<string, string>> turretCodes = toolService.GetAllTurretCodes();
            SelectList turretCodeList = new SelectList(turretCodes, "Key", "Value");
            ViewBag.TurretCodeList = turretCodeList;

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return Json(new { success = false, errors = errors });
        }










        public async Task<ActionResult> Delete(string id)
        {
             await toolService.Remove(id);
            var tools = await toolService.GetAll();
            return PartialView("ToolTable", tools); 

        }




        public async Task<ActionResult> Detail(string id)
        {
            var tool = await toolService.GetById(id);

            if (tool != null)
            {
                ViewData["IsDetail"] = true;
                return View("Save", tool);
            }
            else
            {
                var tools = await toolService.GetAll();
                return View("GetAll", tools);
            }
        }


       


        public async Task<ActionResult> Search(string id, string turretCode)
        {
            var tools = await toolService.Search(id, turretCode);
            return PartialView("Search", tools);
        }
    }
}