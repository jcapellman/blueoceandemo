using System;

using BlueOcean.ViewModel;
using Xamarin.Forms;

namespace BlueOcean {
	public partial class LoginPage : ContentPage {
		public LoginPage () {
			InitializeComponent ();

		    BindingContext = new LoginModel();

		    this.ToolbarItems.Clear();
            this.ToolbarItems.Add(new ToolbarItem("register", "", delegate {
                Navigation.PushModalAsync(new NavigationPage(new RegisterPage()));
            }));
		}

        void btnLogin_Clicked(object sender, EventArgs args) {
            Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }
	}
}