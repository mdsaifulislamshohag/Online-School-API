using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineSchool.Models;
using ViewModel;

namespace OnlineSchool.Controllers
{
 
  ///  [ApiController]
    public class CreateTokenController : Controller
    {

        private readonly DatabaseContext _context;

        public CreateTokenController(DatabaseContext context)
        {
            _context = context;
        }
        [Route("api/GenerateToken")]
        [HttpPost]
        public async Task<ActionResult> GenerateToken(TokenDetails tokenDetails)
        {
            if(!ModelState.IsValid)
            {
                return Json(new { success = false, error = "Input Formate is not Satisfiying" });
            }

            JWT_Auth jwt = new JWT_Auth();

            var verify_Email = await _context
                .Authorizations
                .Where(x => x.Email == tokenDetails.Email)
                .FirstOrDefaultAsync();

            if (verify_Email != null)
            {
                return Json(new { success = false, error = "This Email is Already in use" });
            }

            var auth = new Models.Authorization()
            {
                Email = tokenDetails.Email,
                Company_Name = tokenDetails.CompanyName,
                JWT_Token = "",
            };

            _context.Authorizations.Add(auth);
            await _context.SaveChangesAsync();

            var Auth_By_Email = await _context.Authorizations
                .Where(x => x.Email == auth.Email)
                .FirstOrDefaultAsync();

            String access_token = jwt.GenerateToken((Auth_By_Email.AuthID).ToString(), tokenDetails.Email, tokenDetails.CompanyName);

            Auth_By_Email.JWT_Token = access_token;
            await _context.SaveChangesAsync();

            return Json(new { success=true , Token=access_token});
        }

       
        [Authorize(Roles = "Provider" , AuthenticationSchemes = "Provider")]
        [Route("RefreshToken/{AuthID}")]
        [HttpPut]
        public async Task<ActionResult> RefreshToken(int AuthID)
        {
            var data = await _context.Authorizations
                .Where(x => x.AuthID == AuthID)
                .FirstOrDefaultAsync();

            if (data == null)
            {
                return Json(new { success = false, newToken = "Error" });
            }

            JWT_Auth jwt = new JWT_Auth();

            String newToken = jwt.GenerateToken((AuthID).ToString(),data.Email, data.Company_Name);

            data.JWT_Token = newToken;

            await _context.SaveChangesAsync();

            return Json(new { success = true, newToken = newToken });
        }
        
    }
  
}