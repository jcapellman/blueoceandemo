using System;

using BlueOcean.Common;
using BlueOcean.ViewModel;
using Xamarin.Forms;

namespace BlueOcean {
	public partial class ProfilePage : ContentPage {
	    private ProfileModel viewModel {
	        get { return (ProfileModel) BindingContext; }
	    }

		public ProfilePage () {
			InitializeComponent ();

		    BindingContext = new ProfileModel();
		}

	    private void btnUpdate_Clicked(object sender, EventArgs args) {
	        viewModel.UpdateProfile();

            DisplayAlert(Constants.APP_NAME, "Update successful", "ok");
	    }
	}
}