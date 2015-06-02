using Windows.Phone.UI.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UWT.App {
    public sealed partial class ShopPage : Page {
        public ShopPage() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = e.Parameter;
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Frame.Navigate(typeof (CategoryPage), ((ListView) sender).SelectedItem);
        }
    }
}
