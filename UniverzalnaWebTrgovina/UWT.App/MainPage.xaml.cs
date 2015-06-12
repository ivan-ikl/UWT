using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UWT.App
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = Context.UwtContext;
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Frame.Navigate(typeof (ShopPage), ((ListView) sender).SelectedItem);
        }
    }
}
