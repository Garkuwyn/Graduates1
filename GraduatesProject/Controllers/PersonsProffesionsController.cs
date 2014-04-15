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
    public class PersonsProffesionsController : Controller
    {
        private GraduatesEntityModel graduatesEntity;

        public PersonsProffesionsController()
        {
            graduatesEntity = new GraduatesEntityModel();
        }

        //
        // GET: /PersonsProffesions/

        public ActionResult Index()
        {
            var personsproffesions = graduatesEntity.PersonsProffesions.Include(p => p.Person).Include(p => p.Position).Include(p => p.Structure);
            return View(personsproffesions.ToList());
        }

        //
        // GET: /PersonsProffesions/Details/5

        public ActionResult Details(int id = 0)
        {
            PersonsProffesion personsproffesion = graduatesEntity.PersonsProffesions.Find(id);
            if (personsproffesion == null)
            {
                return HttpNotFound();
            }
            return View(personsproffesion);
        }

        //
        // GET: /PersonsProffesions/Create

        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(graduatesEntity.Persons, "Id", "FirstName");
            ViewBag.PositionId = new SelectList(graduatesEntity.Positions, "Id", "PositionName");
            ViewBag.StructureId = new SelectList(graduatesEntity.Structures, "Id", "StructureName");
            return View();
        }

        //
        // POST: /PersonsProffesions/Create

        [HttpPost]
        public ActionResult Create(PersonsProffesion personsproffesion)
        {
            if (ModelState.IsValid)
            {
                graduatesEntity.PersonsProffesions.Add(personsproffesion);
                graduatesEntity.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonId = new SelectList(graduatesEntity.Persons, "Id", "FirstName", personsproffesion.PersonId);
            ViewBag.PositionId = new SelectList(graduatesEntity.Positions, "Id", "PositionName", personsproffesion.PositionId);
            ViewBag.StructureId = new SelectList(graduatesEntity.Structures, "Id", "StructureName", personsproffesion.StructureId);
            return View(personsproffesion);
        }

        //
        // GET: /PersonsProffesions/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PersonsProffesion personsproffesion = graduatesEntity.PersonsProffesions.Find(id);
            if (personsproffesion == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = new SelectList(graduatesEntity.Persons, "Id", "FirstName", personsproffesion.PersonId);
            ViewBag.PositionId = new SelectList(graduatesEntity.Positions, "Id", "PositionName", personsproffesion.PositionId);
            ViewBag.StructureId = new SelectList(graduatesEntity.Structures, "Id", "StructureName", personsproffesion.StructureId);
            return View(personsproffesion);
        }

        //
        // POST: /PersonsProffesions/Edit/5

        [HttpPost]
        public ActionResult Edit(PersonsProffesion personsproffesion)
        {
            if (ModelState.IsValid)
            {
                graduatesEntity.Entry(personsproffesion).State = EntityState.Modified;
                graduatesEntity.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonId = new SelectList(graduatesEntity.Persons, "Id", "FirstName", personsproffesion.PersonId);
            ViewBag.PositionId = new SelectList(graduatesEntity.Positions, "Id", "PositionName", personsproffesion.PositionId);
            ViewBag.StructureId = new SelectList(graduatesEntity.Structures, "Id", "StructureName", personsproffesion.StructureId);
            return View(personsproffesion);
        }

        //
        // GET: /PersonsProffesions/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PersonsProffesion personsproffesion = graduatesEntity.PersonsProffesions.Find(id);
            if (personsproffesion == null)
            {
                return HttpNotFound();
            }
            return View(personsproffesion);
        }

        //
        // POST: /PersonsProffesions/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonsProffesion personsproffesion = graduatesEntity.PersonsProffesions.Find(id);
            graduatesEntity.PersonsProffesions.Remove(personsproffesion);
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