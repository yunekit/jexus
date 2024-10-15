# OWIN Web应用程序示例

这是一个不依赖 ASP.NET 框架环境的“纯OWIN”Web应用程序示例，可直接在 Jexus 和 TinyFox 上运行，简单调整后也能在 IIS 上运行。

**一、示例目的**

- 展示如何开发一个具有 OwinMain 方法的“适配器”，让 Jexus 驱动基于微软OWIN接口标准开发的 WEB 程序。
- 了解基于OWIN标准的WEB程序的开发基本特点。

**二、示例功能：**

- WebApi
- SignalR

**三、部署过程：**

1. 在VS中，将该项目发布到开发机的某个目标文件夹中；
2. 将目标文件夹中的所有文件上传到 Jexus 所在的服务器上的某个网站文件夹内；
3. 在 Jexus 的siteconf文件夹中新建一个网站配置文件，将网站文件夹路径填到root项中；
4. 在上一步的网站配置文件中添加一行，设定含用 OwinMain 方法的“适配器”所在的dll名称，如：OwinMain=OwinTest.dll
5. 重启 jexus 或单独启动这个网站
6. 尝试访问这个网站
