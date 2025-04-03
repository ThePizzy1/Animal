using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{
    public partial class Food
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Name { get; set; }
        public string FoodType { get; set; }
        public string AnimalType { get; set; }
        public string AgeGroup { get; set; }
        public decimal Weight { get; set; }
        public string MeasurementWeight { get; set; }
        public decimal CaloriesPerServing {  get; set; }
        public decimal WeightPerServing { get;set; }
        public string MeasurementPerServing { get; set; }
        public decimal FatContent { get; set; }
        public decimal FiberContent { get; set; }
        public DateTime ExporationDate { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public decimal Price { get; set; }
    }
}
