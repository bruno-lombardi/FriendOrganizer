using Autofac;
using FriendOrganizer.Startup;
using System;
using System.Windows;

namespace FriendOrganizer
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();
            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }

        private void Application_DispatcherUnhandledException(object sender, 
            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Unexpected error occured. We're sorry, inform app administrator."
                + Environment.NewLine + e.Exception.Message, "Unexpected error");

            e.Handled = true;
        }
    }
}
