using Blog.UI.App_Start;
using CKSource.CKFinder.Connector.Config;
using CKSource.CKFinder.Connector.Core.Acl;
using CKSource.CKFinder.Connector.Core.Builders;
using CKSource.CKFinder.Connector.Host.Owin;
using CKSource.FileSystem.Local;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
[assembly:OwinStartup(typeof(Blog.UI.App_Classes.Startup))]
namespace Blog.UI.App_Classes
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            FileSystemFactory.RegisterFileSystem<LocalStorage>();
            app.Map("/ckfinder/connector", SetupConnector);
        }
        private static void SetupConnector(IAppBuilder app)
        {
            var connectorFactory = new OwinConnectorFactory();
            var connectorBuilder = new ConnectorBuilder();

            var customAuthenticator = new CKFinderAuthenticator();

            connectorBuilder.LoadConfig().SetAuthenticator(customAuthenticator).SetRequestConfiguration((request, config) => {
                 config.LoadConfig();
            });

            var connector = connectorBuilder.Build(connectorFactory);

            app.UseConnector(connector);
        }
    }
}