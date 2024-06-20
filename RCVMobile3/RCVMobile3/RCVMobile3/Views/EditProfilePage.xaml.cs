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
    public partial class EditProfilePage : ContentPage
    {
        private User userData;
        public EditProfilePage(User userData)
        {
            InitializeComponent();
            this.userData = userData;
            BindingContext = userData;
        }

        private void MenuBtn_Clicked(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Clicked(object sender, EventArgs e)
        {

        }

        private async void EditBtn_Clicked(object sender, EventArgs e)
        {
            var id = userData.Id;
            var name = NameEntry.Text;
            var surname = SurnameEntry.Text;
            var phone = PhoneEntry.Text;
            var nickname = NickNameEntry.Text;
            var email = EmailEntry.Text;
            var password = PasswordEntry.Text;
            var city = CityEntry.Text;

            var data = new JObject
            {
                {"user_email",email },
                {"user_password", password },
                {"user_name",name },
                {"user_surname",surname },
                {"user_phone",phone },
                {"user_nickname",nickname},
                {"user_city",city}
            };

            var apiUrl = $"{ApiConfig.BaseUrl}/api/User/UpdateUser/" + Convert.ToString(userData.Id);
            var content = new StringContent(data.ToString(), Encoding.UTF8, "application/json");

            var httpClient = new HttpClient();
            var response = await httpClient.PutAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Поздравляем", "Данные успешно обновлены", "OK");
            }
            else
            {
                await DisplayAlert("Ошибка", "Произошла ошибка при обновлении данных", "OK");
            }
        }
    }
}