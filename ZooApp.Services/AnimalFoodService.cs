using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModel;

namespace ZooApp.Services
{
    public class AnimalFoodService
    {
        ZooContext db = new ZooContext();
        public List<ViewFoodTotal> GetViewFoodTotal()
        {
            //LINQ CODE

            IQueryable<IGrouping<int, AnimalFood>> animalFoodGroup = db.AnimalFoods.GroupBy(x => x.FoodId);

            IQueryable<ViewFoodTotal> foodTotals = from foodGroup in animalFoodGroup
                                                   let food = foodGroup.FirstOrDefault()
                                                   let totalQuantity = foodGroup.Sum(x => x.Animals.Quantity * x.Quantity)
                                                   select new ViewFoodTotal
                                                   {
                                                       FoodPrice = food.Food.Price,
                                                       FoodName = food.Food.Name,
                                                       TotalQuantity = totalQuantity,
                                                       TotalPrice = totalQuantity * food.Food.Price,
                                                       Id = food.Id,
                                                       FoodId = food.FoodId

                                                   };
            return foodTotals.ToList();


        }


        public List<ViewFoodAnimalTotal> GetViewFoodTotalsByFood(int FoodId)
        {
            var animalFoods = db.AnimalFoods.Where(f => f.FoodId == FoodId);

            var totals = animalFoods.Select(animalFood => new ViewFoodAnimalTotal(){

                Id = animalFood.Id,
                AnimalName = animalFood.Animals.Name,
                TotalQuantity = animalFood.Quantity * animalFood.Animals.Quantity,
                TotalPrice = animalFood.Quantity * animalFood.Animals.Quantity * animalFood.Food.Price


            }).ToList();
            return totals;
        }
    }
}
