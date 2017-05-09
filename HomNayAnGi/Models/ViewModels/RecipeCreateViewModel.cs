using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomNayAnGi.Models.ViewModels
{
    public class RecipeCreateViewModel
    {
        public string name { get; set; }
        public int dishId { get; set; }
        public decimal price { get; set; }
        public int type { get; set; }
        public int authorId { get; set; }

        public StepCreateViewModel[] Step { get; set; }
        public MaterialUnitViewModel[] Material { get; set; }
    }
}