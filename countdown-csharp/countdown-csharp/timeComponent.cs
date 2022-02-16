using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace countdown_csharp
{
    class timeComponent
    {
        private string unit;
        private InputHandler inputHandler;
        private IDictionary<string, int> unitDict;

        public timeComponent(string unit, InputHandler timer)
        {
            this.unit = unit;
            inputHandler = timer;
            unitDict = new Dictionary<string, int>();
            unitDict.Add("seconds", 1);
            unitDict.Add("minutes", 60);
            unitDict.Add("hours", 3600);
            unitDict.Add("days", 86400);
        }

        public TextBlock GetTextBlock()
        {
            double size = 30;
            if(unit == "seconds")
            {
                size = 50;
            }
            TextBlock textBlock = new TextBlock() { Text = GetFormat(), VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top, Name = GetName(), FontSize = size };
            return textBlock;
        }

        public void UpdateTime(StackPanel panel)
        {
            TextBlock block = (TextBlock)panel.FindName(GetName());
            block.Text = GetFormat();
        }

        private String GetName()
        {
            return unit + "Box";
        }

        private String GetFormat()
        {
            return string.Format("{0:0.000}", GetTimeInUnit()) + " in " + unit;
        }

        private Double GetTimeInUnit()
        {
            return inputHandler.getTimeLeft() / unitDict[unit];
        }
    }
}
