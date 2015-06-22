using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ShutMeDown.Model
{
    class Clock : DependencyObject
    {

        public bool AllowNegative
        {
            get { return (bool)GetValue(AllowNegativeProperty); }
            set { SetValue(AllowNegativeProperty, value); }
        }
        public static readonly DependencyProperty AllowNegativeProperty =
            DependencyProperty.Register("AllowNegative", typeof(bool), typeof(Clock), new UIPropertyMetadata(true));


        public int Hours
        {
            get { return (int)GetValue(HoursProperty); }
            set { SetValue(HoursProperty, value); }
        }
        public static readonly DependencyProperty HoursProperty =
            DependencyProperty.Register("Hours", typeof(int), typeof(Clock), new UIPropertyMetadata(0, (sender, e) =>
                {
                    var ths = (sender as Clock);
                    if (ths.AllowNegative && (int)e.NewValue < 0)
                        ths.Hours = 0;
                }));

        public int Minutes
        {
            get { return (int)GetValue(MinutesProperty); }
            set { SetValue(MinutesProperty, value); }
        }
        public static readonly DependencyProperty MinutesProperty =
            DependencyProperty.Register("Minutes", typeof(int), typeof(Clock), new UIPropertyMetadata(0, (sender, e) =>
            {
                var ths = (sender as Clock);
                if ((int)e.NewValue >= 60)
                {
                    ths.Minutes = 60 - ths.Minutes;
                    ths.Hours++;
                }
                else if ((int)e.NewValue < 0)
                {
                    ths.Minutes += 60;
                    ths.Hours--;
                }
            }));

        public double Seconds
        {
            get { return (double)GetValue(SecondsProperty); }
            set { SetValue(SecondsProperty, value); }
        }
        public static readonly DependencyProperty SecondsProperty =
            DependencyProperty.Register("Seconds", typeof(double), typeof(Clock), new UIPropertyMetadata(0d, (sender, e) =>
            {
                var ths = (sender as Clock);
                if ((double)e.NewValue >= 60)
                {
                    ths.Seconds = 60 - ths.Seconds;
                    ths.Minutes++;
                }
                else if ((double)e.NewValue < 0)
                {
                    ths.Seconds += 60;
                    ths.Minutes--;
                }
            }));
    }
}