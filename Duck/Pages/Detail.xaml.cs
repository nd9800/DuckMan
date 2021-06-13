using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
using Newtonsoft.Json;
using Duck.Services;
using Duck.Models;
using Windows.UI.Popups;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Duck.Pages
{
    
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Detail : Page
    {
        int id;
        public Detail()
        {
            this.InitializeComponent();
    
     
        }
     
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var item = e.Parameter as Food;
            switch (item)
            {
                case null:
                    var item2 = e.Parameter as HomeList;
                    id = item2.id;
                    base.OnNavigatedTo(e);
                    GetFood();
                    break;
                default:
                    id = item.id;
                    base.OnNavigatedTo(e);
                    GetFood();
                    break;

            }

          

        }

        public async void GetFood()
        {

            HttpClient httpClient = new HttpClient();//shipper
            var response = await (httpClient.GetAsync("https://foodgroup.herokuapp.com/api/food/" + id));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stringcontent = await response.Content.ReadAsStringAsync(); //da lay duoc het api qua dang string //read response content
                                                                                // convert string content sang object

                Root2 g2 = JsonConvert.DeserializeObject<Root2>(stringcontent);

                detailList.Items.Add(g2.data);
            }


        }

        private async void Button_ClickCart(object sender, RoutedEventArgs e)
        {
            Cart cart = new Cart();
            var item = (DetailList)detailList.Items[0];
            
         

                    CartItem c = new CartItem(item.id, item.name, item.image, item.price, 1);

                    cart.AddToCart(c);
                   

            var dialog = new MessageDialog("Done");
            await dialog.ShowAsync();
        }
    }
}
