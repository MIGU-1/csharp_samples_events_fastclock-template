using System;
using System.Windows;

namespace EventsDemo.FastClockWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Initialized(object sender, EventArgs e)
        {
            DatePickerDate.SelectedDate = DateTime.Today;
            TextBoxTime.Text = DateTime.Now.ToShortTimeString();
        }

        private void ButtonSetTime_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = Convert.ToDateTime(DatePickerDate.SelectedDate);
            string[] timestr = TextBoxTime.Text.Split(':');
            selectedDate = selectedDate.AddHours(Convert.ToDouble(timestr[0]));
            selectedDate = selectedDate.AddMinutes(Convert.ToDouble(timestr[1]));
            FastClock.FastClock.Instance.Time = selectedDate;
        }

        private void FastClockOneMinuteIsOver(object sender, DateTime fastClockTime)
        {
            TextBlockDate.Text = fastClockTime.ToShortDateString();
            TextBlockTime.Text = fastClockTime.ToShortTimeString();
        }

        private void CheckBoxClockRuns_Click(object sender, RoutedEventArgs e)
        {
            FastClock.FastClock.Instance.Factor = Convert.ToInt32(TextBoxFactor.Text);
            FastClock.FastClock.Instance.OneMinuteIsOver += FastClockOneMinuteIsOver;
            ButtonSetTime_Click(this, null);
            FastClock.FastClock.Instance.IsRunning = CheckBoxClockRuns.IsChecked == true;
        }

        private void ButtonCreateView_Click(object sender, RoutedEventArgs e)
        {
            DigitalClock digitalClock = new DigitalClock();
            ProgressBar progressBar = new ProgressBar();
            digitalClock.Owner = this;
            digitalClock.Show();
            progressBar.Owner = this;
            progressBar.Show();
        }
    }
}
