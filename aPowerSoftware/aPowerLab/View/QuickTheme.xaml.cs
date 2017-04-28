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
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static Albert.Power.Core;
using static Albert.Power.Runtime.AsyncIO;
// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace aPowerLab.View
{
	public sealed partial class QuickTheme : UserControl
	{
		public QuickTheme()
		{
			this.InitializeComponent();

			//Main Logic for the ColorPicker 
			void cpicker(Color c)
			{
				var brush = new SolidColorBrush(c);
				
				if (opt1.IsChecked == true)
				{
			
					opt1.BorderBrushChecked = brush;
					opt1.Background = brush; 

				}
				else if(opt2.IsChecked == true)
				{
			
					opt2.BorderBrushChecked = brush;
					opt2.Background = brush;
				}
				else if (opt3.IsChecked == true)
				{
			
					opt3.BorderBrushChecked = brush;
					opt3.Background = brush;
				}
				else if (opt4.IsChecked == true)
				{
				
					opt4.BorderBrushChecked = brush;
					opt4.Background = brush;
				}
				else if (opt5.IsChecked == true)
				{
					opt5.BorderBrushChecked = brush;
					opt5.Background = brush;
				}
			}
			//Create ColorPicker Change Functon 
			colorPicker.OnColorChanged += cpicker;
			


		}

		async void sass_Export(object sender, RoutedEventArgs e)
		{
			//Make the all the Colors a solid Color Brush 

			var color1 = (SolidColorBrush)opt1.Background;
			var color2 = (SolidColorBrush)opt2.Background;
			var color3 = (SolidColorBrush)opt3.Background;
			var color4 = (SolidColorBrush)opt4.Background;
			var color5 = (SolidColorBrush)opt5.Background;

			//Now Convert Color's 
			var cov1 = ConvertAlphaToHtml(color1.Color.ToString());
			var cov2 = ConvertAlphaToHtml(color2.Color.ToString());
			var cov3 = ConvertAlphaToHtml(color3.Color.ToString());
			var cov4 = ConvertAlphaToHtml(color4.Color.ToString());
			var cov5 = ConvertAlphaToHtml(color5.Color.ToString());

			//Write the Document out here
			var sassstr = $"//Theme Stylesheet\n\n$foreground:{cov1};\n$background:{cov2};\n$olro1:{cov3};\n$color2:{cov4};\n$color3:{cov5};\n\nbody\n{{\n\tbackground:{cov2};\n\tcolor:{cov1}\n}}\n";


			await SaveTextAsync( "style.scss", sassstr);



		}
	}
}
