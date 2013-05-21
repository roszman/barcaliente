using Barcaliente.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Barcaliente.Domain.Concrete;
using Barcaliente.WebUI.Models;

namespace Barcaliente.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IMealRepository _repository;

        public HomeController(IMealRepository mealRepository)
        {
            _repository = mealRepository;
        }

        public ActionResult Index()
        {
            return View(_repository.Meals.ToArray());
        }

        public ViewResult Menu()
        {
            return View();
        }

        public ViewResult MenuCategory(string categoryName)
        {
            List<Meal> mealsInCategory = _repository.Meals.Where(m => m.Category == categoryName).ToList();
            if (mealsInCategory.Count() > 0)
            {
                int mealsCategoryByThree = mealsInCategory.Count() / 3;
                List<Meal>[] mealsInCategoryViewThreeColumns = new List<Meal>[3];

                mealsInCategoryViewThreeColumns[0] = mealsInCategory.Take(mealsCategoryByThree).ToList();
                mealsInCategoryViewThreeColumns[1] = mealsInCategory.Skip(mealsCategoryByThree).Take(mealsCategoryByThree).ToList();
                mealsInCategoryViewThreeColumns[2] = mealsInCategory.Skip(mealsCategoryByThree * 2).ToList();

                return View(new MenuCategoryViewModel {CategoryName = categoryName, MealsInCategoryViewThreeColumns = mealsInCategoryViewThreeColumns });
            }
            else
            {
                return View("NoMealsIncategory", null, categoryName);
            }
            
        }

        public ViewResult Contact()
        {
            return View();
        }

        public ViewResult NightOrders()
        {
            return View();
        }

        public ViewResult Promotions()
        {
            return View();
        }

        public ViewResult SpecialOrders()
        {
            return View();
        }

        public ViewResult Gallery()
        {
            return View();
        }

        public ViewResult Work()
        {
            return View();
        }



    }
}
