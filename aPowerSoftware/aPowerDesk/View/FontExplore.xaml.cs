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

namespace aPowerDesk.View
{
	/// <summary>
	/// Interaction logic for FontExplore.xaml
	/// </summary>
	public partial class FontExplore : DocumentControl
	{
		public FontExplore(TabControl _mainTab)
		{
			InitializeComponent();
			TabItem = new DocumentTabItem("Font Explore", true, this, _mainTab);
			TabItem.Focus();
	
			
			
		}
	}
}
