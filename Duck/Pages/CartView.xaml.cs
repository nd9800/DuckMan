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
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Duck.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CartView : Page
    {

       
        Cart cart = new Cart();
        public CartView()
        {
            this.InitializeComponent();
            
            CartList.ItemsSource = cart.GetCart();
        

        }

        private async void Delete_Item(object sender, RoutedEventArgs e)
        {
           
            Button b = (sender) as Button;
            var cid = Convert.ToInt32(b.CommandParameter);
            for (int i = 0; i < cart.GetCart().Count; i++)
            {
                if (cart.GetCart()[i].id == cid)
                {
                    cart.RemoveItem(cart.GetCart()[i]);
                    break;
                }
            }
            var dialog = new MessageDialog("Done");
            CartFrame.Navigate(typeof(CartView));
            await dialog.ShowAsync();
        }

        private async void Update_Item(object sender, RoutedEventArgs e)
        {
          
      
            Button b = (sender) as Button;
            var cid = Convert.ToInt32(b.CommandParameter);
            for (int i = 0; i < cart.GetCart().Count; i++)
            {
                if (cart.GetCart()[i].id == cid)
                {
                    cart.UpdateCart(cart.GetCart()[i],6);
                    break;
                }
            }
            var dialog = new MessageDialog("Done");
            CartFrame.Navigate(typeof(CartView));
            await dialog.ShowAsync();
        }

   
    }
}
