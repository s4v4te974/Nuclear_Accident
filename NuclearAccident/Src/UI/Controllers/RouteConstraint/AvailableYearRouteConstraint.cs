using NuclearIncident.Src.Common.Enum;

namespace NuclearIncident.Src.UI.Controllers.RouteConstraint
{
    public class AvailableYearRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var matchingValue = values[routeKey] != null ? values[routeKey]?.ToString() : "notokay";
            return Enum.TryParse(matchingValue, true, out AvailableYear _);
        }
    }
}
