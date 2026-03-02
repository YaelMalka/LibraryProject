using Libary.MiddleWare;

namespace Libary
{
    public static class Extentions
    {
        public static IApplicationBuilder UseShabbatMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ShabbatMiddleWare>();
        }
    }
}
