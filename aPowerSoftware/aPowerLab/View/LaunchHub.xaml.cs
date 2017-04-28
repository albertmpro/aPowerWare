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
// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace aPowerLab.View
{
	public sealed partial class LaunchHub : UserControl
	{
		public LaunchHub()
		{
			this.InitializeComponent();
		}

		void hype_Click(object sender, RoutedEventArgs e )
		{
			var hype = sender as HyperlinkButton;

			switch(hype.Tag)
			{
				case "sk": // Go to the SketchLab
					VMNavigate(typeof(SketchLab));
					break;
				case "ch": // Go to the Character Lab
					VMNavigate(typeof(CharacterLab));
					break;
				case "mp": // Go to the Map Lab 
					VMNavigate(typeof(MapLab));
					break;
				default:

					break;
			}


		}

	}
}
