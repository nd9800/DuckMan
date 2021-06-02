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


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Duck.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Category : Page
    {
        public Category()
        {
            this.InitializeComponent();
            GetMenu();
        }

     
        public async void GetMenu()
        {
            // cach lay tu api va nap vao ItemList
            /*  HttpClient httpClient = new HttpClient();//shipper
              var response = await (httpClient.GetAsync("https://foodgroup.herokuapp.com/api/menu"));
              if(response.StatusCode == HttpStatusCode.OK)
              {
                  var stringcontent = await response.Content.ReadAsStringAsync(); //da lay duoc het api qua dang string //read response content
                                                                                  // convert string content sang object

                 CategoryList g = JsonConvert.DeserializeObject<CategoryList>(stringcontent);
                  ItemList.Items.Add(g.data);

              }

              */
            MenuService mn = new MenuService();
            Root g = await mn.GetMenu();
            
            if (g != null)
            {
                CList.ItemsSource = g.data.foods;
          

            }
        }

    
        private void CList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            ListView view = (ListView)sender;

            var selectedItem = view.SelectedItem;
           
            SubFrame.Navigate(typeof(Pages.Detail),selectedItem);
        }
    }
}
