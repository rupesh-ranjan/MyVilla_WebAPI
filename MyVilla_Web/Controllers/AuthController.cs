using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MyVilla_Utility;
using MyVilla_Web.Models;
using MyVilla_Web.Models.Dto;
using MyVilla_Web.Services.IServices;
using Newtonsoft.Json;
using System.Security.Claims;

namespace MyVilla_Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDTO loginRequestDTO = new();
            return View(loginRequestDTO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequestDTO)
        {
            APIResponse response = await _authService.LoginAsync<APIResponse>(loginRequestDTO);
            if (response != null && response.IsSuccess)
            {
                LoginResponseDTO loginResponseDTO = JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(response.Result));
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, loginResponseDTO.User.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, loginResponseDTO.User.Role));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                HttpContext.Session.SetString(SD.SessionToken, loginResponseDTO.Token);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomeError", response.ErrorMessages.FirstOrDefault());
                return View(loginRequestDTO);
            }
            
        }
        #endregion

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterationRequestDTO registerationRequestDTO)
        {
            APIResponse response = await _authService.RegisterAsync<APIResponse>(registerationRequestDTO);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        #endregion


        #region Logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString(SD.SessionToken, "");
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region AccessDenied
        [HttpGet]
        public IActionResult AccessDenied(RegisterationRequestDTO registerationRequestDTO)
        {
            return View();
        }
        #endregion
    }
}
