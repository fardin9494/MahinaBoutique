﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace _0_SelfBuildFramwork.Application
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public long AuthenticatedAccountId()
        {
            if (!IsAuthenticated())
            {
                return 0;
            }
          var AccountId = long.Parse( _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "AccountId").Value);
            return AccountId;
        }

        public string AuthenticatedName()
        {
            if (!IsAuthenticated())
            {
                return null;
            }

            var Fullname = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value.ToString();
            return Fullname;
        }

        public List<int> AuthenticatedPermissions()
        {
            if (!IsAuthenticated())
            {
                return new List<int>();
            }

            var Permissions = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Permission").Value;
            return JsonConvert.DeserializeObject<List<int>>(Permissions);
        }

        public string AuthenticatedRole()
        {
            if (!IsAuthenticated())
            {
                return null;
            }
            var RoleId = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            return RoleId;
        }

        public bool IsAuthenticated()
        {
            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
            //var claims = _contextAccessor.HttpContext.User.Claims.ToList();
            ////if (claims.Count > 0)
            ////    return true;
            ////return false;
            //return claims.Count > 0;
        }

        public void SignIn(AuthViewModel account)
        {
            var PermissionString = JsonConvert.SerializeObject(account.Permissions);
            var claims = new List<Claim>
            {
                new Claim("AccountId", account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.FullName),
                new Claim(ClaimTypes.Role, account.RoleId.ToString()),
                new Claim(ClaimTypes.NameIdentifier, account.UserName),
                new Claim("Permission",PermissionString)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(2)
            };

            _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public void SignOut()
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}