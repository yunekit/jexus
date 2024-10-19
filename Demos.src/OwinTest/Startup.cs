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
        /// <param name="builder"></param>
        public void Configuration(IAppBuilder builder)
        {
            //实例化http/webapi配置
            var httpCconf = new HttpConfiguration();
            //配置webapi路由
            ApiRouteConfig(httpCconf.Routes);

            //根据配置启用WebApi支持
            builder.UseWebApi(httpCconf);

            //启用SignalR并默认映射到“/signalr”路径上
            builder.MapSignalR();
        }


        /// <summary>
        /// WebApi路由配置
        /// </summary>
        /// <param name="routes">路由集合</param>
        void ApiRouteConfig(HttpRouteCollection routes)
        {
            //忽略的路径
            routes.IgnoreRoute("ignore1", "{resource}.axd/{*pathInfo}");
            
            //默认配置
            routes.MapHttpRoute("default.", "api/{controller}/{id}", new { id = RouteParameter.Optional });

        }

    }



}