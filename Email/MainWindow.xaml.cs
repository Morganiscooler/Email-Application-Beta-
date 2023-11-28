using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
namespace Email
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string ClientId = "YourClientId";
        private const string RedirectUri = "urn:ietf:wg:oauth:2.0:oob";
        private const string AuthEndpoint = "https://accounts.google.com/o/oauth2/auth";
        private const string TokenEndpoint = "https://oauth2.googleapis.com/token";
        private const string Scope = "https://www.googleapis.com/auth/userinfo.profile";
        public MainWindow()
        {

            InitializeComponent();

            // Start the OAuth process
            StartOAuth();

        }
        private void StartOAuth()
        {
            // Generate the authorization URL
            var authorizationUrl = $"{AuthEndpoint}?client_id={ClientId}&redirect_uri={RedirectUri}&scope={Scope}&response_type=code";

            // Navigate to the authorization URL
            webBrowser.Source = new Uri(authorizationUrl);
        }

        private void Tab1_Clicked(object sender, MouseButtonEventArgs e)
        {
            
        }
        private void Tab2_Clicked(object sender, MouseButtonEventArgs e)
        {

        }
        private void Tab3_Clicked(object sender, MouseButtonEventArgs e)
        {

        }

        private void webBrowser_Loaded(object sender, RoutedEventArgs e)
        {
            

            //webBrowser.Navigate("https://mail.google.com/mail/u/4/#inbox"); (come back later)
        }
        private async void WebBrowser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            // Check if the URL contains the authorization code
            if (webBrowser.Source.AbsoluteUri.StartsWith(RedirectUri))
            {
                // Parse the authorization code from the URL
                var queryString = webBrowser.Source.Query;
                var parameters = HttpUtility.ParseQueryString(queryString);
                var authorizationCode = parameters.Get("code");

                // Exchange the authorization code for an access token
                var accessToken = await ExchangeCodeForAccessToken(authorizationCode);

                // You can now use the accessToken to make requests to the Google API
                MessageBox.Show($"Access Token: {accessToken}");

                // Close the window or perform further actions as needed
                Close();
            }
        }
        private async Task<string> ExchangeCodeForAccessToken(string authorizationCode)
        {
            using (var client = new HttpClient())
            {
                var requestBody = $"code={authorizationCode}&client_id={ClientId}&client_secret=YourClientSecret&redirect_uri={RedirectUri}&grant_type=authorization_code";

                var response = await client.PostAsync(TokenEndpoint, new StringContent(requestBody));
                var responseContent = await response.Content.ReadAsStringAsync();

                // Parse the access token from the response
                var parameters = HttpUtility.ParseQueryString(responseContent);
                return parameters.Get("access_token");
            }
        }

    }
}
