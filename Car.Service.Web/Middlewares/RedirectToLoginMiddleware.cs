namespace Vehicle.Service.Tracking.Middlewares
{
    public class RedirectToLoginMiddleware
    {
        private readonly RequestDelegate _next;

        public RedirectToLoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Kullanıcı kimlik doğrulaması yapılmamışsa ve oturumda belirli bir anahtar yoksa
            if (!context.User.Identity.IsAuthenticated &&
                !context.Request.Path.StartsWithSegments("/Login/Index") &&
                !context.Request.Path.StartsWithSegments("/api") &&
                !context.Request.Path.StartsWithSegments("/Login/Login") && // Login POST metodunu göz ardı et
                string.IsNullOrEmpty(context.Session.GetString("Username"))
                )
            {
                context.Response.Redirect("/Login/Index");
                return;
            }

            await _next(context);
        }
    }
}
