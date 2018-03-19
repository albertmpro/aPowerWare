using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Albert.Power.Win32;
using  System.IO;
using static System.IO.File;
using static Albert.Power.Win32.Win32IO;
using static System.Windows.MessageBox;
using static aPowerDesk.DeskViewModel;


namespace aPowerDesk.View
{
    /// <summary>
    /// Interaction logic for WebWriter.xaml
    /// </summary>
    public partial class WebWriter : DocumentControl 
    {
        public WebWriter(TabControl _tab)
        {
            InitializeComponent();
			//Create a New TabItem 
			txt.TabItem = new DocumentTabItem($"Document{Count++}", true, this, _tab);
			//Focus 
			txt.TabItem.Focus();
			Focus();
			txt.Focus();
			//Notify the Application 
			VMNotify("You have created New Text Document");
		}

		public WebWriter(TabControl _tab,string _fileName)
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
