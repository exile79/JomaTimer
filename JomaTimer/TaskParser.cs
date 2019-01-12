using System;

namespace JomaTimer
{
    internal class TaskParser
    {

        internal static Task Parse(string s)
        {
            // s should be in the form  "<time>s/h<space><title> 
            var idx = s.IndexOf(' '); // split first space

            if (idx < 2)
            {
                throw new TaskParserException();
            }

            // get time
            int seconds = 0;
            var timeString = s.Substring(0, idx).Trim();
            if (timeString.EndsWith("s", StringComparison.InvariantCultureIgnoreCase))
            {
                // seconds
                timeString = timeString.Substring(0, timeString.Length - 1);
                seconds = int.Parse(timeString);
            }
            else if (timeString.EndsWith("m", StringComparison.InvariantCultureIgnoreCase))
            {
                // minutes
                timeString = timeString.Substring(0, timeString.Length - 1);
                seconds = int.Parse(timeString);
                seconds *= 60;
            }
            else if (timeString.EndsWith("h", StringComparison.InvariantCultureIgnoreCase))
            {
                // hours
                timeString = timeString.Substring(0, timeString.Length - 1);
                seconds = int.Parse(timeString);
                seconds *= 360;
            }
            else
            {
                throw new TaskParserException();
            }

            var name = s.Substring(idx).Trim();

            var task = new Task();
            task.Name = name;
            task.Seconds = seconds;

            return task;

            //if (s.IndexOf(" in ") > 0)
            //{
            //    var arr = s.Split(new string[] { " in " }, StringSplitOptions.RemoveEmptyEntries);
            //    var task = new Task();
            //    task.Name = arr[0].Trim();
            //    var timeexp = arr[1].Trim();

            //    var idx = timeexp.IndexOf('s');
            //    if (idx != -1)
            //    {
            //        // seconds
            //        var v = timeexp.Substring(0, idx);
            //        double d;
            //        double.TryParse(v, out d);
            //        var t = DateTime.Now.AddSeconds(d);
            //        task.Time = t;
                    
            //    }

            //    return task;

            //}

            //return null;
        }
    }

    internal class TaskParserException : Exception
    {

    }
}