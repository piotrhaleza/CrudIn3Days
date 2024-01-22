using Autofac;
using Bukma.Factories;
using Bukma.ViewModels;
using Bukma.ViewModels.Windows;
using Bukma.Views.Windows;
using Data;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukma
{
    public static class Startups
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ViewModelFactory>().As<IViewModelFactory>();
            builder.RegisterType<ServicesFactory>().As<IServicesFactory>();
            builder.RegisterType<WindowFactory>().As<IWindowFactory>();

            builder.RegisterType<MainWindowViewModel>().AsSelf();
            builder.RegisterType<OrderViewModel>().AsSelf();
            builder.RegisterType<ClientWindowViewModel>().AsSelf();
            builder.RegisterType<ResultSavingWindowViewModel>().AsSelf();
            builder.RegisterType<ClientFiltrationWindowViewModel>().AsSelf();
            builder.RegisterType<ArticlesWindowViewModel>().AsSelf();
            builder.RegisterType<ListsWindowViewModel>().AsSelf();
            builder.RegisterType<NameFiltrationViewModel>().AsSelf();

            builder.RegisterType<ClientWindow>().AsSelf();
            builder.RegisterType<ResultSavingWindow>().AsSelf();
            builder.RegisterType<ClientFiltrationWindow>().AsSelf();
            builder.RegisterType<ListsWindow>().AsSelf();
            builder.RegisterType<NameFiltrationWindow>().AsSelf();

            builder.RegisterType<BaseContext>().AsSelf();
            builder.RegisterType<ClientService>().AsImplementedInterfaces();
            builder.RegisterType<ArticleService>().AsImplementedInterfaces();
            builder.RegisterType<OrderArticleService>().AsImplementedInterfaces();
            builder.RegisterType<OrderService>().AsImplementedInterfaces();

            return builder.Build();
        }
    }
}
