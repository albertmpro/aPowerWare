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
	public sealed partial class MainView : Page10x
	{
		public MainView()
		{
			this.InitializeComponent();
			//Setup the ViewModel
			//Default Frame
			VMFrame = frame;
			//Default Menu
			VMMenu = hamMenu;
			//Default StatusBar 
			VMStatusBar = stackStatus;
			//Defult SplitView 
			VMSplitView = splitView; 

			
		

			//Set the Start Frame 
			VMFrame.Navigate(typeof(StartView));
			//Set Default mode 
			VMMode = IdeaMode.Menu;


		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			//Set the orentation 
			Orientation(DisplayOrientations.Portrait);
	

		}
		void ham_Click(object sender, RoutedEventArgs e)
		{
			var ham = sender as HamburgerButton;

			switch(ham.Symbol)
			{
				case "St":
					VMFrame.Navigate(typeof(StartView));
					VMMode = IdeaMode.None;
					VMSplitView.IsPaneOpen = false;
					break;
				case "Sk":
					//Navigate to the Sketchview
					VMFrame.Navigate(typeof(SketchView));
					VMMode = IdeaMode.None;
					VMSplitView.IsPaneOpen = false;
					break;
				case "In":
					//Navigate to the about page
					VMFrame.Navigate(typeof(InstaMsgView));
					VMMode = IdeaMode.Menu;
					VMSplitView.IsPaneOpen = false;
					break;
				case "Ab":
					//Navigate to the about page
					VMFrame.Navigate(typeof(AboutView));
					VMMode = IdeaMode.Menu;
					VMSplitView.IsPaneOpen = false;
					break;

			}
		}
		void mnu_Click(object sender, RoutedEventArgs e)
		{
			splitView.IsPaneOpen = true;
		}













	}
}
