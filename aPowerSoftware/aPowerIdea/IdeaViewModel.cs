using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert.Power.Runtime;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace aPowerIdea
{
	public class IdeaViewModel: ViewModel
	{
		//private field's
		static IdeaMode mode;
		/// <summary>
		/// Gets and Sets the Default frame to use for the Applcation
		/// </summary>
		public static Frame VMFrame { get; set; }
		/// <summary>
		/// Gets and sets the If the Default Menu Button
		/// </summary>
		public static HamburgerButton VMMenu {get; set;}
		/// <summary>
		/// Gets and sets the default StatusBar
		/// </summary>
		public static StackPanel VMStatusBar { get; set; }

		/// <summary>
		/// Gets or sets the Default split view 
		/// </summary>
		public static SplitView VMSplitView { get; set; }

		/// <summary>
		/// Gets or sets the mode you want to be in 
		/// </summary>
		public static IdeaMode VMMode
		{
			get { return mode; }
			set
			{
				mode = value;

				switch(value)
				{
					case IdeaMode.Menu:
						if (VMMenu != null || VMStatusBar != null)
						{
							VMMenu.Visibility = Visibility.Visible;
							VMStatusBar.Visibility = Visibility.Collapsed;
						}

		
						break;
					case IdeaMode.MenuAndStatusBar:
						if (VMMenu != null || VMStatusBar != null)
						{
							VMMenu.Visibility = Visibility.Visible;
							VMStatusBar.Visibility = Visibility.Visible;
						}
						break;
					case IdeaMode.StatusBar:
						if (VMMenu != null || VMStatusBar != null)
						{
							VMMenu.Visibility = Visibility.Collapsed;
							VMStatusBar.Visibility = Visibility.Visible;
						}
						break;
					case IdeaMode.None:
						if (VMMenu != null || VMStatusBar != null)
						{
							VMMenu.Visibility = Visibility.Collapsed;
							VMStatusBar.Visibility = Visibility.Collapsed;
						}
						break;
					default:
						if (VMMenu != null || VMStatusBar != null)
						{
							VMMenu.Visibility = Visibility.Visible;
							VMStatusBar.Visibility = Visibility.Collapsed;
						}
						break;
				}
			}
		}


    }

	public enum IdeaMode
	{
		MenuAndStatusBar,
		Menu,
		StatusBar,
		None
	}
}
