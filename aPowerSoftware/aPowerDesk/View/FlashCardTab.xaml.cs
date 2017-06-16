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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Albert.Power.Win32;
using System.IO;

using static Albert.Power.Win32.Win32IO;
namespace aPowerDesk.View
{
	/// <summary>
	/// Interaction logic for FlashCardTab.xaml
	/// </summary>
	public partial class FlashCardTab : DocumentControl 
	{




		public FlashCardTab(TabControl _tab)
		{
			InitializeComponent();

			//Create a New TabItem 
			TabItem = new DocumentTabItem($"FlashCard{Count++}", true, this, _tab);

			//Focus 
			TabItem.Focus();
			Focus();


		}

	}
}
