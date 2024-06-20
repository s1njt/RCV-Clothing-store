using Newtonsoft.Json.Linq;
using RCVMobile3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RCVMobile3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketPage : ContentPage
    {
        private User userData;
        private Clothe selectedItem;
        public TicketPage(Clothe selectedItem, User userData)
        {
            InitializeComponent();
            BindingContext = selectedItem;
            this.userData = userData;
            this.selectedItem = selectedItem;

        }

        private async void MakeTicket_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MakeTicketPage(userData,selectedItem));
        }

        private string labelTextToCopy;

        private  void OnLabelTapped(object sender, EventArgs e)
        {
            var label = (Label)sender;
            labelTextToCopy = label.Text;
            Clipboard.SetTextAsync(labelTextToCopy);
        }

        private async void AddCart_Clicked(object sender, EventArgs e)
        {
            var id = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            var added_user = Convert.ToString(userData.Id);
            var added_clothe = Convert.ToString(selectedItem.Id);
            var added_price = Convert.ToInt32(selectedItem.clothe_price);


            var data = new JObject
            {
                {"Id",id },
                {"cart_user",added_user },
                {"cart_clotheid", added_clothe },
                {"cart_price",added_price },

            };

            var response = await HttpClientHelper.PostAsync<JObject>($"{ApiConfig.BaseUrl}/api/Cart/AddCart", data);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Поздравляем", "Товар добавлен в корзину", "OK");
            }
            else
            {
                await DisplayAlert("Ошибка", "В данный момент нельзя добавить", "OK");
            }
        }
    }
}