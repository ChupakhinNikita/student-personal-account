using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using webApp.Models;
using Microsoft.EntityFrameworkCore;
using webUniversity.Models;

namespace webApp.Controllers
{
    public class AccountController : Controller
    {

        private UniversityContext _context;

        public AccountController(UniversityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // находим пользователя 
               User? user = await _context.Users.FirstOrDefaultAsync(u => u.login == model.login && u.password == model.password);

                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    if (user.role == "Администратор")
                    {
                        return RedirectToAction("Admin", "Home");
                    }
                    else if (user.role == "Студент")
                    {
                        return RedirectToAction("Student", "Home");
                    }
                    else if (user.role == "Преподователь")
                    {
                        return RedirectToAction("Teacher", "Home");
                    }
                }
                else 
                {
                    ModelState.AddModelError("Name", "Некорректные логин и(или) пароль");
                }
            }
            return View(model);
        }
        private async Task Authenticate(User user)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.login),
                new Claim(ClaimTypes.Role, user.role),
                new Claim("userID" , user.userID.ToString())
            };
            // создаем объект ClaimsIdentity
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(claimsPrincipal);
        }

        [HttpGet]
        public async Task<IActionResult> Logout() 
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

    }
}
