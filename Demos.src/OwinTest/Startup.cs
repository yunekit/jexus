using Owin;
using System.Web.Http;

namespace OwinTest
{
    /// <summary>
    /// OWIN启动配置类
    /// </summary>
    public class Startup
    {

        /// <summary>
        /// OWIN配置
        /// </summary>
        /// <param name="appbuilder"></param>
        public void Configuration(IAppBuilder appbuilder)
        {
            var config = new HttpConfiguration();
            ApiRouteConfig(config.Routes);

            //启用WebApi支持
            appbuilder.UseWebApi(config);

            //启用SignalR并默认映射到“/signalr”路径上
            appbuilder.MapSignalR();
        }


        /// <summary>
        /// WebApi路由配置
        /// </summary>
        /// <param name="routes"></param>
        void ApiRouteConfig(HttpRouteCollection routes)
        {
            //忽略的路径
            routes.IgnoreRoute("ignore1", "{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute("default.", "api/{controller}/{id}", new { id = RouteParameter.Optional });

        }

    }



}