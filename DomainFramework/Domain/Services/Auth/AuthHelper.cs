using Base_Framework.Domain.Core.Contracts;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Base_Framework.Domain.Services.Auth
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public async Task<long> CurrentAccountId(CancellationToken cancellationToken)
        {
            return await IsAuthenticated(cancellationToken)
               ? long.Parse(_contextAccessor.HttpContext.User.Claims.First(x => x.Type == "AccountId")?.Value)
               : 0;
        }

        public async Task<AuthDTO> CurrentAccountInfo(CancellationToken cancellationToken)
        {
            var result = new AuthDTO();
            if (!await IsAuthenticated(cancellationToken))
                return result;

            var claims = _contextAccessor.HttpContext.User.Claims.ToList();
            result.Id = long.Parse(claims.FirstOrDefault(x => x.Type == "AccountId").Value);
            result.Username = claims.FirstOrDefault(x => x.Type == "Username").Value;
            result.RoleId = long.Parse(claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value);
            result.Fullname = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            return result;
        }

        public async Task<string> CurrentAccountMobile(CancellationToken cancellationToken)
        {
            return await IsAuthenticated(cancellationToken)
              ? _contextAccessor.HttpContext.User.Claims.First(x => x.Type == "Mobile")?.Value
                : "";
        }

        public async Task<string> CurrentAccountRole(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<int>> GetPermissions(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsAuthenticated(CancellationToken cancellationToken)
        {
            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public async Task Signin(AuthDTO account, CancellationToken cancellationToken)
        {
            var claims = new List<Claim>
            {
                new Claim("AccountId", account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.Fullname),
                new Claim(ClaimTypes.Role, account.RoleId.ToString()),
                new Claim("Username", account.Username), 
                new Claim("Mobile", account.Mobile)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
            };

            _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public async Task SignOut(CancellationToken cancellationToken)
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
