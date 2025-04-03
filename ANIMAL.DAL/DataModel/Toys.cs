using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{
    public partial class Toys
    {
        public int Id { get; set; }
        public string BrandName {  get; set; }
        public string Name { get; set; }
        public string AnimalType { get; set; }
        public string ToyType { get; set; }
        public string AgeGroup { get; set; }
        public decimal Hight { get; set; }
        public decimal Width { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public decimal Price {  get; set; }

    }
}
