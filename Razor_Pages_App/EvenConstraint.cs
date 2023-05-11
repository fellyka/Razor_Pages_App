using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using System;

namespace Razor_Pages_App
{
    public class EvenConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            int id;

            //RouteValueDictionary is a dictionary and from this parameter, we can read the value from the url by the value binding mechanism
            if (Int32.TryParse(values["id"].ToString(), out id))
            {
                if(id % 2 == 0) { return true; }
            }

            return false;

        }
    }
}
