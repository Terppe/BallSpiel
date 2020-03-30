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
        private bool _gehtNachunten = true;

        private int zaehler = 0;
        public MainWindow()
        {
            InitializeComponent();

            _animationsTimer.Interval = TimeSpan.FromMilliseconds(25);
            _animationsTimer.Tick += PositioniereBall;         
        }

        private void PositioniereBall(object sender, EventArgs e)
        {
            var x = Canvas.GetLeft(Ball);
            var y = Canvas.GetTop(Ball);

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

            //------------------------
            if (_gehtNachunten)
            {
                Canvas.SetTop(Ball, y + 5);
            }
            else
            {
                Canvas.SetTop(Ball, y - 5);
            }

            if (y >= Spielplatz.ActualHeight - Ball.ActualHeight)
            {
                _gehtNachunten = false;
            }
            else if (y <= 0)
            {
                _gehtNachunten = true;
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
                zaehler = 0;
                SpielstandLabel.Content = $"{zaehler} Clicks";
            }

        }

        private void Ball_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_animationsTimer.IsEnabled)
            {
                zaehler += 1;
                SpielstandLabel.Content = $"{zaehler} Clicks";
            }

        }
    }
}
