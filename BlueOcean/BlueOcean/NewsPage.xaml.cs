using BlueOcean.ViewModel;
using Xamarin.Forms;

namespace BlueOcean {
	public partial class NewsPage : ContentPage {
	    private NewsModel viewModel {
	        get { return (NewsModel) this.BindingContext; }
	    }

		public NewsPage () {
			InitializeComponent ();

		    BindingContext = new NewsModel();

            viewModel.LoadData();
		}

        void lvNews_Refreshing(object sender, System.EventArgs e) {
	        viewModel.LoadData();
             
	    }
	}
}