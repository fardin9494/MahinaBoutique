using _0_SelfBuildFramwork.Application;
using _0_SelfBuildFramwork.Infrastracture;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ServiceHost
{
    public class SecurityPageFilter : IPageFilter
    {
        private readonly IAuthHelper _authHelper;

        public SecurityPageFilter(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var ContentPermission = (NeedPermissionAttribute)context.HandlerMethod.MethodInfo.GetCustomAttribute(typeof(NeedPermissionAttribute));
            
            var accuntpermission = _authHelper.AuthenticatedPermissions();

            if(ContentPermission != null)
            {
                if (!accuntpermission.Contains(ContentPermission.PermissionCode))
                    {
                        context.HttpContext.Response.Redirect("/AccessDenied");
                    }
            }

        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
           
        }
    }
}
