using System;

using BlueOcean.ViewModel;
using Xamarin.Forms;

namespace BlueOcean {
	public partial class RegisterPage : ContentPage {
	    private RegisterModel viewModel {
	        get { return (RegisterModel) BindingContext; }
	    }

	    public RegisterPage () {
			InitializeComponent ();

		    BindingContext = new RegisterModel();
		}

        void btnRegister_Clicked(object sender, EventArgs args) {
            viewModel.AttemptRegister();

            Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }
	}
}