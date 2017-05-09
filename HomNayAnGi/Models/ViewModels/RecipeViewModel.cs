using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomNayAnGi.Models.ViewModels
{
    public class RecipeViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int authorId { get; set; }
        public int dishId { get; set; }
        public string status { get; set; }
        public double rating { get; set; }
        public int rateQuantity { get; set; }
        public int viewQuantity { get; set; }
        public DateTime dateCreated { get; set; }
        public string type { get; set; }
        public decimal price { get; set; }
        public DateTime? dateApproved { get; set; }

        public AccountViewModel AccountViewModel { get; set; }
        public DishViewModel DishViewModel { get; set; }
    }
}