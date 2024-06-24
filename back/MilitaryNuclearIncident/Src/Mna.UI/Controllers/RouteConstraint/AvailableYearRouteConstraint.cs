using MilitaryNuclearAccident.Src.Mna.Common.Enum;

namespace MilitaryNuclearAccident.Src.Mna.UI.Controllers.RouteConstraint
{
    public class AvailableYearRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var matchingValue = values[routeKey].ToString();
            return System.Enum.TryParse(matchingValue, true, out AvailableYear _);
        }
    }

}
