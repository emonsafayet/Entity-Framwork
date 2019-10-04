﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;

namespace ZooApp.ViewModel
{

    public class ViewFoodAnimalTotal
    {
        public ViewFoodAnimalTotal()
        {

        }
        public ViewFoodAnimalTotal(AnimalFood animalFood)
        {
            Id = animalFood.Id;
            AnimalName = animalFood.Animals.Name;
            TotalQuantity = animalFood.Quantity * animalFood.Animals.Quantity;
            TotalPrice = TotalQuantity * animalFood.Food.Price;


        }

        public int Id { get; set; }

        public double TotalQuantity { get; set; }

        public double TotalPrice { get; set; }

        public string AnimalName { get; set; }
    }
}
