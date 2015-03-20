using System;

using BlueOcean.ViewModel;
using Xamarin.Forms;

namespace BlueOcean {
	public partial class RegisterPage : ContentPage {
		public RegisterPage () {
			InitializeComponent ();

		    BindingContext = new RegisterModel();
		}

        void btnRegister_Clicked(object sender, EventArgs args) {
            Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }
	}
}