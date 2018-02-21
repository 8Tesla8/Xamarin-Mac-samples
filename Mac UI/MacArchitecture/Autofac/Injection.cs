using System;
using Autofac;
using MacArchitecture.UiElements.Table.ViewFactory;

namespace MacArchitecture.Autofac {
    static partial class Injection {
        private static readonly IContainer Container;


        public static ILifetimeScope BeginLifetimeScope() {
            return Container.BeginLifetimeScope();
        }


        private static IContainer BuildContainer() {
            var builder = new ContainerBuilder();

            builder.RegisterType<ViewFactory>().As<IViewFactory>();

            return builder.Build();
        }


        static Injection() {
            Container = BuildContainer();
        }


        public static T Resolve<T>() {
            return Container.Resolve<T>();
        }


        public static T ResolveKeyed<T>(object serviceKey) {
            return Container.ResolveKeyed<T>(serviceKey);
        }
    }
}
