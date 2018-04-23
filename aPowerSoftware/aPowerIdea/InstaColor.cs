using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert.Power.Runtime;
using Albert.Power;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace aPowerIdea
{
	public class InstaBrushes: Notify 
	{
		//Private Field's 
		string name;
		Brush border, back, fore;

		public string Name
		{
			get { return name; }
			set { name = value; OnPropertyChanged("Name"); }

		}

		public Brush Border
		{
			get { return border; }
			set { border = value; OnPropertyChanged("Border"); }
		}

		public Brush PaperBrush
		{
			get { return back; }
			set { back = value; OnPropertyChanged("PaperBrush"); }
		}

		public Brush TextBrush
		{
			get { return fore; }
			set { fore = value; OnPropertyChanged("TextBrush"); }
		}






	}
}
