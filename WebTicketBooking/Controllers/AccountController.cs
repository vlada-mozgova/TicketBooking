using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebTicketBooking.DAL;
using WebTicketBooking.DAL.Models;
using WebTicketBooking.Models.Account;

namespace WebTicketBooking.Controllers
{
    [Controller]
    public class AccountController : HomeController
    {
        private ApplicationContext _context;
        public AccountController(ApplicationContext context)
        {
            _context = context;
        }

        // Registration form display method
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Registration method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Username);

                if (user == null)
                {
                    user = new User { Username = model.Username, Email = model.Email, Password = model.Password };
                    if (model.Code == "smile")
                        user.RoleName = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "admin");
                    else
                        user.RoleName = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    await Authenticate(user);

                    return RedirectToAction("Login", "Account");
                }
                else
                    TempData["failReg"] = "User exists";
            }
            return View(model);
        }

        // Login form display method
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Login method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users
                    .Include(u => u.RoleName)
                    .FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                TempData["failLog"] = "Invalid username or password";
            }
            return View(model);
        }

        // Logout method
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        // Authentication method
        private async Task Authenticate(User user)
        {
            //создаем один claim
           var claims = new List<Claim>
           {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.RoleName?.Name)
           };
            //создаем объект ClaimsIdentity
           ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
               ClaimsIdentity.DefaultRoleClaimType);
            //установка аутентификационных куки
           await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        // Approve form display method
        [HttpGet]
        public IActionResult Approve()
        {
            return View();
        }

        // Approve method
        [HttpPost]
        public async Task<IActionResult> Approve(ApproveModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users
                    .Include(u => u.RoleName)
                    .FirstOrDefaultAsync(u => u.Username == GetUser());
                if (user != null && model.Code == "smile")
                {
                    user.RoleName = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "admin");
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        // Update username form display method
        [HttpGet]
        public IActionResult UpdateUser()
        {
            return View();
        }

        // Update username method
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserNameModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users
                    .Include(u => u.RoleName)
                    .FirstOrDefaultAsync(u => u.Username == GetUser());
                if (user != null && _context.Users.Any(x => x.Username != model.NewUserName))
                {
                    user.Username = model.NewUserName;
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");
                }
                TempData["failUsername"] = "Username exists";
            }
            return View(model);
        }

        // Update password form display method
        [HttpGet]
        public IActionResult UpdatePassword()
        {
            return View();
        }

        // Update password method
        [HttpPost]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users
                    .Include(u => u.RoleName)
                    .FirstOrDefaultAsync(u => u.Username == GetUser());
                if (user != null)
                {
                    user.Password = model.NewPassword;
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");
                }
                TempData["failPassword"] = "Ivalid password";
            }
            return View(model);
        }

        // Method of displaying a list of all users
        [HttpGet]
        public IActionResult GetAll()
        {
            var userlist = _context.Users.ToList();
            return View(userlist);
        }

        // Method of displaying a specific user
        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }
    }
}
