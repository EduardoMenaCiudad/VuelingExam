using Microsoft.AspNetCore.Builder;

namespace GNB_EduardoMenaCiudad.Middleware
{
    public static class MiddlewareExtensionMethods
    {
        public static void ConfigureExceptionCustomMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
