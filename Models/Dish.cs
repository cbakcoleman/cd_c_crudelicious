using System;
using System.ComponentModel.DataAnnotations;

namespace cd_c_crudelicious
{
    public class Dish
    {
        [Key]
        public int DishId {get;set;}
        public string ChefName {get;set;}
        public string DishName {get;set;}
        public int Calories {get; set;}
        public int Tastiness {get;set;}
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}