using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RCVMobile3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RCVMobile3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        private User userData;

        public CartPage(User userData)
        {
            InitializeComponent();
            this.userData = userData;


        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Получение ID пользователя, для которого нужно получить данные о заказах и вещах

            string url = $"{ApiConfig.BaseUrl}/api/Cart/GetCartUser?userId=" + Convert.ToString(userData.Id);


            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<CartWithClothe> ticketsWithClothe = JsonConvert.DeserializeObject<List<CartWithClothe>>(json);

                    // Привязка данных к ListView
                    TicketsLV.ItemsSource = ticketsWithClothe;
                }
                else
                {
                    // Обработка ошибки, если запрос не удался
                }
            }
        }

        private async void PayCart_Clicked(object sender, EventArgs e)
        {

            var userid = Convert.ToString(userData.Id);
            var items = TicketsLV.ItemsSource;

            foreach (var item in items)
            {
                var cartWithClothe = item as CartWithClothe;
                if (cartWithClothe != null)
                {
                    var clothe = cartWithClothe.Clothe;
                    var cart = cartWithClothe.Cart;

                    var data = new JObject
        {
            {"ticket_acceptUserId", userid}, // Используем UserID из переменной
            {"ticket_productsId", clothe.Id}, // Используем Id товара
            {"ticket_contactNumber", "Номер телефона"}, // Укажите соответствующие значения
            {"ticket_createDate", DateTime.Now}, // Укажите соответствующие значения
            {"ticket_deliveryDate", DateTime.Now}, // Укажите соответствующие значения
            {"ticket_deliveryAdress", "Адрес доставки"}, // Укажите соответствующие значения
            {"ticket_deliveryStatus", "Статус доставки"}, // Укажите соответствующие значения
            {"ticket_sum", cart.cart_price} // Используем цену из объекта корзины
        };

                    var response = await HttpClientHelper.PostAsync<JObject>($"{ApiConfig.BaseUrl}/api/Tickets/AddTicket", data);

                    if (response.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Успех", "Товары успешно добавлены", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Ошибка", "Не удалось добавить товары", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("oshibka","ok","ne");
                }
            }
        }

    }
}