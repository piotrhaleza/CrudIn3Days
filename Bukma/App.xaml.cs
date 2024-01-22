using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using Bukma.Factories;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Bukma
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            CurrentApp = this;
            Container = Startups.Configure();
        }

        public static IContainer Container { get; set; }

        public static App CurrentApp { get; set; }

        

    }
}
