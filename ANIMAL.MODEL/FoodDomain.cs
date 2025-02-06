using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{
    public class FoodDomain
    {
        public FoodDomain() { }
        public FoodDomain(int id, string brandName, string name, string foodType, string animalType, string ageGroup, decimal weight, decimal caloriesPerServing, decimal weightPerServing, string measurementPerServing, decimal fatContent, decimal fiberContent, DateTime exporationDate, int quantity, string notes)
        {
            Id = id;
            BrandName = brandName;
            Name = name;
            FoodType = foodType;
            AnimalType = animalType;
            AgeGroup = ageGroup;
            Weight = weight;
            CaloriesPerServing = caloriesPerServing;
            WeightPerServing = weightPerServing;
            MeasurementPerServing = measurementPerServing;
            FatContent = fatContent;
            FiberContent = fiberContent;
            ExporationDate = exporationDate;
            Quantity = quantity;
            Notes = notes;
        }
        public FoodDomain(int id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Name { get; set; }
        public string FoodType { get; set; }
        public string AnimalType { get; set; }
        public string AgeGroup { get; set; }
        public decimal Weight { get; set; }
        public decimal CaloriesPerServing { get; set; }
        public decimal WeightPerServing { get; set; }
        public string MeasurementPerServing { get; set; }
        public decimal FatContent { get; set; }
        public decimal FiberContent { get; set; }
        public DateTime ExporationDate { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
    }
}
