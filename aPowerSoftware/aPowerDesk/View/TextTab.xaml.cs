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
using static System.IO.File;
using static aPowerDesk.DeskViewModel;
namespace aPowerDesk.View
{
	/// <summary>
	/// Interaction logic for TextTab.xaml
	/// </summary>
	public partial class TextTab : DocumentControl
	{

		/// <summary>
		/// Default Constructor 
		/// </summary>
		/// <param name="_tab"></param>
		public TextTab(TabControl _tab)
		{
			InitializeComponent();
			
			txt.TabItem = new DocumentTabItem($"Document{Count++}", true, this, _tab);
			//Focus 
			txt.TabItem.Focus();
			Focus();
			txt.Focus();
			//Notify the Application 
			VMNotify("You have created New Text Document");

		}
		/// <summary>
		/// Secondary Constructory 
		/// </summary>
		/// <param name="_tab"></param>
		/// <param name="_fileName"></param>
		public TextTab(TabControl _tab,string _fileName)
		{
			InitializeComponent();

			//Get the File INfo 
			txt.FileInfo = new FileInfo(_fileName);
			//Read the TextFile 
			txt.Text = ReadAllText(_fileName);
			txt.TabItem = new DocumentTabItem(txt.FileInfo.Name, true, this, _tab);
			//Focus 
			txt.TabItem.Focus();
		
			txt.Focus();
			//Notify the Application 
			VMNotify($"You have opened {txt.FileInfo.Name} from the {txt.FileInfo.DirectoryName} directory.");

		}
	}
}
