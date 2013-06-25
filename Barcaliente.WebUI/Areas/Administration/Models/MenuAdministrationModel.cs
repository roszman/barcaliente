using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Barcaliente.Domain.Entities;
namespace Barcaliente.WebUI.Areas.Administration.Models
{
    public class MenuAdministrationModel
    {
        public Meal NewMeal { get; set; }
        public IEnumerable<Meal> Meals { get; set; }
    }
}