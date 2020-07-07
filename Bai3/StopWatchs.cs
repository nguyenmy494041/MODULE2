using System;
namespace Bai3
{
    public class StopWatch
    {
        public static void Main()
        {
            Watch watch = new Watch();

            watch.Start();

            double n = 0;

            while (n < 10000)
            {
                System.Console.WriteLine(n);
                n++;
            }

            watch.Stop();

            int time = watch.GetElapsedTime();

            Console.WriteLine($"Thoi gian chay: {time}");
        }
    }
    public class Watch
    {
        private DateTime _startTime;
        private DateTime _endTime;

        public Watch()
        {
            _startTime = DateTime.Now;
        }

        public DateTime startTime()
        {
            return _startTime;
        }

        public DateTime endTime()
        {
            return _endTime;
        }
        public void Start()
        {
            _startTime = DateTime.Now;
        }

        public void Stop()
        {
            _endTime = DateTime.Now;
        }

        public int GetElapsedTime()
        {
            var distance = _endTime - _startTime;
            return distance.Milliseconds;
        }
    }
}