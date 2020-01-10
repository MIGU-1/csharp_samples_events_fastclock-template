using System;
using System.Windows.Threading;

namespace EventsDemo.FastClock
{
    public class FastClock
    {
        private static FastClock _instance;

        private bool _isRunning;

        private readonly DispatcherTimer _timer;


        public event EventHandler<DateTime> OneMinuteIsOver;


        public static FastClock Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FastClock();
                    return _instance;
                }
                else
                {
                    return _instance;
                }
            }
        }

        public int Factor { get; set; }
        public DateTime Time { get; set; }
        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                if (!_isRunning && value)
                {
                    if (Factor == 0)
                        Factor = 1;

                    _timer.Interval = TimeSpan.FromMilliseconds(10000 / Factor);
                    _timer.Start();
                }
                else if (_isRunning && !value)
                {
                    _timer.Stop();
                }

                _isRunning = value;
            }

        }

        private FastClock()
        {
            Factor = 1;
            Time = DateTime.Now;
            _timer = new DispatcherTimer();
            _timer.Tick += OnTimerTick;
            _timer.Interval = TimeSpan.FromMilliseconds(10000);
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            Time = Time.AddMinutes(1);
            OnOneMinuteIsOver(Time);
        }
        protected virtual void OnOneMinuteIsOver(DateTime time)
        {
            OneMinuteIsOver?.Invoke(this, time);
        }
    }
}
