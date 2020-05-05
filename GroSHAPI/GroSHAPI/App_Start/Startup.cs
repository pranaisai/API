using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;
using System.Web;

[assembly: OwinStartup(typeof(GroSHAPI.App_Start.Startup))]

namespace GroSHAPI.App_Start
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			//SignalR configuration method
			var ctx = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
			//var root = ctx + "/ItemImages";
			var hubConfiguration = new HubConfiguration();
			hubConfiguration.EnableDetailedErrors = true;
			hubConfiguration.EnableJavaScriptProxies = false;

			app.MapSignalR(ctx+"/signalr", hubConfiguration);
			// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
			app.UseCors(CorsOptions.AllowAll);
			OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
			{

				TokenEndpointPath = new PathString("/api/Login"),
				Provider = new ApplicationAuthProvider(),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays(365),
				AllowInsecureHttp = true
			};
			app.UseOAuthAuthorizationServer(option);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
		}
	}
}
