using System;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;

[assembly: OwinStartup(typeof(Service.App_Start.Startup))]

namespace Service.App_Start
{
    public class Startup
    {
            public void Configuration(IAppBuilder app)
            {
                // Enable CORS (cross origin resource sharing) for making request using browser from different domains
                app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

                OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
                {
                    AllowInsecureHttp = true,
                    //The Path For generating the Toekn
                    TokenEndpointPath = new PathString("/token"),
                    //Setting the Token Expired Time (24 hours)
                    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                    //MyAuthorizationServerProvider class will validate the user credentials
                    Provider = new MyAuthorizationServerProvider()
                };
                //Token Generations
                app.UseOAuthAuthorizationServer(options);
                app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

                HttpConfiguration config = new HttpConfiguration();
                WebApiConfig.Register(config);
            
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
