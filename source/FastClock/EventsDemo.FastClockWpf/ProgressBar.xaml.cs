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
using System.Windows.Shapes;

namespace EventsDemo.FastClockWpf
{
    /// <summary>
    /// Interaction logic for ProgressBar.xaml
    /// </summary>
    public partial class ProgressBar : Window
    {
        public ProgressBar()
        {
            InitializeComponent();
        }
        private void Window_Initialized(object sender, EventArgs e)
        {
            FastClock.FastClock.Instance.OneMinuteIsOver += Instance_OneMinuteIsOver;
        }
        private void Instance_OneMinuteIsOver(object sender, DateTime e)
        {
            ProgressBarCtrl.Value = FastClock.FastClock.Instance.Time.Minute;
        }
    }
}
