using System.Windows;
using System;
using System.Windows.Input;
using System.Windows.Threading;

namespace StopWatch
{
    public partial class StopWatchWindow : Window
    {
        private DispatcherTimer _timer;
        private TimeSpan _countdownTime;
        private TimeSpan _currentTime;
        
        
        public StopWatchWindow()
        {
            InitializeComponent();
            InitializeCountdown(GlobalVar.Day, GlobalVar.Hours, GlobalVar.Mins, GlobalVar.Seconds);
        }
        private void InitializeCountdown(int days, int hours, int minutes, int seconds)
        {
            _countdownTime = new TimeSpan(days, hours, minutes, seconds);
            _currentTime = _countdownTime;

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += CountdownTimer_Tick;
            _timer.Start();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (_currentTime > TimeSpan.Zero)
            {
                _currentTime = _currentTime.Subtract(TimeSpan.FromSeconds(1));
            }
            else
            {
                _timer.Stop();
                // Countdown has ended, you can add custom handling here
                MessageBox.Show("时间到啦！！！！");
            }

            countdownTextBlock.Content = _currentTime.ToString(@"dd\:hh\:mm\:ss");
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
