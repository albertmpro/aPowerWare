using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert.Power.Win32;
using System.Windows.Controls;

namespace aPowerDesk
{
	public class DeskViewModel: ViewModel
	{


		public static  Frame VMFrame { get; set; }

		public static TabControl VMTab { get; set;  }

		/// <summary>
		/// A static  Action Event that can be used to notify the Application 
		/// </summary>
		public static Action<string> VMNotify;


	}
}
