using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using UWT.App.Helpers;

namespace UWT.App {
    public sealed partial class LoginPage : Page {
        public LoginPage() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            DataContext = new CredentialHelper();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var credentialHelper = (CredentialHelper) DataContext;
            var context = await WebHelper.GetContext(credentialHelper.Username, credentialHelper.Password);
            if (context == null)
            {
                ErrorMessage.Visibility = Visibility.Visible;
            }
            else
            {
                Context.UwtContext = context;
                Frame.Navigate(typeof (MainPage));
            }
        }
    }
}
