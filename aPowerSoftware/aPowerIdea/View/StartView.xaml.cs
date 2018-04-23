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
using static aPowerIdea.IdeaViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace aPowerIdea.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class StartView : Page10x
	{
		public StartView()
		{
			this.InitializeComponent();
			
			
		}

		void btn_Click(object sender, RoutedEventArgs e)
		{
			var btn = sender as PushButton; 

			switch(btn.Tag)
			{
				case "sk": //Go to the Sketch VIew
					VMFrame.Navigate(typeof(SketchView));
					VMMode = IdeaMode.None;
					break;
				case "pr": //Go to Power Message
					VMFrame.Navigate(typeof(InstaMsgView));
					VMMode = IdeaMode.Menu;

					break;
				case "ab":
					VMFrame.Navigate(typeof(AboutView));
					VMMode = IdeaMode.Menu;
					break;
			}
		}


	}
}
