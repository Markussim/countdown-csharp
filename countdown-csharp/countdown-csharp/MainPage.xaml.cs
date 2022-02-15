using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace countdown_csharp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private InputHandler mainInputHandler = new InputHandler();
        public MainPage()
        {
            this.InitializeComponent();
            CompositionTarget.Rendering += UpdateTimeLeft;
        }

        private void formatText(object sender, RoutedEventArgs e)
        {
            timeInput.Text = mainInputHandler.formatText(timeInput.Text);
            timeInput.Select(timeInput.Text.Length, 0);
        }

        private void UpdateTimeLeft(object sender, object args)
        {
            outputBox.Text = String.Format("{0:0.00}", mainInputHandler.getTimeLeft()) + " in seconds";
        }
    }
}
