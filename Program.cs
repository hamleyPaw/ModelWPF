using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMTemplate.Services;
using MVVMTemplate.ViewModels;
using MVVMTemplate.Views;
using SimpleInjector;


namespace MVVMTemplate
{
    static class Program
    {
        [STAThread]
        public static void Main()
        {
            var container = Bootstrap();

            RunApplication(container);
        }

        private static Container Bootstrap()
        {
            var container = new Container();

            container.Register<IInteractionService, InteractionService>(Lifestyle.Singleton);
            container.Register<IWidgetCreatorServant, WidgetCreatorServant>(Lifestyle.Transient);

            container.Register<MainView>();
            container.Register<MainViewModel>();

            container.Register<WidgetView>();
            container.Register<IWidgetViewModel, WidgetViewModel>();

            container.Register<IDialogService<WidgetView>, DialogService<WidgetView>>();

            container.Verify();

            return container;
        }

        private static void RunApplication(Container container)
        {
            try
            {
                var app = new App();

                app.DependencyContainer = container;

                var mainWindow = container.GetInstance<MainView>();
                app.Run(mainWindow);
            }
            catch (Exception ex)
            {
                //Log the exception and exit
            }
        }
    }
}
