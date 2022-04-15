using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SMECommerce.App.Models.Auth;
using SMECommerce.Models.EntityModels.Identity;

namespace SMECommerce.App.Controllers
{
    public class AuthController : Controller
    {
        SignInManager<AppUser> _SignInManager;
        UserManager<AppUser> _UserManager;
        IPasswordHasher<AppUser> PasswordHasher;
        IConfiguration configuration;
        public AuthController(SignInManager<AppUser> _SignInManager, UserManager<AppUser> _UserManager, IPasswordHasher<AppUser> PasswordHasher, IConfiguration configuration)
        {
            this._SignInManager = _SignInManager;
            this._UserManager = _UserManager;
            this.PasswordHasher = PasswordHasher;
            this.configuration = configuration;
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn( LogInViewModel model)
        {
            var user =await  _UserManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                var result =await _SignInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Register");
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new AppUser()
                {
                    UserName = model.Email,
                    Email=model.Email

                };

                var result =await  _UserManager.CreateAsync(user, model.password);
                if (result.Succeeded)
                {
                    return RedirectToAction("LogIn");
                }
            }
            return View("Index","Home");
        }
        [HttpPost]
        public async Task<IActionResult> Token([FromBody]LogInViewModel model)
        {
            var user =await _UserManager.FindByNameAsync(model.UserName);
            if(user!=null)
            {
                //verify password
               var result= PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
                if (result == PasswordVerificationResult.Success)
                {

                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                    var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    //var userClaims = await _UserManager.GetClaimsAsync(user);


                    //var claims = new Claim[]
                    //{
                    //    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    //    new Claim(JwtRegisteredClaimNames.GivenName, user.UserName),
                    //    new Claim(JwtRegisteredClaimNames.Jti, (new Guid()).ToString())

                    //}.Union(userClaims);


                    var token = new JwtSecurityToken(
                        issuer: configuration["Jwt:Issuer"],
                        audience: configuration["Jwt:Issuer"],
                        claims: null,
                        expires: DateTime.Now.AddMinutes(120),
                        signingCredentials: signingCredentials
                        );


                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(new { token = tokenString, expires = token.ValidTo });

                }


            }

            return BadRequest("User or Password could not match, please check");

        }
    }
                
}

