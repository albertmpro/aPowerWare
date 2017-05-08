﻿using System;
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
using Albert.Power.Runtime;
using Windows.System;
using static aPowerLab.LabViewModel;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace aPowerLab.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class WebLab : Page10x
	{
		public WebLab()
		{
			this.InitializeComponent();
			VMNotify("You are on hte WebLab.");
		}

		void txtUrl_KeyUp(object sender, KeyRoutedEventArgs e)
		{
			//Make sure that you are using the Enter key 
			if (e.Key == VirtualKey.Enter)
			{
				//Preform Navigatioin 
				WebNavigate();
			}
		}
		void go_Click(object sender, RoutedEventArgs e)
		{
			//Preform Navigation 
			WebNavigate();
		}

		void WebNavigate()
		{
			if (txtUrl.Text.StartsWith("http://"))
				webView.Navigate(new Uri(txtUrl.Text)); // Navigate the url 
			else
			{
				//add the http: part 
				var http = "http://";
				webView.Navigate(new Uri($"{http}{txtUrl.Text}"));


			}
		}

		private void txtUrl_GotFocus(object sender, RoutedEventArgs e)
		{
			//Select all the text 
			txtUrl.SelectAll();
		}

		private void webView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
		{
			//Load the real address into the address bar 
			txtUrl.Text = webView.Source.ToString();
			//Notify the Application what is going on 
			//App.ViewModel.Notify("Completed!");
			VMNotify("Completed!");
		}

		private void webView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
		{
			//Notify the Application what is going on 
			//App.ViewModel.Notify("Loading...");
			VMNotify("Loading..");
		}
	}
}
