using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Barcaliente.Domain.Entities
{
    public class Meal
    {
        public int MealID { get; set; }
        [Required(ErrorMessage="Proszę podaj nazwę")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage="Proszę podaj cenę")]
        [Range(0.01, double.MaxValue, ErrorMessage="Cena powinna wynosić conajmniej 1 grosz.")]
        public decimal Price { get; set; }
        public string ImageName { get; set; }
        [Required(ErrorMessage = "Proszę podaj kategorię")]
        public string Category { get; set; }
        public int Order { get; set; }
        public bool IsDeleted { get; set; }
    }
}
