using CallCenter.Business.DTO;
using CallCenter.Business.UnitOfWork;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CallCenter.RestService.OAuth.Providers
{
    internal class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async System.Threading.Tasks.Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            
            byte[] data = System.Convert.FromBase64String(context.Password);
            string contextPass = System.Text.ASCIIEncoding.UTF8.GetString(data);
            
            data = System.Convert.FromBase64String(contextPass);
            contextPass = System.Text.ASCIIEncoding.UTF8.GetString(data);

            EmployeeDto employeeDto = Worker.EmployeeRepository.Read(context.UserName, contextPass);
            if (employeeDto != null && employeeDto.Id > 0)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));

                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Kullanıcı adı veya şifre yanlış.");
            }
        }
    }
}