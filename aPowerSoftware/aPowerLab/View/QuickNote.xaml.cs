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
using Windows.Storage;
using Albert.Power.Runtime;
using Windows.Storage.Pickers;
using static aPowerLab.LabViewModel;
using static Albert.Power.Runtime.AsyncIO;
using Windows.UI.Text;
// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace aPowerLab.View
{
	public sealed partial class QuickNote : UserControl
	{
		public QuickNote()
		{
			this.InitializeComponent();

			//load click 
			btnLoad.Click += load_Click;

			// save click  
			btnSave.Click += save_Click;

		

		}

		async void load_Click(object sender, RoutedEventArgs e)
		{
			//Load the TextFile 
			await OpenTextFileAsync(async (p, s) =>
			 {

				 var str = await ReadTextAsync(s);

				 txt.Document.SetText(TextSetOptions.None, str);


			 });

		}

		async void save_Click(object sender, RoutedEventArgs e)
		{
			try
			{

				//Write the file here 
				var str = "";
				txt.Document.GetText(TextGetOptions.None, out str);

				//Write the File 
				await SaveTextAsync("TextDocument.txt", str);


			}
			catch (Exception ex)
			{
				await Device10x.MsgShow("Error", ex.Message, "Ok");
			}

		}


	}
}
