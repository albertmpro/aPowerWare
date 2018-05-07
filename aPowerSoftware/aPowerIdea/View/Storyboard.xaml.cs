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
using Windows.Graphics.Display;


namespace aPowerIdea.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Storyboard : Page10x
    {
		SBMode mode;
        public Storyboard()
        {
            this.InitializeComponent();
			

			
			

		}

		public SBMode SBMode
		{
			get { return mode; }
			set
			{
				mode = value;
				switch(value)
				{
					case SBMode.Vert: // Portrait
						DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
						break;

					case SBMode.Horz:  // Landscape Mode
						DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape;
						break;
					default: // Portrait Mode
						DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
						break;

						
						
				}
			}
		}

		


    }

	public enum SBMode
	{
		Vert,Horz
	}
}
