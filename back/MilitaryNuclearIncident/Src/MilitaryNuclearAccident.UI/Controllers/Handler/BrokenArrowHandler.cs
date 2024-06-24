using System.Data.Common;
using System.Net;

namespace BrokenArrowApp.Src.BrokenArrowApp.UI.Controllers.Handler
{
    public class BrokenArrowHandler(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DbException ex)
            {
                var response = context.Response;
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.ContentType = "application/json";
                await response.WriteAsync(ex.Message);
            }
        }
    }
}
