using System;
using System.Collections.Generic;
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
using Albert.Power.Runtime;
using static Albert.Power.Runtime.Device10x;
using static Albert.Power.Runtime.AsyncIO;
using static aPowerIdea.IdeaViewModel;
using Windows.Graphics.Display;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace aPowerIdea.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InstaMsgView : Page10x
    {
        public InstaMsgView()
        {
            this.InitializeComponent();
			//Set Default Orentation's 
			Orientation(DisplayOrientations.Portrait);
		}


		async void cmd_Click(object sender, RoutedEventArgs e)
		{
			var cmd = sender as CmdButton;

			async void save()
			{
				//Create a random number
				var random = new Random();
				//Cfreate a Name 
				var name = $"image{random.Next(1, 1000)}";
				//Write the Image File
				await ExportJpegAsync(name, txtMsg, 72);
			}

			void clear()
			{
				txtMsg.Text = "";
			}

			switch (cmd.Label)
			{
	
				case "Edit":

					break;
				case "Save":

					break;
				case "Clear":

					await MsgShow("Clear", "Do you want to clear this text", "Clear", "Cancel", clear);

					break;
			}

    }
}
