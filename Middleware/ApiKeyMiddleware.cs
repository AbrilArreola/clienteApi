namespace ClienteApi.Middleware
{
    /// Verifica la api-key en el header dado.
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string HeaderName = "X-API-KEY";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IConfiguration config)
        {
            /// Validador en caso de no haber api key.
            if (!context.Request.Headers.TryGetValue(HeaderName, out var key))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key requerida.");
                return;
            }

            var apiKey = config.GetValue<string>("ApiKey");
            /// Validador en caso de que la api ky sea incorrecta.
            if (key != apiKey)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key inválida.");
                return;
            }

            await _next(context);
        }
    }

    public static class ApiKeyMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiKeyMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ApiKeyMiddleware>();
        }
    }
}
