﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;

namespace ZooApp.ViewModel
{
    public class ViewFoodTotal
    {
        public ViewFoodTotal()
        {

        }
        public ViewFoodTotal(AnimalFood animalFood)
        {

            FoodName = animalFood.Food.Name;
            FoodPrice = animalFood.Food.Price;
            TotalQuantity = animalFood.Animals.Quantity *
                            animalFood.Quantity;
            TotalPrice = FoodPrice * TotalQuantity;
            Id = animalFood.Id;
            FoodId = animalFood.FoodId;

    }
        public int Id { get; set; }
        public int FoodId { get; set; }
        public string FoodName { get; set; } //OOP Concept
        public double FoodPrice { get; set; }
        public double TotalQuantity { get;  set; }
        public double TotalPrice { get;  set; }
    }
}
