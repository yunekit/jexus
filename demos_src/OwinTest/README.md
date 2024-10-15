# OWIN Web应用程序示例

这是一个不依赖 ASP.NET 环境的“纯OWIN”Web应用程序示例，可直接在Jexus和TinyFox上运行，简单调整后也能在IIS上运行。

**示例功能：**

- WebApi
- SignalR

**部署过程：**

1. 在VS中，将该项目发布到开发机的某个目标文件夹中
2. 将目标文件夹中的所有文件上传到Jexus所在的服务器上的某个网站文件夹内
3. 在Jexus上新建一个网站配置文件，将配置文件中的root项指向这个网站文件夹
4. 在上一步的配置文件中添加一行，内容是：OwinMain=OwinTest.dll
5. 重启jexus或单独启动这个网站
6. 尝试访问这个网站
