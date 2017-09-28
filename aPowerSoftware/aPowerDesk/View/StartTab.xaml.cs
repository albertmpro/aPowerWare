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
using static aPowerDesk.DeskViewModel;
namespace aPowerDesk.View
{
	/// <summary>
	/// Interaction logic for StartTab.xaml
	/// </summary>
	public partial class StartTab : DocumentControl
	{
		public StartTab(TabControl _tab)
		{
			InitializeComponent();
			

			//Creat the TabItem
			TabItem = new DocumentTabItem("StartPage", false, this, _tab);

			TabItem.Focus();
	
		}

		void hyper_Click(object sender, RoutedEventArgs e)
		{
			var hype = sender as Hyperlink;

			switch(hype.Tag)
			{
				case "txt":
					//Create a new TextEdtor 
					var txt = new TextTab(VMTab);
					break;
				case "writer":
					//Create a new FlashCardDocment 
					var writer = new WebWriter(VMTab);
					break;
				case "writer2":
					Win32IO.OpenDialogTask("Writing File", "All Files(.)|*.*", (o) =>
					{
						
					});		
						
					break;
				case "txt2": //Load File in 
					Win32IO.OpenDialogTask("Open Text File", "All Files(.)|*.*", (o) =>
					  {
						  //Load the
						  var txt2 = new TextTab(VMTab,o.FileName);


					  });
					break;

				default:
					// Do nothing 
					break;
			}
		}



	}
}
