using Albert.Power;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aPowerDesk
{
	public class FlashCard: Notify
	{
		string name,front, back;


		/// <summary>
		/// Default Constructor 
		/// </summary>
		public FlashCard()
		{

		}
		/// <summary>
		/// Secondary Constructor 
		/// </summary>
		/// <param name="_front"></param>
		/// <param name="_back"></param>
		public FlashCard(string _name,string _front, string _back)
		{
			name = _name;
			front = _front;
			back = _back;


		}

		public string Name
		{
			get { return name; }
			set { name = value; OnPropertyChanged("Name"); }
		}

		public string Front
		{
			get { return front; }
			set { front = value; OnPropertyChanged("Front"); }
		}

		public string Back
		{
			get { return back; }
			set { back = value; OnPropertyChanged("Back"); }
		}

	}
}
