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
using static Albert.Power.Runtime.AsyncIO;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace aPowerLab.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class WebImgLab : Page10x
	{
		
		public WebImgLab()
		{
			this.InitializeComponent();

			
		}

		async void btnLoad_Click(object sender, RoutedEventArgs e)
		{
			// Open the Picture into the Image List
			await OpenPictureAsync(new List<Image> {imgOriginal,img504,img100,img200,img400 });

			//List the file source 

			//Display Orignial Image size 
			tbSize.Text = ""; 
			tbSize.Text = $"Width: {imgOriginal.ActualWidth}px Height:{imgOriginal.ActualHeight}px";
			
			




		}

		void save_Click(object sender, RoutedEventArgs e)
		{
			
		}


	}
}
