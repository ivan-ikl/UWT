using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AutoMapper;
using UWT.App.Models;

namespace UWT.App {

    public sealed partial class ProductPage : Page {
        public ProductPage() {
            InitializeComponent();
        }
    
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            DataContext = Mapper.Map<ProductViewModel>(e.Parameter);
        }
    }
}
