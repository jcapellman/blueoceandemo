using BlueOcean.Models;
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

	    private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
            if (lvNews.SelectedItem == null) {
                return;
            }

            App.SelectedNewsID = ((News)lvNews.SelectedItem).id;

            Navigation.PushModalAsync(new NavigationPage(new CommentPage()));
	    }
	}
}