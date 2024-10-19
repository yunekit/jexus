using System;
using System.Collections.Generic;
using Microsoft.Owin.Builder;
using System.Threading.Tasks;


namespace OwinTest
{
    /// <summary>
    /// Jexus OWIN适配器（也适用于TinyFox）
    /// </summary>
    public class JwsAdapter
    {
        /// <summary>
        /// Microsoft OWIN 处理管线入口函数
        /// </summary>
        static Func<IDictionary<string, object>, Task> _owinAppFunc;

        /// <summary>
        /// 一个处于取消状态的任务对象
        /// </summary>
        readonly static Task _canceledTask;



        /// <summary>
        /// 静态构造函数
        /// </summary>
        static JwsAdapter()
        {
            var tcs = new TaskCompletionSource<object>();
            tcs.SetCanceled();
            _canceledTask = tcs.Task;
        }

        /// <summary>
        /// 适本器构造函数
        /// </summary>
        public JwsAdapter()
        {
            //配置并构建OWIN处理管线
            var builder = new AppBuilder();
            new Startup().Configuration(builder);
            _owinAppFunc = builder.Build();
        }



        /// <summary>
        /// *** Jexus或TinyFox驱动OWIN所需要的关键函数 ***
        /// <para>每个请求到来，JWS/TinyFox都把请求打包成字典，通过这个函数提供给OWIN应用程序具体处理</para>
        /// </summary>
        /// <param name="env">新请求的环境字典</param>
        /// <returns>返回一个正在运行或已经完成的任务，返回取消表示不属于本OWIN，返回null表示中止处理</returns>
        public Task OwinMain(IDictionary<string, object> env)
        {

            if (_owinAppFunc == null) return null;

            //浏览器请求的路径
            var req_path = env["owin.RequestPath"] as string;


            //属于本OWIN应用处理的请求交给OWIN处理，其它的返回一个取消状态的Task。

            var isApiPath = req_path.StartsWith("/api/");
            var isSignalRPath = req_path.StartsWith("/signalr/");

            if (isApiPath || isSignalRPath)
            {
                //交给OWIN管道进行具体处理
                return _owinAppFunc(env);
            }
            else
            {
                //返回一个取消了的task对象，表示不属于本OWIN处理的路径
                return _canceledTask;
            }
        }

    }
}