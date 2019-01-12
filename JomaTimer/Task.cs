using System;

namespace JomaTimer
{
    class Task
    {
        public string Name { get; set; }
        public int Seconds { get; set; }

        public DateTime Time {
            get
            {
                return DateTime.Now.AddSeconds(Seconds);
            }
        }

        public TimeSpan Remaining
        {
            get
            {
                return new TimeSpan(0, 0, Seconds);
            }
        }

        public bool Paused { get; set; }

        public override string ToString()
        {
            return "Task " + Name + " Seconds:" + Seconds;
        }
    }
}
