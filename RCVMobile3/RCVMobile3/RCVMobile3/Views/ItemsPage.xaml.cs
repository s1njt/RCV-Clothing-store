using Newtonsoft.Json.Linq;
using RCVMobile3.Models;
using RCVMobile3.ViewModels;
using RCVMobile3.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml; 

namespace RCVMobile3.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            var id = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            var name = NameEntry.Text;
            var surname = SurnameEntry.Text;
            var phone = PhoneEntry.Text;
            var nickname = NickNameEntry.Text;
            var email = EmailEntry.Text;
            var password = PasswordEntry.Text;
            var city = "arzamas";

            var data = new JObject
            {
                {"Id",id },
                {"user_email",email },
                {"user_password", password },
                {"user_name",name },
                {"user_surname",surname },
                {"user_phone",phone },
                {"user_nickname",nickname},
                {"user_city",city}
            };

            var response = await HttpClientHelper.PostAsync<JObject>($"{ApiConfig.BaseUrl}/api/User/AddUser", data);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Поздравляем", "Вы зарегестрировались", "OK");
            }
            else
            {
                await DisplayAlert("Ошибка", "Вы ввели некорреткные данные", "OK");
            }
        }
    }
}