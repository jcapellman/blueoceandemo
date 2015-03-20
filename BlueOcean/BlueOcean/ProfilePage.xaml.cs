using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueOcean.ViewModel;
using Xamarin.Forms;

namespace BlueOcean
{
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
			InitializeComponent ();

		    BindingContext = new ProfileModel();


		}
	}
}
