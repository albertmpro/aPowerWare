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
using static System.IO.File;
using static aPowerDesk.DeskViewModel;
using static Albert.Power.Win32.Win32IO;
using System.IO;

namespace AMWin32
{
	/// <summary>
	/// Interaction logic for CodePart.xaml
	/// </summary>
	public partial class CodePart : UserControl
	{

		public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string), typeof(CodePart), new PropertyMetadata("Header", (sender, e) =>
		   {
			   var cp = sender as CodePart;

			   // Grab the tb Header 
			   cp.tbHeader.Text = (string)e.NewValue;


		   }));

		public static readonly DependencyProperty CodeProperty = DependencyProperty.Register("Code", typeof(string), typeof(CodePart), new PropertyMetadata("", (sender, e) =>
		{
			var cp = sender as CodePart;

			// Grab the Code.Text 
			cp.txtCode.Text = (string)e.NewValue;


		}));

		public static readonly DependencyProperty FilterProperty = DependencyProperty.Register("Filter", typeof(string), typeof(CodePart), new PropertyMetadata("All Files(.)|*.*", (sender, e) =>
		{
			var cp = sender as CodePart;

			// Grab the Code.Text 
			cp.txtCode.Filter = (string)e.NewValue;


		}));

		/// <summary>
		/// Default Constructor 
		/// </summary>
		public CodePart()
		{
			InitializeComponent();

			void export_Click(object sender, RoutedEventArgs e)
			{
				SaveDialogTask("Export your file", Filter, (s) =>
				  {
					  WriteAllText(s.FileName, txtCode.Text);
					  txtCode.FileInfo = new FileInfo(s.FileName);
					  txtCode.CurrentFile = s.FileName;
				  });
			}


			btnExport.Click += export_Click;

		}


		

		/// <summary>
		/// Gets or sets the Header above the code 
		/// </summary>
		public string Header
		{
			get { return (string)GetValue(HeaderProperty); }
			set { SetValue(HeaderProperty, value); }
		}
		/// <summary>
		/// Gets or sets the Code that is used and saved
		/// </summary>
		public string Code
		{
			get { return (string)GetValue(CodeProperty); }
			set { SetValue(CodeProperty, value); }
		}
		/// <summary>
		/// Gets or sets the File Format that will be used 
		/// </summary>
		public string Filter
		{
			get { return (string)GetValue(FilterProperty); }
			set { SetValue(FilterProperty, value); }
		}

	}
}
