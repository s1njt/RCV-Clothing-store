using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using RCVMobile3.Models;
using System.Net.Http;

namespace RCVMobile3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovinkiPage : ContentPage
    {
        private User userData;
        public NovinkiPage(User userData)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.userData = userData;
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            string url = $"{ApiConfig.BaseUrl}/api/CLothes/GetClothes";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();

                // Десериализация JSON в список объектов Clothe
                List<Clothe> clothes = JsonConvert.DeserializeObject<List<Clothe>>(json);

                // Установка свойства ItemsSource ListView на список объектов Clothe
                ClotheLV.ItemsSource = clothes;
            }
        }

        private async void ClotheLV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedItem = (Clothe)e.SelectedItem;

            // Передача данных на следующую страницу
            await Navigation.PushAsync(new TicketPage(selectedItem,userData));

            // Сбросить выбранный элемент
            
        }
    }
}
