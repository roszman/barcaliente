﻿using Barcaliente.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barcaliente.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IMealRepository repository;

        public HomeController(IMealRepository mealRepository)
        {
            repository = mealRepository;
        }

        public ActionResult Index()
        {
            return View(repository.Meals.ToArray());
        }

        public ViewResult Menu()
        {
            return View();
        }

    }
}
