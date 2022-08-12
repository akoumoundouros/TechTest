namespace TechTest.Components.Auth
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        string[] _userList;


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            IServiceProvider services = context.HttpContext.RequestServices;
            AppConfig settings = services.GetService<AppConfig>();
            _userList = settings.AllowedUsers;

            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            var user = context.HttpContext.User.Identity;
            if (user == null || !IsAuthorizedUser(user.Name))
            {
                // not logged in - return 401 unauthorized
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }

        private bool IsAuthorizedUser(string username)
        {
            var nameIndex = username.LastIndexOf('\\') + 1;
            username = username.Substring(nameIndex, username.Length - nameIndex);
            return _userList.Contains(username);
        }
    }
}
