using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooApp.Models;
using ZooApp.Services;
using ZooApp.ViewModels;

namespace ZooApp.Mvc.Controllers
{
    public class AnimalController : Controller
    {
        AnimalService service = new AnimalService();
       
        // GET: Animal
        public ActionResult Index()
        {
            var viewAnimals = service.GeAll();
            return View(viewAnimals);
        }


        public ActionResult Details(int id)
        {
           ViewAnimal animals= service.Get(id);
            return View(animals);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Animals animal)
        {
            //save
            if (ModelState.IsValid)
            {
                bool saved = service.Save(animal);
                return RedirectToAction("Index");
            }
            return View(animal);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
             Animals animals= service.GetDbModel(id);
            return View(animals);
        }

        [HttpPost]
        public ActionResult Edit(Animals animal)
        {
            //update
            bool saved = service.Update(animal);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            return View(service.GetDbModel(id));
        }

        [HttpPost]
        public ActionResult Delete(Animals animal)
        {
            //delete
            bool saved = service.Delete(animal);
            return RedirectToAction("Index");
        }
    }
}