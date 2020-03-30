using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BallSpiel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _animationsTimer = new DispatcherTimer();
        private bool _gehtNachrechts = true;
        public MainWindow()
        {
            InitializeComponent();

            _animationsTimer.Interval = TimeSpan.FromMilliseconds(25);
            _animationsTimer.Tick += PositioniereBall;         
        }

        private void PositioniereBall(object sender, EventArgs e)
        {
            var x = Canvas.GetLeft(Ball);

            if (_gehtNachrechts)
            {
                Canvas.SetLeft(Ball, x + 5);
            }
            else
            {
                Canvas.SetLeft(Ball, x - 5);
            }

            if (x >= Spielplatz.ActualWidth - Ball.ActualWidth)
            {
                _gehtNachrechts = false;
            }
            else if (x <= 0)
            {
                _gehtNachrechts = true;
            }
        }

        private void StartStopButton_Click(object sender, RoutedEventArgs e)
        {
            if (_animationsTimer.IsEnabled)
            {
                _animationsTimer.Stop();
            }
            else
            {
                _animationsTimer.Start();
            }

        }
    }
}
