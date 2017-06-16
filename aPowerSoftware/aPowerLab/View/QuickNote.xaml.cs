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
using static Albert.Power.Runtime.Device10x;
using Windows.UI.Text;
// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace aPowerLab.View
{
	public sealed partial class QuickNote : UserControl
	{

		public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(object), typeof(QuickNote), new PropertyMetadata("", (sender, e) =>
		 {
			 var qn = sender as QuickNote;
			 //The txt header 
			 qn.txt.Header = (object)e.NewValue; 


		 }));

		public QuickNote()
		{
			this.InitializeComponent();


		



		}

		async void clear_Click(object sender, RoutedEventArgs e)
		{
			await MsgShow("Clearing", "Do you want to clear this document?", "Clear", "Cancel", () =>
				{
					txt.Document.SetText(TextSetOptions.None, "");
				});
		}

		async void load_Click(object sender, RoutedEventArgs e)
		{
			//Load the TextFile 
			await OpenTextFileAsync(async (p, s) =>
			 {

				 var str = await ReadTextAsync(s);

				 txt.Document.SetText(TextSetOptions.None, str);
				// txt.Text = str;

			 });

		}

		async void save_Click(object sender, RoutedEventArgs e)
		{
			try
			{

				var str = "";
				//Write the Text file to the string 
				txt.Document.GetText(TextGetOptions.None, out str);
				//Write the File 
				await SaveTextAsync("TextDocument.txt",str );


			}
			catch (Exception ex)
			{
				await Device10x.MsgShow("Error", ex.Message, "Ok");
			}

		}

		/// <summary>
		/// Gets or set the header of the Textbox 
		/// </summary>
		public object Header
		{
			get { return (object)GetValue(HeaderProperty); }
			set { SetValue(HeaderProperty, value); }
		}
	}
}
