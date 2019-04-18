using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetEtMechant.Data;
using BetEtMechant.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BetEtMechant.Controllers
{
    public class AccountController : BaseController
    {

        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, BetDbContext context) : base(context)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Birthdate = model.BirthDate,
                    Lastname = model.Name,
                    Firstname = model.Firstname
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if(result.Succeeded)
                {
                    DisplayMessage("Utilisateur créé", Class.TypeMessage.SUCCESS);
                    return RedirectToAction("index", "home");
                }
                else
                {
                    ModelState.AddModelError("", result.ToString());
                }

            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var resultat = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (resultat.Succeeded)
                {
                    if (!string.IsNullOrWhiteSpace(returnUrl))
                        return Redirect(returnUrl);

                    DisplayMessage("Vous êtes connecté", Class.TypeMessage.SUCCESS);
                    return RedirectToAction("index", "home");
                }

                if (resultat.IsLockedOut)
                {
                    ModelState.AddModelError("", "Le compte est bloqué.");
                }
                else
                {
                    ModelState.AddModelError("", "Email / mot de passe invalide");
                }

            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            DisplayMessage("Vous êtes déconnecté", Class.TypeMessage.DANGER);
            return RedirectToAction("index", "home");
        }

    }
}
