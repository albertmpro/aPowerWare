﻿using System;
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
using static aPowerDesk.DeskViewModel;
namespace aPowerDesk.View
{
	/// <summary>
	/// Interaction logic for TabPage.xaml
	/// </summary>
	public partial class TabPage : Page
	{

		//Field's 
		StartTab startPage;
		
		public TabPage()
		{
			InitializeComponent();

			//Link to the VMTab 
			VMTab = tabControl;

			//Create a StartPage 
			startPage = new StartTab(VMTab);
			


		}
	}
}
