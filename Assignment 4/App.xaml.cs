using Assignment_4.Controller;
using Assignment_4.Model;
using Assignment_4.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Assignment_4
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void OnStartup(Object sender, StartupEventArgs e)
        {
            IController controller = new MyController();
            IModel model = new MyModel(controller);
            controller.setModel(model);
            IView mainWindow = new MainWindow(controller);
            controller.setView(mainWindow);
            mainWindow.display();
        }
    }
}
