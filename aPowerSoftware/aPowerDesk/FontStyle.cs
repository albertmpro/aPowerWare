using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert.Power;
using System.Windows.Media;

namespace aPowerDesk
{
    public class FontStyle: Notify
    {
		string fontName;
		FontFamily font;

		public FontStyle(string _fontName)
		{
			fontName = _fontName;
			font = new FontFamily(fontName);
		}

		public FontStyle()
		{
			//Do nothing 
		}

		public FontFamily FontFamily
		{
			get { return font; }
		}

		public string FontName
		{
			get { return fontName; }
			set
			{
				fontName = value;
				font = new FontFamily(fontName);
				OnPropertyChanged("FontName");
			}
		}

    }
}
