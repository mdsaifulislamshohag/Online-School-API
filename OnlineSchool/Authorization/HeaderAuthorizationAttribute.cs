using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace Authorization
{
   [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
   public class HeaderAuthorizationAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            JWT_Auth jWT = new JWT_Auth();

            if (!context.HttpContext.Request.Headers.TryGetValue("ApiKey", out var potentialApiKey))
            {
               
            }

            if (!jWT.ValidateToken(potentialApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            else
            {
                
                  ///  context.HttpContext.Session.SetString("JWT_Token", potentialApiKey);
                
                    var jwt = potentialApiKey;
                    var handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(jwt);
                    context.HttpContext.Session.SetString("Subject", token.Subject);
                
                  ///  Console.WriteLine(token.Subject);
                 
            }
           

            await next();
        }
    }
}
