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
using Albert.Power.Runtime;
using static Albert.Power.Runtime.Device10x;
using static Albert.Power.Runtime.AsyncIO;
using static aPowerLab.LabViewModel;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace aPowerLab.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CharacterLab : Page10x
	{

		public enum SheetState { All,FrontBack,FrontSide,BackSide,Front,Back,Side}
		SketchCanvas front, side, back;
		TextBlock tbFront, tbBack, tbSide;
		RowDefinition row1, row2;

		ColumnDefinition col1, col2, col3;
		SheetState state;

		/// <summary>
		/// Default Constructor 
		/// </summary>
		public CharacterLab()
		{
			this.InitializeComponent();

			//Create the Layout Root 
			InitLayoutRoot();

			void InitLayoutRoot()
			{

				// Declare the SketchCanvas 
				front = new SketchCanvas { Margin = new Thickness(8),Width = 504, Height =504, DrawOpacity = .2, DrawThickness = 7 };
				side = new SketchCanvas { Margin = new Thickness(8),  Width = 504, Height = 504, DrawOpacity = .2, DrawThickness = 7 };
				back = new SketchCanvas { Margin = new Thickness(8), Width = 504, Height = 504, DrawOpacity = .2, DrawThickness = 7 };

				//Declare TextBlock 
				tbFront = new TextBlock { TextAlignment = TextAlignment.Center, Margin = new Thickness(5), Text = "Front" };
				tbBack = new TextBlock { TextAlignment = TextAlignment.Center, Margin = new Thickness(5), Text = "Back" };
				tbSide = new TextBlock { TextAlignment = TextAlignment.Center, Margin = new Thickness(5), Text = "Side" };

				//Row's 
				row1 = new RowDefinition();
				row2 = new RowDefinition { MinHeight = 40 };

				//Column's 
				col1 = new ColumnDefinition();
				col2 = new ColumnDefinition();
				col3 = new ColumnDefinition();

				//Setup Rows and Columns 
				layoutRoot.RowDefinitions.Add(row1);
				layoutRoot.RowDefinitions.Add(row2);
				layoutRoot.ColumnDefinitions.Add(col1);
				layoutRoot.ColumnDefinitions.Add(col2);
				layoutRoot.ColumnDefinitions.Add(col3);


			}


			//Notify the Application 
			//VMNotify("You are using hte Character Lab.");

			State = SheetState.All;

		}



		private void cmbState_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var item = cmbState.SelectedItem as ComboBoxItem;

			switch (item?.Content)
			{
				case "All":
					State = SheetState.All;
					VMNotify("Show All Sides");
					break;
				case "Front":
					State = SheetState.Front;

					VMNotify("Show the Front");
					break;
				case "Side":
					State = SheetState.Side;
					VMNotify("Show the Side");
					break;
				case "Back":
					State = SheetState.Back;
					VMNotify("Show the Back");
					break;
				case "FrontBack":
					State = SheetState.FrontBack;
					VMNotify("Show the Front and Back");
					break;
				case "FrontSide":
					State = SheetState.FrontSide;
					VMNotify("Show the Front and Side");
					break;
				case "SideBack":
					State = SheetState.BackSide;
					VMNotify("Show the Side and Back");
					break;
			}
		}


		async void cmd_Click(object sender, RoutedEventArgs e)
		{
			var cmdButton = sender as CmdButton; 

			void skState(SketchState _state)
			{
				front.SketchState = _state;
				back.SketchState = _state;
				side.SketchState = _state;
			}
			void clear()
			{
				front.Children.Clear();
				back.Children.Clear();
				side.Children.Clear();
			}
			switch(cmdButton.Label)
			{
				case "Draw":
					//Do the Draw State 
					skState(SketchState.Draw);
					break;
				case "Line":
					//Do the Line State 
					skState(SketchState.Line);
					break;
				case "Rectangle":
					//Do the Rectangle State 
					skState(SketchState.Rectangle);
					break;
				case "Circle":
					//Do the Circle State 
					skState(SketchState.Circle);
					break;
				case "Erase":
					//Do the Erase State 
					skState(SketchState.Erase);
					break;
				case "Clear":
					await MsgShow("Do you want ot clear these documents?", "Clear", "Clear","Cancel", () =>
					   {
						   //Clear Everything 
						   clear(); 
					   });
					break;

				case "Save":
					
				default:
					//Do Nothing 
					break;
			}
		}

		public SheetState State
		{
			get
			{
				return state;
			}
			set
			{
				state = value;

				//Clear LayoutRoot
				void clear()
				{
					//Clear the Children 
					layoutRoot.Children.Clear();

					//Clear up Column Spans 
					Grid.SetColumnSpan(front, 1);
					Grid.SetColumnSpan(side, 1);
					Grid.SetColumnSpan(back, 1);
					Grid.SetColumnSpan(tbFront, 1);
					Grid.SetColumnSpan(tbSide, 1);
					Grid.SetColumnSpan(tbBack, 1);
				}
				void threesides()
				{
				
					layoutRoot.RowDefinitions.Clear();
					layoutRoot.ColumnDefinitions.Clear();

					layoutRoot.RowDefinitions.Add(row1);
					layoutRoot.RowDefinitions.Add(row2);
					layoutRoot.ColumnDefinitions.Add(col1);
					layoutRoot.ColumnDefinitions.Add(col2);
					layoutRoot.ColumnDefinitions.Add(col3);

				}
				void twosides()
				{

					layoutRoot.RowDefinitions.Clear();
					layoutRoot.ColumnDefinitions.Clear();

					layoutRoot.RowDefinitions.Add(row1);
					layoutRoot.RowDefinitions.Add(row2);
					layoutRoot.ColumnDefinitions.Add(col1);
					layoutRoot.ColumnDefinitions.Add(col2);


				}
		

				switch(value )
				{
					case SheetState.Front: //Show Only The Front View
						//Clean Up the layoutRoot
						clear();
						threesides();
						Grid.SetColumnSpan(front, 3);
						Grid.SetColumnSpan(tbFront, 3);
						Grid.SetRow(front, 0);
						Grid.SetRow(tbFront, 1);
						layoutRoot.Children.Add(front);
						layoutRoot.Children.Add(tbFront);
						break;
					case SheetState.Back: // Show only the Back View
						//Clear the layoutRoot 
						clear();
						threesides();
						Grid.SetColumnSpan(back, 3);
						Grid.SetColumnSpan(tbBack, 3);
						Grid.SetRow(back, 0);
						Grid.SetRow(tbBack, 1);
						layoutRoot.Children.Add(back);
						layoutRoot.Children.Add(tbBack);
						break;
					case SheetState.Side:
						
						clear();
						threesides();
						Grid.SetColumnSpan(side, 3);
						Grid.SetColumnSpan(tbSide, 3);
						Grid.SetRow(side, 0);
						Grid.SetRow(tbSide, 1);
						layoutRoot.Children.Add(side);
						layoutRoot.Children.Add(tbSide);

						break;
					case SheetState.FrontSide:
						//Clear the layoutRoot 
						clear();
						twosides();
					
						Grid.SetRow(tbSide, 1);
						Grid.SetRow(tbFront, 1);
						Grid.SetColumn(front, 0);
						Grid.SetColumn(side, 1);
						Grid.SetColumn(tbFront, 0);
						Grid.SetColumn(tbSide, 1);
						layoutRoot.Children.Add(front);
						layoutRoot.Children.Add(tbFront);
						layoutRoot.Children.Add(side);
						layoutRoot.Children.Add(tbSide);
						break;
					case SheetState.FrontBack:
						//Clear the layoutRoot 
						clear();
						twosides();
						Grid.SetRow(tbBack, 1);
						Grid.SetRow(tbFront, 1);
						Grid.SetColumn(front, 0);
						Grid.SetColumn(back, 1);
						Grid.SetColumn(tbFront, 0);
						Grid.SetColumn(tbBack, 1);
						layoutRoot.Children.Add(front);
						layoutRoot.Children.Add(tbFront);
						layoutRoot.Children.Add(back);
						layoutRoot.Children.Add(tbBack);
						break;
					case SheetState.BackSide:

						//Clear the layoutRoot 
						clear();
						twosides();
						Grid.SetRow(tbSide, 1);
						Grid.SetRow(tbBack, 1);
						Grid.SetColumn(side, 0);
						Grid.SetColumn(back, 1);
						Grid.SetColumn(tbSide, 0);
						Grid.SetColumn(tbBack, 1);
						layoutRoot.Children.Add(tbSide);
						layoutRoot.Children.Add(side);
						layoutRoot.Children.Add(back);
						layoutRoot.Children.Add(tbBack);
						break;

					case SheetState.All:
						clear();
						threesides();

						Grid.SetRow(tbSide, 1);
						Grid.SetRow(tbBack, 1);
						Grid.SetRow(tbFront, 1);
						Grid.SetColumn(front, 0);
						Grid.SetColumn(side, 1);
						Grid.SetColumn(back, 2);
						Grid.SetColumn(tbFront, 0);
						Grid.SetColumn(tbSide, 1);
						Grid.SetColumn(tbBack, 2);
						layoutRoot.Children.Add(front);
						layoutRoot.Children.Add(tbFront);
						layoutRoot.Children.Add(tbSide);
						layoutRoot.Children.Add(side);
						layoutRoot.Children.Add(back);
						layoutRoot.Children.Add(tbBack);

						break;
				}

			}
		}

	}
}
