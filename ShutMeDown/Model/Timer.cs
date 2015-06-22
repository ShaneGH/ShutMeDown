using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ShutMeDown.Model
{
    class Timer : DependencyObject
    {
        public event EventHandler CountdownComplete;
        public Clock Clock
        {
            get { return (Clock)GetValue(ClockProperty); }
            set { SetValue(ClockPropertyKey, value); }
        }
        public static readonly DependencyPropertyKey ClockPropertyKey =
            DependencyProperty.RegisterReadOnly("Clock", typeof(Clock), typeof(Timer), new UIPropertyMetadata(null));
        public static readonly DependencyProperty ClockProperty = ClockPropertyKey.DependencyProperty;

        public Timer()
        {
            Clock = new Clock();
        }

        public void BeginCountdown(int hours, int minutes, int seconds, Action complete)
        {
            Stop();
            Clock.Hours = hours;
            Clock.Minutes = minutes;
            Clock.Seconds = seconds;
            Play(complete);
        }

        System.Threading.Timer _timer = null;
        public void Play(Action complete)
        {
            Stop();
            _timer = new System.Threading.Timer((arg) =>
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    if ((Clock.AllowNegative && Clock.Hours < 0)
                        || (Clock.Hours <= 0 && Clock.Minutes <= 0 && Clock.Seconds <= 0))
                    {
                        if (CountdownComplete != null)
                            CountdownComplete(this, new EventArgs());
                        Stop();
                        if (complete != null)
                            complete.Invoke();
                    }
                    else
                        Clock.Seconds--;
                }));
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        public void Stop()
        {
            if (_timer == null)
                return;
            _timer.Dispose();
            _timer = null;
        }
    }
}
