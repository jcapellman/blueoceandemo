using BlueOcean.Models;

using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;

namespace BlueOcean {
	public class App : Application {
        public const string applicationURL = "https://blueoceandemo.azure-mobile.net/";
        public const string applicationKey = "yimTyOWIkvBGpDrmLmBYwKxllEaQjK17";

        public static MobileServiceClient client = new MobileServiceClient(applicationURL, applicationKey);

        public static Users CurrentUser { get; set; }

		public App () {
		    MainPage = new NavigationPage(new LoginPage());
		}

		protected override void OnStart () { }

		protected override void OnSleep () { }

		protected override void OnResume () { }
	}
}