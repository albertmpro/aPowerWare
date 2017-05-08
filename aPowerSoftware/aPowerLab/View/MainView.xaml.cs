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
using static aPowerLab.LabViewModel;
using static Albert.Power.Runtime.QuickAnimation;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace aPowerLab.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainView : Page10x
	{
		public MainView()
		{
			this.InitializeComponent();

			//ViewModel Stuff 
			VMSplitView = splitView;
			VMFrame = frame;
			//Go to the StartView
			VMNavigate(typeof(StartLab));
			
			//Notify Lamba 
			VMNotify += (s) =>
			{
				tbStatus.Text = s; // Link the string to the tbStatus
				
				//Animation 
				RunDouble(tbStatus, "Opacity", 1, .4, TimeSpan.FromSeconds(5.4));
			};

		}
		void ham_Click(object sender, RoutedEventArgs e)
		{
			var ham = sender as HamburgerButton;


			switch(ham.Symbol)
			{
				case "St": // Go to the StartLab 
					VMNavigate(typeof(StartLab));
					break;
				case "Mp": // Go to the map lab
					VMNavigate(typeof(MapLab));
					break;
	
				
				case "Sk": // Run the SketchLab 
					VMNavigate(typeof(SketchLab));
					break;
				case "Wb": // Rin the WebLab
					VMNavigate(typeof(WebLab));
					break;
				default:

					break;
			}
		}
		void mnu_Click(object sender, RoutedEventArgs e)
		{
			splitView.IsPaneOpen = true;
		}



	}
}
