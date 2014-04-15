using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GraduatesProject.DAL;
namespace GraduatesProject.Controllers
{
    public class HomeController : Controller
    {
        private GraduatesEntityModel graduatesEntities;
        public HomeController()
        {
            graduatesEntities = new GraduatesEntityModel();
        }
        public ActionResult Index()
        {
            var students = graduatesEntities.Persons.ToList();
            return View(students);
        }

        public ViewResult GetAddEditForm()
        {
            ViewBag.Title = "Add";
            return View("AddEditPerson", new Person());
        }

        public ViewResult GetEditForm(int id)
        {
            var person = this.graduatesEntities.Persons.FirstOrDefault(a => a.Id == id);
            if (person == null)
            {
                return this.View("Error");
            }
            ViewBag.Title = "Edit";
            return View("AddEditPerson",person);
        }
        

        [HttpPost]
        public ActionResult AddEditPerson(Person person)
        {
            person.GroupId = 1;
            if (ModelState.IsValid)
            {
                if (person.Id > 0)
                {
                    var dbPerson = this.graduatesEntities.Persons.FirstOrDefault(a => a.Id == person.Id);
                    if (dbPerson != null)
                    {
                        dbPerson.FirstName = person.FirstName;
                        dbPerson.LastName = person.LastName;
                        dbPerson.Biography = person.Biography;
                        dbPerson.GraduateYear = person.GraduateYear;
                        dbPerson.GPAofCertificate = person.GPAofCertificate;
                        dbPerson.DiplomaPaperTopic = person.DiplomaPaperTopic;
                        dbPerson.SupervisorOfDiplomaPaper = person.SupervisorOfDiplomaPaper;
                        dbPerson.Email = person.Email;
                        dbPerson.Skype = person.Skype;
                        dbPerson.ActivityInStudent = person.ActivityInStudent;
                        dbPerson.HasWorkNow = person.HasWorkNow;
                        dbPerson.IsMarried = person.IsMarried;
                        dbPerson.ReviewsAboutInstitute = person.ReviewsAboutInstitute;
                        dbPerson.FundedByNBU = person.FundedByNBU;
                        dbPerson.GroupName = person.GroupName;
                        graduatesEntities.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }


                graduatesEntities.Persons.Add(person);
                graduatesEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddEditPerson",person);
        }

        public ActionResult GetProffesions(int id)
        {
            var personsproffesions = graduatesEntities.PersonsProffesions.Where(a=>a.PersonId==id).Include(p => p.Person).Include(p => p.Position).Include(p => p.Structure);
            return View(personsproffesions.ToList());
        }

       /* public ActionResult About()
        {
            ViewBag.Message = "Страница описания приложения.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Страница контактов.";

            return View();
        }*/
    }
}
