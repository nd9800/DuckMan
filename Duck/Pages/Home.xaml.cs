using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Duck.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Duck.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        public Home()
        {
            this.InitializeComponent();
        }

        private void Menu_Loaded(object sender, RoutedEventArgs e)
        {

            MenuItem m = new MenuItem("57615", "Home");
            MenuItem m1 = new MenuItem("57721", "Category");
            MenuItem m2 = new MenuItem("57677", "Cart");


            Menu.Items.Add(m); Menu.Items.Add(m1); Menu.Items.Add(m2);
        }

        private void ListViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MenuItem item = Menu.SelectedItem as MenuItem;
            switch (item.Title)
            {
                case "Home":
                    MainFrame.Navigate(typeof(Pages.Home_page));
                    break;
                case "Category":
                    MainFrame.Navigate(typeof(Pages.Category));
                    break;
                case "Cart":
                    MainFrame.Navigate(typeof(Pages.CartView));
                    break;


            }
        }

        private void pic1_Click(object sender, RoutedEventArgs e)
        {

        }

     
      
    }
}
