using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Barcaliente.Domain.Abstract;
using Barcaliente.Domain.Entities;
using Barcaliente.WebUI.Areas.Administration.Models;

namespace Barcaliente.WebUI.Areas.Administration.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        //
        // GET: /Administration/Menu/

        private IMealRepository _mealRepository;

        public MenuController(IMealRepository mealRepo)
        {
            _mealRepository = mealRepo;
        }

        public ActionResult Index()
        {
            MenuAdministrationModel menuAdministrationModel = new MenuAdministrationModel { Meals = _mealRepository.Meals.Where(meal => !meal.IsDeleted), NewMeal = new Meal() };

            return View(menuAdministrationModel);
        }
        [HttpPost]
        public JsonResult Edit(string pk, string value, string name)
        {
            try
            {
                if (_mealRepository.Edit(pk, value, name))
                {
                    Response.StatusCode = (int)HttpStatusCode.OK;

                    return new JsonResult { Data = new { message = "Udało się zapisać zmiany ;)" } };
                }
            }
            catch (FormatException)
            {
                Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                return new JsonResult();                      
            }
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return new JsonResult();                      
        }


        [HttpPost]
        public JsonResult Delete(string stringMealId)
        {
            int intMealId = int.MinValue;
            if (Int32.TryParse(stringMealId, out intMealId))
            {
                if (_mealRepository.Delete(intMealId))
                {
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return new JsonResult { Data = new { message = "Udało się usunąc danie :)" } };
                }
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return new JsonResult();
            }
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return new JsonResult();
        }

        [HttpPost]
        public JsonResult Add(Meal meal)
        {
            if (ModelState.IsValid)
            {
                if (_mealRepository.Save(meal))
                {
                    Response.StatusCode = (int)HttpStatusCode.OK;                    
                    return new JsonResult { Data = new {message = "Udało się dodać nowe danie :)", meal = meal} };
                }
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult();
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return new JsonResult();
        }
    }
}
