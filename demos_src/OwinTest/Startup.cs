using Owin;
using System.Web.Http;

namespace OwinTest
{
    public class Startup
    {
        public void Configuration(IAppBuilder appbuilder)
        {

            var config = new HttpConfiguration();
            ApiRouteConfig(config.Routes);
            appbuilder.UseWebApi(config);
            appbuilder.MapSignalR(); //path: /signalr
        }



        void ApiRouteConfig(HttpRouteCollection routes)
        {
            //忽略的路径
            routes.IgnoreRoute("ignore1", "{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute("default.", "api/{controller}/{id}", new { id = RouteParameter.Optional });

        }

    }



}