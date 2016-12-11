using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace 矩形選択
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var wnd = new MainWindow();
            wnd.DataContext = new ViewModel();
            this.MainWindow = wnd;
            this.MainWindow.ShowDialog();
        }
    }
}
