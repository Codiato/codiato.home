/*
 * This controller has not unit tests.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Codiato.Home.WebUI.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult CreateUsername(string username, string password, string email)
        {
            Membership.CreateUser(username, password, email);

            return Content("Is in place");
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string username, string password, bool remember, string returnUrl)
        {
            if (Membership.ValidateUser(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, remember);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("CreatePost", "BlogPanel");
                }
            }
            else
            {
                ModelState.AddModelError("", "The username or password was incorrect.");
            }

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Blog", "Index");
        }
			
    }
}
