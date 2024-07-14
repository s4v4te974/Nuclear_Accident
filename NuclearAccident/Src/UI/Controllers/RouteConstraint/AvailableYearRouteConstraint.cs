using NuclearAccident.Src.Common.Enum;

namespace NuclearAccident.Src.UI.Controllers.RouteConstraint
{
    public class AvailableYearRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var matchingValue = values[routeKey] != null ? values[routeKey]?.ToString() : "notokay";
            return System.Enum.TryParse(matchingValue, true, out AvailableYear _);
        }
    }
}
