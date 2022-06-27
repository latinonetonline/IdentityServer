
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;

namespace Project4.STS.Identity.Rules
{
    public static class RedirectToProxiedHttpsExtensions
    {
        public static RewriteOptions AddRedirectToProxiedHttps(this RewriteOptions options)
        {
            options.Rules.Add(new RedirectToProxiedHttpsRule());
            return options;
        }

        public static IApplicationBuilder UseRedirectToProxiedHttps(this IApplicationBuilder app)
        {
            RewriteOptions options = new();

            options.AddRedirectToProxiedHttps()
               .AddRedirect("(.*)/$", "$1");  // remove trailing slash
            app.UseRewriter(options);
            return app;
        }
    }
}
