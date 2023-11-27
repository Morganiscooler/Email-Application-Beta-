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
namespace Email
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            webBrowser.Navigate(new Uri("https://www.gmail.com"));
            webBrowser.LoadCompleted += WebBrowser_LoadCompleted;

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void webBrowser_Loaded(object sender, RoutedEventArgs e)
        {
            

            //webBrowser.Navigate("https://mail.google.com/mail/u/4/#inbox"); (come back later)
        }
        private void WebBrowser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            // Injecting JavaScript to fill in the login form
            dynamic document = webBrowser.Document;
            dynamic loginElement = document.getElementById("identifierId");
            dynamic passwordElement = document.getElementsByName("password")[0];

            if (loginElement != null && passwordElement != null)
            {
                loginElement.value = "YourEmailAddress@gmail.com";
                passwordElement.value = "YourPassword";

                // Submitting the form
                document.forms[0].submit();

            }           
        }
    }
}
