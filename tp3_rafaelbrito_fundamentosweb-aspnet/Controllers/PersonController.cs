using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tp3_rafaelbrito_fundamentosweb_aspnet.Models;


namespace tp3_rafaelbrito_fundamentosweb_aspnet.Controllers
{
    public class PersonController : Controller
    {
        public static List<Person> People { get; set; } = new List<Person>();
        
        public ActionResult Index()
        {
            return View(People);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var person = People.FirstOrDefault(x => x.Id == id);
            return View(person);
        }

        public ActionResult Edit(int id)
        {
            var pessoa = People.FirstOrDefault(x => x.Id == id);
            return View(pessoa);
        }

        public ActionResult Search()
        {
            return View(PeopleFound);
        }

        [HttpPost]
        
        public ActionResult Edit(int id, string firstName, string lastName, string birthday)
        {
            try
            {
                var person = People.FirstOrDefault(x => x.Id == id);

                People.Remove(person);

                person.Id = id;

                DateTime birthdayConverted = Convert.ToDateTime(birthday);

                Person updatedPerson = new Person(id, firstName, lastName, birthdayConverted.Date);

                People.Add(updatedPerson);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult New(string firstName, string lastName, string birthday)
        {
            try
            {
                if (ModelState.IsValid == false) return View();

                DateTime birthdayConverted = Convert.ToDateTime(birthday);

                int id = People.Count() + 1;

                Person person = new Person(id, firstName, lastName, birthdayConverted.Date);

                People.Add(person);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var person = People.FirstOrDefault(x => x.Id == id);
                People.Remove(person);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
