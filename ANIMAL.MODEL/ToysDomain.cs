using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.MODEL
{
    public class ToysDomain
    {
        public ToysDomain() { }

        public ToysDomain(int id, string brandName, string name, string animalType, string toyType, string ageGroup, decimal hight, decimal width, int quantity, string notes)
        {
            Id = id;
            BrandName = brandName;
            Name = name;
            AnimalType = animalType;
            ToyType = toyType;
            AgeGroup = ageGroup;
            Hight = hight;
            Width = width;
            Quantity = quantity;
            Notes = notes;
        }

        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Name { get; set; }
        public string AnimalType { get; set; }
        public string ToyType { get; set; }
        public string AgeGroup { get; set; }
        public decimal Hight { get; set; }
        public decimal Width { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
    }
}
