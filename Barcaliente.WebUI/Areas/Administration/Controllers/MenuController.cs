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
            IEnumerable<Meal> meals = _mealRepository.Meals.Where(meal => !meal.IsDeleted);

            return View(meals);
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
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new JsonResult { Data = "Ojojoj, ktoś tu podał dane w złym formacie..." };                      
            }
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return new JsonResult { Data = "Stało się coś mrocznego..." };                      
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
                return new JsonResult { Data = "Danie o takim Id nie istnieje." };
            }
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return new JsonResult { Data = "Stało się coś mrocznego..." };
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
                return new JsonResult { Data = "Stało się coś mrocznego" };
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return new JsonResult { Data = ModelState.Values.SelectMany(v => v.Errors) };
        }
    }
}
