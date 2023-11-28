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

    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();



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
            

            webBrowser.Navigate("https://mail.google.com/mail/u/4/#inbox"); // (come back later)
        }
       

    }
}
