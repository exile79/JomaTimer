using System;

namespace JomaTimer
{
    internal class TaskParser
    {
        internal static Task Parse(string s)
        {
            if (s.IndexOf(" in ") > 0)
            {
                var arr = s.Split(new string[] { " in " }, StringSplitOptions.RemoveEmptyEntries);
                var task = new Task();
                task.Name = arr[0].Trim();
                var timeexp = arr[1].Trim();

                var idx = timeexp.IndexOf('s');
                if (idx != -1)
                {
                    // seconds
                    var v = timeexp.Substring(0, idx);
                    double d;
                    double.TryParse(v, out d);
                    var t = DateTime.Now.AddSeconds(d);
                    task.Time = t;
                    
                }

                return task;

            }

            return null;
        }
    }
}