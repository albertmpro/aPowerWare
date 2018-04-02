using System;
using System.Collections.Generic;
using  System.IO;
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
using static Albert.Power.Runtime.AsyncIO;
using static Albert.Power.Runtime.Device10x;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Pickers;
using Windows.Graphics.Display;
using static aPowerIdea.IdeaViewModel;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace aPowerIdea.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class SketchView : Page10x
	{
		public SketchView()
		{
			this.InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			//Set Default Orentation's 
			Orientation(DisplayOrientations.Portrait);
			// Hide the status bar 
			HidePhoneStatusBar();
		}

		async void cmd_Click(object sender, RoutedEventArgs e)
		{
			CmdButton cmd = sender as CmdButton;
			void clear()
			{
				//Clear the Sketch 
				sketchCanvas.Children.Clear();
			}
			async void save()
			{
				var random = new Random();
				//Cfreate a Name 
				var name = $"image{random.Next(1, 1000)}";
				//Write the File
				await ExportJpegAsync(name, sketchCanvas, 72);
			}

			switch (cmd.Label)
			{
				case "Draw":
					//Draw something 
					sketchCanvas.SketchState = SketchState.Draw;
					break;
				case "Line":
					//Draw a Line  
					sketchCanvas.SketchState = SketchState.Line;
					break;
				case "Rectangle":
					//Draw a Rectangle 
					sketchCanvas.SketchState = SketchState.Rectangle;
					break;
				case "Erase":
					//Erase something 
					sketchCanvas.SketchState = SketchState.Erase;
					break;
				case "Clear":
					await MsgShow("Do you want to Clear this Sketch?", "Cancel Sketch", "Clear", "Cancel", clear);
					break;
				case "Save":
					await MsgShow("Do you want to save this Sketch?", "Save Sketch", "Save", "Cancel", save);
					break;
				case "Menu":
					VMSplitView.IsPaneOpen = true;
					break;
			}

		}

	}
}
