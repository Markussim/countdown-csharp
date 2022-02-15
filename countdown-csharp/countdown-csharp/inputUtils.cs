using System;
using System.Diagnostics;
using System.Linq;

namespace countdown_csharp
{
    class InputHandler
    {
        private DateTime dt;

        public InputHandler()
        {
            dt = new DateTime();
        }

        public string formatText(string input)
        {
            String newText = input;
            int inputLength = input.Length;
            if(inputLength > 5)
            {
                newText = input.Remove(input.Length - 1, 1);
            }
            if(inputLength == 3 && input[2].ToString() != ":")
            {
                newText = input.Remove(input.Length - 1, 1);
                newText += ":";
                if (Char.IsNumber(input[2]))
                {
                    newText += input[2];
                }
            }
            if(input.Length == 5 && int.TryParse(input.Substring(0, 2), out int hour) && int.TryParse(input.Substring(3, 2), out int minute))
            {
                if(Enumerable.Range(0, 23).Contains(hour) && Enumerable.Range(0, 59).Contains(minute))
                {
                    DateTime now = DateTime.Now;
                    dt = new DateTime(now.Year, now.Month, now.Day, hour, minute, 0, DateTimeKind.Local);
                }
                
            }

            return newText;
        }

        public double getTimeLeft()
        {
            return (Double)(dt.ToUniversalTime().Ticks - DateTime.Now.ToUniversalTime().Ticks) / (Double)TimeSpan.TicksPerSecond;
        }
    }
}
