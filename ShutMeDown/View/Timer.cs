using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;

namespace ShutMeDown.View
{
    class Timer : System.Windows.Controls.ContentControl
    {
        public const string StartName = "PART_Start";
        public const string StopName = "PART_Stop";
        public const string UpHName = "PART_UpH";
        public const string UpMName = "PART_UpM";
        public const string UpSName = "PART_UpS";
        public const string DownHName = "PART_DownH";
        public const string DownMName = "PART_DownM";
        public const string DownSName = "PART_DownS";

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if(Template == null)
                return;

            var b1 = Template.FindName(UpHName, this) as ButtonBase;
            var b2 = Template.FindName(UpMName, this) as ButtonBase;
            var b3 = Template.FindName(UpSName, this) as ButtonBase;
            var b4 = Template.FindName(DownHName, this) as ButtonBase;
            var b5 = Template.FindName(DownMName, this) as ButtonBase;
            var b6 = Template.FindName(DownSName, this) as ButtonBase;

            var bst = Template.FindName(StartName, this) as ButtonBase;
            var bsp = Template.FindName(StopName, this) as ButtonBase;

            if (b1 != null)
                b1.Click += (sender, e) =>
                {
                    var context = DataContext as Model.Timer;
                    if (context != null && context.Clock != null)
                        context.Clock.Hours++;
                };
            if (b2 != null)
                b2.Click += (sender, e) =>
                {
                    var context = DataContext as Model.Timer;
                    if (context != null && context.Clock != null)
                        context.Clock.Minutes++;
                };
            if (b3 != null)
                b3.Click += (sender, e) =>
                {
                    var context = DataContext as Model.Timer;
                    if (context != null && context.Clock != null)
                        context.Clock.Seconds++;
                };
            if (b4 != null)
                b4.Click += (sender, e) =>
                {
                    var context = DataContext as Model.Timer;
                    if (context != null && context.Clock != null)
                        context.Clock.Hours--;
                };
            if (b5 != null)
                b5.Click += (sender, e) =>
                {
                    var context = DataContext as Model.Timer;
                    if (context != null && context.Clock != null)
                        context.Clock.Minutes--;
                };
            if (b6 != null)
                b6.Click += (sender, e) =>
                {
                    var context = DataContext as Model.Timer;
                    if (context != null && context.Clock != null)
                        context.Clock.Seconds--;
                };
            if (bst != null)
                bst.Click += (sender, e) =>
                {
                    var context = DataContext as Model.Timer;
                    if (context != null && context != null)
                        context.Play(() => { System.Diagnostics.Process.Start("shutdown", "/s /t 0"); });
                };
            if (bsp != null)
                bsp.Click += (sender, e) =>
                {
                    var context = DataContext as Model.Timer;
                    if (context != null && context != null)
                        context.Stop();
                };
        }
    }
}
