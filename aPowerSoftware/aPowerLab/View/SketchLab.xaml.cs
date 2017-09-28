using Albert.Power.Runtime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using static Albert.Power.Runtime.AsyncIO;
using static Albert.Power.Runtime.Device10x;
using static aPowerLab.LabViewModel;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace aPowerLab.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class SketchLab : Page10x
	{


		public SketchLab()
		{
			this.InitializeComponent();
		}

		void apply_Click(object sender, RoutedEventArgs e)
		{
			sketchCanvas.DrawThickness = slideSize.Value;
			sketchCanvas.DrawOpacity = slideOpacity.Value;
			sketchCanvas.DrawBrush = new SolidColorBrush(colorPicker.Color);
		}

		async void cmd_Click(object sender, RoutedEventArgs e)
		{
			var cmd = sender as CmdButton;

			switch(cmd.Label)
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
