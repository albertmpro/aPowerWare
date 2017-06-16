using Albert.Power.Runtime;
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
using static aPowerLab.LabViewModel;
using static Albert.Power.Runtime.AsyncIO;
using static Albert.Power.Runtime.Device10x;
// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace aPowerLab.View
{
	public sealed partial class QuickSketch : UserControl
	{
		public QuickSketch()
		{
			this.InitializeComponent();
		}
		async void cmd_Click(object sender, RoutedEventArgs e)
		{
			var cmd = sender as CmdButton;

			switch (cmd.Label)
			{
				case "Draw":
					//Use the Draw Tool 
					sketchCanvas.SketchState = SketchState.Draw;
					VMNotify("Using the drawing tool");
					break;
				case "Line":
					//Use the Draw Line 
					sketchCanvas.SketchState = SketchState.Line;
					VMNotify("Using the line tool");
					break;
				case "Rectangle":
					//Use the Rectangle Tool 
					sketchCanvas.SketchState = SketchState.Rectangle;
					VMNotify("Using the rectangle tool");
					break;
				case "Circle":
					//Use the Circle Tool 
					sketchCanvas.SketchState = SketchState.Circle;
					VMNotify("Using the circle tool");
					break;
				case "Erase":
					//Use the Erase Tool 
					sketchCanvas.SketchState = SketchState.Erase;
					VMNotify("Using the erase tool");
					break;
				case "Clear":

					//Message box Lamba for clearing the sketch 
					await MsgShow("Clearing", "Do you want to clear this document?", "Clear", "cancel", () =>
					   {
						   //Clear the SketchCanvas 
						   sketchCanvas.Children.Clear();
					   });
					break;
				case "Save":
					//Export the image 
					await ExportPngAsync(sketchCanvas, 72);
					break;
				default:

					break;
			}
		}
	}
}
