namespace CkmBvIntegration.API.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetBearerToken(this HttpContext httpContext)
        {
            var bearerToken = httpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (string.IsNullOrEmpty(bearerToken))
            {
                return null;
            }

            if (bearerToken.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                return bearerToken["Bearer ".Length..].Trim();
            }

            return null;
        }
    }
}
