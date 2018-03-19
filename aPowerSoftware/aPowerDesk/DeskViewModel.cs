using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input; 
using Albert.Power.Win32;
using System.Windows.Controls;

namespace aPowerDesk
{
	

	public class DeskViewModel: ViewModel
	{
	

		//Repsents the command to run the Consle Application 
		static RoutedUICommand runConsole = new RoutedUICommand("RunConsole", "RunConsole", typeof(DeskViewModel));

		

		/// <summary>
		/// Gets the command to run the Console Applications 
		/// </summary>
		public static RoutedUICommand RunConsole
		{
			get { return runConsole; }
		}
		/// <summary>
		/// Gets or sets defualt Frame of the Application 
		/// </summary>
		public static  Frame VMFrame { get; set; }
		/// <summary>
		/// Gets or sets the Default Tab COntrol of the Applicationns 
		/// </summary>
		public static TabControl VMTab { get; set;  }

		/// <summary>
		/// A static  Action Event that can be used to notify the Application 
		/// </summary>
		public static Action<string> VMNotify;


	}
}
