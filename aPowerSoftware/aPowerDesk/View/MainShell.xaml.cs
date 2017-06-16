using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Albert.Power.Win32;
using static aPowerDesk.DeskViewModel;
using static Albert.Power.Win32.QuickAnimation;
namespace aPowerDesk.View
{
	/// <summary>
	/// Main Window Shell of the Application 
	/// </summary>
	public partial class MainShell : ViewShell 
	{
		//Field's 
		TabPage tabPage;

		public MainShell()
		{
			InitializeComponent();

			//Create a instansce of the Tab page 
			tabPage = new TabPage();

			// Link to the VidwModel Frame 
			VMFrame = frame;

			//Navigate to the Tab Page
			VMFrame.Navigate(tabPage);

			//Notify Method 
			void notify(string _str)
			{
				//Fill the tbStatus texgt
				tbStatus.Text = _str;
				//Do a quick Animaton 
				RunDouble(tbStatus, "Opacity",
					1, .4, TimeSpan.FromSeconds(10));
					
			}
			//VMNotify  Expression 
			VMNotify = notify;

			VMNotify("Welcome to the aPowerDesk");
			
		}
	}
}
