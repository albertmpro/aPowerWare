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
		InstaMsgDialog msg;

        public InstaMsgView()
        {
            this.InitializeComponent();
			//Set Default Orentation's 
			Orientation(DisplayOrientations.Portrait);
			msg = new InstaMsgDialog();
		}


		async void cmd_Click(object sender, RoutedEventArgs e)
		{
			var cmd = sender as CmdButton;

			void edit()
			{

			}
			//Link to the insta Edit Dialog 
			msg.OnFirstButton += edit;

			async void save()
			{
				//Create a random number
				var random = new Random();
				//Create a Name 
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
					
					await msg.ShowAsync();

					break;
				case "Save":
					await MsgShow("Save Image", "Do you want to save this text?", "Save", "Cancel", save);
					break;
				case "Clear":

					await MsgShow("Clear", "Do you want to clear this text?", "Clear", "Cancel", clear);

					break;
			}
		}

    }
}
