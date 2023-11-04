using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace StopWatch
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            GlobalVar.Day = int.Parse(inputDays.Text);
            GlobalVar.Hours = int.Parse(inputHours.Text);
            GlobalVar.Mins = int.Parse(inputMins.Text);
            GlobalVar.Seconds = int.Parse(inputSeconds.Text);
            StopWatchWindow stopWatchWindow = new StopWatchWindow();
            stopWatchWindow.Show();
            Close();
        }
    }
}
