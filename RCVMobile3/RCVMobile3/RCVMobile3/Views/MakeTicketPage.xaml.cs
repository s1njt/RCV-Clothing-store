using Newtonsoft.Json.Linq;
using RCVMobile3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RCVMobile3.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MakeTicketPage : ContentPage
	{
        private User userData;
        private Clothe selectedItem;
        public MakeTicketPage (User userData, Clothe selectedItem)
		{
			InitializeComponent ();
            BindingContext = selectedItem;
            this.userData = userData;
            BindingContext = userData;
            this.selectedItem = selectedItem;
        }

        private async void AddTikcet_Clicked(object sender, EventArgs e)
        {
            
            
            var name = userData.Id;
            var articule = selectedItem.Id;
            var phone = userData.user_phone;
            var createdate = DateTime.UtcNow;
            var deliverydate = DateTime.UtcNow;
            var adress = Adress.Text ;
            var status = "Создан";
            var sum = selectedItem.clothe_price;

            var data = new JObject
            {
                
                {"ticket_acceptUserId",name },
                {"ticket_productsId", articule },
                {"ticket_contactNumber",phone },
                {"ticket_createDate",createdate },
                {"ticket_deliveryDate",deliverydate },
                {"ticket_deliveryAdress",adress},
                {"ticket_deliveryStatus",status},
                {"ticket_sum", sum}
            };

            var response = await HttpClientHelper.PostAsync<JObject>($"{ApiConfig.BaseUrl}/api/Tickets/AddTicket", data);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Поздравляем", "Заказ создан", "OK");
            }
            else
            {
                await DisplayAlert("Ошибка", "Вы ввели некорреткные данные", "OK");
            }
        }
    }
}