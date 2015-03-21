using System;

using BlueOcean.Common;
using BlueOcean.ViewModel;
using Xamarin.Forms;

namespace BlueOcean {
	public partial class LoginPage : ContentPage {
	    private LoginModel viewModel {
	        get { return (LoginModel) BindingContext; }
	    }

		public LoginPage () {
			InitializeComponent ();

		    BindingContext = new LoginModel();

		    this.ToolbarItems.Clear();
            this.ToolbarItems.Add(new ToolbarItem("register", (Device.OS == TargetPlatform.WinPhone ? "register.png" : ""), delegate {
                Navigation.PushModalAsync(new NavigationPage(new RegisterPage()));
            }));
		}

        async void btnLogin_Clicked(object sender, EventArgs args) {
            var result = await viewModel.AttemptLogin();

            if (result) {
                Navigation.PushModalAsync(new NavigationPage(new MainPage()));
            } else {
                DisplayAlert(Constants.APP_NAME, "Invalid Login, try again", "ok");
            }
        }
	}
}