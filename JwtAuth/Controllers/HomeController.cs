using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JwtAuth.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;

namespace JwtAuth.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Login()
        {
            ViewData["Message"] = "Login Page.";

            return View();
        }
        [HttpPost]
        public IActionResult Login(string loginid, string password)
        {
            if(loginid=="raju" && password == "123456")
            {

                var claims = new List<Claim>
                            {
                                new Claim("Id","101".ToString()),
                                new Claim(ClaimTypes.Name,"Raju".ToString()),
                                new Claim("LoginId",loginid.ToString()),
                                new Claim(ClaimTypes.Role,"*"),
                            };
                var key = Encoding.ASCII.GetBytes("YourKey-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv");
                //Generate Token for user - JRozario
                var JWToken = new JwtSecurityToken(
                    issuer: "https://localhost:44348/",
                    audience: "https://localhost:44348/",
                    claims: claims,
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
                    //Using HS256 Algorithm to encrypt Token - JRozario
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                );
                var token = new JwtSecurityTokenHandler().WriteToken(JWToken);

                if (token != null)
                {
                    //Save token in session object
                    HttpContext.Session.SetString("JWToken", token);
                }

                return RedirectToAction(nameof(HomeController.Contact), "Home");
            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Login), "Home");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
