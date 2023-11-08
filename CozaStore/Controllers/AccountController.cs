using CozaStore.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CozaStore.Data;
using System.Net.Mail;

namespace CozaStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _contexto;

        public AccountController(
            ILogger<AccountController> logger,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            AppDbContext contexto)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _contexto = contexto;
        }

        public IActionResult Login(string returnUrl)
        {
            LoginVM login = new()
            {
                UrlRetorno = returnUrl ?? Url.Content("~/")
            };
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (ModelState.IsValid)
            {
                string userName = login.Email;
                if (IsValidEmail(login.Email))
                {
                    var user = await _userManager.FindByEmailAsync(login.Email);
                    if (user !=null )
                        userName = user.UserName;
                }

                var result = await _signInManager.PasswordSignInAsync(
                  userName, login.Senha, login.Lembrar, lockoutOnFailure: true
                );

                if(result.Succeeded)
                {
                    _logger.LogInformation($"Usuario {login.Email} acessou o sistema");
                    return LocalRedirect(login.UrlRetorno);
                }
                if(result.IsLockedOut)
                {
                    _logger.LogWarning($"Usuario {login.Email} está bloqueado");
                    return RedirectToAction("Lockout");
                }
                ModelState.AddModelError(string.Empty, "Usuario e/ou senha invalidos !");

            }
            return View(login);
        }

        public static bool IsValidEmail(string email)
        {
            try{
                MailAddress mail = new(email);
                return true;
            } catch {
                return false;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}