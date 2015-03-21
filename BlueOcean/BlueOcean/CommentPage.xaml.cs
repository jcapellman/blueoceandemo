using System;
using BlueOcean.ViewModel;
using Xamarin.Forms;

namespace BlueOcean {
	public partial class CommentPage : ContentPage {
        private CommentModel viewModel {
            get { return (CommentModel)this.BindingContext; }
        }

		public CommentPage () {
			InitializeComponent ();

		    BindingContext = new CommentModel();

            viewModel.LoadComments();
		}

        async void btnPost_Clicked(object sender, EventArgs args) {
            var result = await viewModel.PostComment();

            if (result) {
                viewModel.LoadComments();
            }
        }
	}
}