using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 矩形選択
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Model.Visible = true;

            var p = CursorInfo.GetNowPosition(this);
            var loc = this.PointFromScreen(this.PointToScreen(new Point(0, 0)));

            m_TopLeft = new Point(p.X - loc.X, p.Y - loc.Y);

            Model.Left = (int)m_TopLeft.X;
            Model.Top = (int)m_TopLeft.Y;
            Model.Height = 0;
            Model.Width = 0;
        }

        private void Window_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (Model.Visible)
            {
                var p = CursorInfo.GetNowPosition(this);
                var loc = this.PointFromScreen(this.PointToScreen(new Point(0, 0)));

                Model.Width = (int)((p.X - loc.X) - m_TopLeft.X);
                Model.Height = (int)((p.Y - loc.Y) - m_TopLeft.Y);
            }
        }

        private void Window_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Model.Visible = false;
        }

        private ViewModel Model
        {
            get { return this.DataContext as ViewModel; }
        }

        private Point m_TopLeft;
    }
}
