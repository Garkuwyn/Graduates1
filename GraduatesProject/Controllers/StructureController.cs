using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GraduatesProject.DAL;

namespace GraduatesProject.Controllers
{
    public class StructureController : Controller
    {
        private GraduatesEntityModel graduatesEntity;

        public StructureController()
        {
                 graduatesEntity = new GraduatesEntityModel();
        }
        //
        // GET: /Structure/

        public ActionResult Index()
        {
            return View(graduatesEntity.Structures.ToList());
        }

        //
        // GET: /Structure/Details/5

        public ActionResult Details(int id = 0)
        {
            Structure structure = graduatesEntity.Structures.Find(id);
            if (structure == null)
            {
                return HttpNotFound();
            }
            return View(structure);
        }

        //
        // GET: /Structure/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Structure/Create

        [HttpPost]
        public ActionResult Create(Structure structure)
        {
            if (ModelState.IsValid)
            {
                graduatesEntity.Structures.Add(structure);
                graduatesEntity.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(structure);
        }

        //
        // GET: /Structure/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Structure structure = graduatesEntity.Structures.Find(id);
            if (structure == null)
            {
                return HttpNotFound();
            }
            return View(structure);
        }

        //
        // POST: /Structure/Edit/5

        [HttpPost]
        public ActionResult Edit(Structure structure)
        {
            if (ModelState.IsValid)
            {
                graduatesEntity.Entry(structure).State = EntityState.Modified;
                graduatesEntity.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(structure);
        }

        //
        // GET: /Structure/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Structure structure = graduatesEntity.Structures.Find(id);
            if (structure == null)
            {
                return HttpNotFound();
            }
            return View(structure);
        }

        //
        // POST: /Structure/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Structure structure = graduatesEntity.Structures.Find(id);
            graduatesEntity.Structures.Remove(structure);
            graduatesEntity.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            graduatesEntity.Dispose();
            base.Dispose(disposing);
        }
    }
}