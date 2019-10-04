using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ZooApp.Models;
using ZooApp.ViewModels;

namespace ZooApp.Services
{
    public class AnimalService
    {      
        ZooContext db = new ZooContext();

        public List<ViewAnimal> GeAll() {            
          
            List<Animals> animals=db.Animals.ToList();
           
            List<ViewAnimal> viewAnimals = new List<ViewAnimal>();

            foreach (Animals animal in animals) {
                ViewAnimal viewAnimal = new ViewAnimal(animal);               
                viewAnimals.Add(viewAnimal);
            }  

            return viewAnimals;

        }

        public ViewAnimal Get(int id)
        {
            Animals animals = db.Animals.Find(id);
            return new ViewAnimal(animals);
        }       

        public bool Save(Animals animal)
        {
            Animals add=db.Animals.Add(animal);
            db.SaveChanges();
            return true;
        }

        public bool Update(Animals animal)
        {
            db.Entry(animal).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }        

        public bool Delete(Animals animal)
        {
            Animals dbanimals = db.Animals.Find(animal.Id);
            db.Animals.Remove(dbanimals);
            db.SaveChanges();
            return true;
        }

        public Animals GetDbModel(int id)
        {
            return db.Animals.Find(id);
        }
    }
}
