using System;

namespace EventsDemo.FastClockWpf
{
    /// <summary>
    /// Interaction logic for DigitalClock.xaml
    /// </summary>
    public partial class DigitalClock
    {
        public DigitalClock()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            FastClock.FastClock.Instance.OneMinuteIsOver += Instance_OneMinuteIsOver;
        }
        private void Instance_OneMinuteIsOver(object sender, DateTime e)
        {
            TextBlockClock.Text = e.ToShortTimeString();
        }
    }
}
