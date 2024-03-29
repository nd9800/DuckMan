﻿using System;
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
    public sealed partial class Home_page : Page
    {
        public Home_page()
        {
            this.InitializeComponent();
            GetHome();
        }
        public async void GetHome()
        {
            HttpClient httpClient = new HttpClient();//shipper
            var response = await (httpClient.GetAsync("https://foodgroup.herokuapp.com/api/today-special"));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stringcontent = await response.Content.ReadAsStringAsync(); //da lay duoc het api qua dang string //read response content
                                                                                // convert string content sang object
                RootHome g = JsonConvert.DeserializeObject<RootHome>(stringcontent);
                HList.ItemsSource = g.data;
            }
        }

        private void HList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView view = (ListView)sender;

            var selectedItem = view.SelectedItem;

            HomeFrame.Navigate(typeof(Pages.Detail), selectedItem);
        }
    }
}
