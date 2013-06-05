using Barcaliente.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Barcaliente.Domain.Concrete;
using Barcaliente.WebUI.Models;
using Barcaliente.Domain.Entities;

namespace Barcaliente.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IMealRepository _mealRepository;
        private IPromotionRepository _promotionRepository; 

        public HomeController(IMealRepository mealRepository, IPromotionRepository promotionRepository)
        {
            _mealRepository = mealRepository;
            _promotionRepository = promotionRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Menu()
        {
            return View();
        }

        public ViewResult MenuCategory(string categoryName)
        {
            List<Meal> mealsInCategory = _mealRepository.Meals.Where(m => m.Category == categoryName && m.IsDeleted == false).OrderBy(m => m.Order).ToList();
            if (mealsInCategory.Count() > 0)
            {
                int mealsCategoryByThree = SplitMealsInCategoryInThreeEqualParts(mealsInCategory.Count());
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

        private static int SplitMealsInCategoryInThreeEqualParts(int mealsInCategory)
        {
            int mealsCategoryByThree = mealsInCategory / 3;
            if (mealsInCategory % 3 != 0)
            {                
                mealsCategoryByThree++;
            }
            return mealsCategoryByThree;
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
            return View(_promotionRepository.Promotions.Where(p => p.Active == true));
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
