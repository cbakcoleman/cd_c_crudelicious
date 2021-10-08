using System;
using System.ComponentModel.DataAnnotations;

namespace cd_c_crudelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get;set;}

        [Required(ErrorMessage = "Chef Name required.")]
        [Display(Name = "Chef Name: ")]
        public string ChefName {get;set;}

        [Required(ErrorMessage = "Dish Name required.")]
        [Display(Name = "Dish Name: ")]
        public string DishName {get;set;}

        [Required(ErrorMessage = "Calories required.")]
        [Display(Name = "Calories: ")]
        [Range(0,9999)]
        public int Calories {get; set;}

        [Required(ErrorMessage = "Tastiness rating required.")]
        [Display(Name = "How tasty is it?!: ")]
        [Range(0,5)]
        public int? Tastiness {get;set;}

        [Required(ErrorMessage = "Description required.")]
        [Display(Name = "Description: ")]
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}