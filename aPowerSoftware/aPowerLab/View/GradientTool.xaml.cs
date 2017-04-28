using Albert.Power.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using static Albert.Power.Runtime.AsyncIO;
using static Albert.Power.Runtime.Device10x;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace aPowerLab.View
{
	public sealed partial class GradientTool : UserControl
	{
		public GradientTool()
		{
			this.InitializeComponent();


			void ON_ColorPicker(Color c)
			{
				if(opt1.IsChecked == true)
				{
					color1.Color = colorPicker.Color;
				}
				else if(opt2.IsChecked == true)
				{
					color2.Color = colorPicker.Color;
				}
			}
			colorPicker.OnColorChanged += ON_ColorPicker;

		}

		private void slideColor2_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
		{
			if(slideCOlor1 != null )
				gs1.Offset = slideCOlor1.Value;

		}

		private void slideCOlor1_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
		{
			if(slideColor2 != null)
				gs2.Offset = slideColor2.Value;
		}

		async void export_Click(object sender, RoutedEventArgs e)
		{
			await MsgShow("Do you want to save this background?", "Exporting", "Export", "Cancel", async () =>
				{
					//Export the png images 
					await ExportPngAsync(border, 72);
				});
		}
	}
}
