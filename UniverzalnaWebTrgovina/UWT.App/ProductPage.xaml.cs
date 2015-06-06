using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UWT.App {

    public sealed partial class ProductPage : Page {
        public ProductPage() {
            InitializeComponent();
        }
    
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            DataContext = e.Parameter;
        }
    }
}
