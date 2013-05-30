using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Barcaliente.Domain.Entities;

namespace Barcaliente.WebUI.Models
{
    public class MenuCategoryViewModel
    {
        public string CategoryName { get; set; }
        public List<Meal>[] MealsInCategoryViewThreeColumns { get; set; }
    }   
}