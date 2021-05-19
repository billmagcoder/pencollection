using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pens.Core.Models;
using Pens.Core.Services;

namespace Pens.Web.Controllers
{
    public class PensController : Controller
    {
        private readonly IPen _db;

        public PensController(IPen db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _db.GetAll();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _db.GetPen(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _db.GetPen(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Pen pen)
        {
            if (ModelState.IsValid)
            {
                await _db.UpdatePen(pen);
                return RedirectToAction("Details",new {id = pen.Id});
            }
            return View(pen);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Pen pen)
        {
            if (ModelState.IsValid)
            {
                await _db.AddPen(pen);
                return RedirectToAction("Details", new {id = pen.Id});
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _db.GetPen(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _db.DeletePen(id);
            return RedirectToAction("Index");
        }
    }
}
