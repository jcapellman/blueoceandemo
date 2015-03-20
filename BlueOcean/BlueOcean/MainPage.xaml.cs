using Xamarin.Forms;

namespace BlueOcean {
    public partial class MainPage : TabbedPage {
		public MainPage () {
			InitializeComponent ();

		    this.Children.Add(new NewsPage { Title = "News", Icon = "News.png"});
            this.Children.Add(new ProfilePage { Title = "Profile", Icon = "News.png"});

            this.ToolbarItems.Clear();
            this.ToolbarItems.Add(new ToolbarItem("logout", "", delegate {
                Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
            }));
		}
	}
}