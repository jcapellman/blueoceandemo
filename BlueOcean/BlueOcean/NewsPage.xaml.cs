using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
	}
}