using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Barcaliente.Domain.Abstract;
using Barcaliente.Domain.Entities;
using System.Security.Cryptography;
using Barcaliente.WebUI.Infarstructure.Abstract;
namespace Barcaliente.WebUI.Areas.Administration.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        private IUserRepository _userRepository;
        private IAuthProvider _authorisationProvider;

        public AccountController(IUserRepository userRepo, IAuthProvider authProvider)
        {
            _userRepository = userRepo;
            _authorisationProvider = authProvider;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User providedUser, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                bool userIsValid = _authorisationProvider.AuthenticateAndLogIn(providedUser.UserName, providedUser.Password);

                if (userIsValid)
                {

                    if (UrlIsValid(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Menu", new { area = "Administration" });
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name  or password is incorrect");
                }
            }

            return View(providedUser);
        }

        private bool UrlIsValid(string returnUrl)
        {
            return Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\");
        }

        public ActionResult LogOff()
        {
            _authorisationProvider.LogOff();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
