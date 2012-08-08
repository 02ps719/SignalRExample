using System;
using System.Web;
using System.Web.Routing;
using Core;
using FubuCore;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap;

namespace Interface
{
    public class TestFubuApplication : HttpApplication
    {
        private static SignalRRegistry _signalRRegistry;

        private FubuRegistry GetMyRegistry()
        {
            return new TestFubuRegistry();
        }

        private static void InitializeStructureMap(IInitializationExpression ex)
        {
            ex.AddRegistry<MassTransitRegistry>();
            ex.AddRegistry<CoreRegistry>();

            _signalRRegistry = new SignalRRegistry();
            ex.AddRegistry(_signalRRegistry);
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            ObjectFactory.Initialize(InitializeStructureMap);
            UrlContext.Reset();
            Bootstrap();

            _signalRRegistry.Configure();
        }

        public void Bootstrap()
        {
            FubuApplication.For(GetMyRegistry)
                .StructureMap(ObjectFactory.Container)
                .Bootstrap();
        }
    }
}
