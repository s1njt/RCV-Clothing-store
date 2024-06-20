using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RCVMobile3.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RCVMobile3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketsPage : ContentPage
    {
        private User userData;
        public TicketsPage(User userData)
        {
            InitializeComponent();
            this.userData = userData;
            BindingContext = userData;
        }

        private void LoginBtn_Clicked(object sender, EventArgs e)
        {

        }

        private void MenuBtn_Clicked(object sender, EventArgs e)
        {

        }

        private void TicketsLV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Получение ID пользователя, для которого нужно получить данные о заказах и вещах

            string url = $"{ApiConfig.BaseUrl}/api/Tickets/GetTicketsWithClotheForUser?userId=" + Convert.ToString(userData.Id);
            

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<TicketWithClothe> ticketsWithClothe = JsonConvert.DeserializeObject<List<TicketWithClothe>>(json);

                    // Привязка данных к ListView
                    TicketsLV.ItemsSource = ticketsWithClothe;
                }
                else
                {
                    // Обработка ошибки, если запрос не удался
                }
            }
        }
    }
}