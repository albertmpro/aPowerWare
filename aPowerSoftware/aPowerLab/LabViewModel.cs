using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert.Power.Runtime;
using System.IO;
using Windows.UI.Xaml;
using Windows.Data.Pdf;
using static Albert.Power.Runtime.AsyncIO;
using static Albert.Power.Runtime.Device10x;
using Windows.UI.Xaml.Controls;

namespace aPowerLab
{
	/// <summary>
	/// Default ViewModel of the Application 
	/// </summary>
	public class LabViewModel: ViewModel 
	{

		#region Event  and Method's 
		/// <summary>
		/// Navigation for the ViewModel 
		/// </summary>
		/// <param name="_page"></param>
		public static void VMNavigate(Type _page)
		{
			//Navigate to the Frame 
			VMFrame?.Navigate(_page);

			//Close the Pane View of the Application 
			if (VMSplitView != null)
				VMSplitView.IsPaneOpen = false;
		}


		/// <summary>
		/// A static  Action Event that can be used to notify the Application 
		/// </summary>
		public static Action<string> VMNotify;
		#endregion


		#region Poperties 

		/// <summary>
		/// Gets or set the Default Frame that you may want to use 
		/// </summary>
		public static Frame VMFrame { get; set; }


		/// <summary>
		/// Gets or sets the Default SplitView You might want to use 
		/// </summary>
		public static SplitView VMSplitView { get; set; }





		#endregion


		#region Sketch Canvas Logic 

		public static async Task ExportSketchCanvasAsync(SketchCanvas _sketchCanvas)
		{
			if (_sketchCanvas != null)
			{
				await ExportPngAsync(_sketchCanvas, 72);
			}
		}

		public static async Task ClearSketchCanvas(SketchCanvas _canvas)
		{
			//Method for Clearing the canvs 
			void clear()
			{
				_canvas?.Children.Clear();
			}
			await MsgShow("Clearing Sketch", "Do you want to clear sketch?", "Clear", "Cancel", clear);
		}

		#endregion



	}
}
