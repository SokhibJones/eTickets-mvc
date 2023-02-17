using eTickets.Data;
using eTickets.Data.Statics;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ApplicationDbContext dbContext;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> UsersAsync()
        {
            var users = await dbContext.Users.ToListAsync();
            return View(users);
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = await userManager.FindByEmailAsync(login.Email);
            if (user != null)
            {
                bool validPassword = await userManager.CheckPasswordAsync(user, login.Password);
                if (validPassword)
                {
                    var result = await signInManager.PasswordSignInAsync(user, login.Password, isPersistent: false, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(actionName: "Index", controllerName: "Movies");
                    }
                }
            }

            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(login);
        }

        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            var user = await userManager.FindByEmailAsync(register.Email);
            if (user != null)
            {
                TempData["Error"] = $"An account with email {register.Email} already exists";
                return View(register);
            }

            var newUser = new ApplicationUser
            {
                FullName = register.FullName,
                Email = register.Email,
                UserName = register.Email.ToLower()
            };

            var response = await userManager.CreateAsync(newUser, register.Password);
            if (response.Succeeded)
            {
                await userManager.AddToRoleAsync(newUser, UserRole.User);
            }
            else
            {
                foreach (var error in response.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(register);
            }

            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(actionName: "Index", controllerName: "Movies");
        }
    }
}
