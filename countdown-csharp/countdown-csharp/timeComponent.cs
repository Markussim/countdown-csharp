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

        public timeComponent(string unit, InputHandler timer)
        {
            this.unit = unit;
            inputHandler = timer;
        }

        public TextBlock GetTextBlock()
        {
            TextBlock textBlock = new TextBlock() { Text = string.Format("{0:0.00}", inputHandler.getTimeLeft()) + " in " + unit, VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top };
            return textBlock;
        }
    }
}
