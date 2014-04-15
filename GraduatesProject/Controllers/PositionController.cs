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
    public class PositionController : Controller
    {
        private GraduatesEntityModel graduatesEntity;

        public PositionController()
        {
             graduatesEntity= new GraduatesEntityModel();
        }

        //
        // GET: /Position/

        public ActionResult Index()
        {
            return View(graduatesEntity.Positions.ToList());
        }

        //
        // GET: /Position/Details/5

        public ActionResult Details(int id = 0)
        {
            Position position = graduatesEntity.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        //
        // GET: /Position/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Position/Create

        [HttpPost]
        public ActionResult Create(Position position)
        {
            if (ModelState.IsValid)
            {
                graduatesEntity.Positions.Add(position);
                graduatesEntity.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(position);
        }

        //
        // GET: /Position/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Position position = graduatesEntity.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        //
        // POST: /Position/Edit/5

        [HttpPost]
        public ActionResult Edit(Position position)
        {
            if (ModelState.IsValid)
            {
                graduatesEntity.Entry(position).State = EntityState.Modified;
                graduatesEntity.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(position);
        }

        //
        // GET: /Position/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Position position = graduatesEntity.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        //
        // POST: /Position/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Position position = graduatesEntity.Positions.Find(id);
            graduatesEntity.Positions.Remove(position);
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