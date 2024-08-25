using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading.Tasks;
using Vehicle.Service.Tracking.Models;
using Car.Service.Web.Business.Abstract;
using Car.Service.Web.Data.Entities;

namespace Car.Service.Web.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcı doğrulama işlemi (örneğin, veritabanı kontrolü)
                var isValidUser = ValidateUser(model.Username, model.Password);

                if (isValidUser)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Username)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    // Başarılı yanıt döndür
                    return Json(new { success = true });
                }

                // Başarısız yanıt döndür
                return Json(new { success = false });
            }

            // Model doğrulama hatası durumunda başarısız yanıt döndür
            return Json(new { success = false });
        }

        private bool ValidateUser(string username, string password)
        {
         var user = _userService.SearchUsersAsync(u => u.Username == username && u.Password == password).Result.FirstOrDefault();

            if (user != null)
            {
                return true;
            }

            return false;
        }
    }
}
