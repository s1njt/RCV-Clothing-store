using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RCVMobile3.Models;
using RCVMobile3.ViewModels;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void RegBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemsPage());
        }

        private async void AuthButton_Clicked(object sender, EventArgs e)
        {
            var email = EmailEntry.Text;
            var password = PasswordEntry.Text;

            var data = new JObject
            {
                { "user_email", email },
                { "user_password", password }
                
            };

            var response = await HttpClientHelper.PostAsync<JObject>($"{ApiConfig.BaseUrl}/api/User/Authenticate", data);

            if (response.IsSuccessStatusCode)
            {
                using (var client = new HttpClient())
                {
                    var userDataResponse = await client.GetAsync($"{ApiConfig.BaseUrl}/api/User/GetUserByEmailAndPassword?email=" + email + "&password=" + password);

                    if (userDataResponse.IsSuccessStatusCode)
                    {
                        var userDataString = await userDataResponse.Content.ReadAsStringAsync();
                        var userData = JsonConvert.DeserializeObject<User>(userDataString);

                        // Передача данных на следующую страницу
                        await Navigation.PushAsync(new ProfilePage(userData));
                    }
                    else
                    {
                        await DisplayAlert("Error", "User not found", "OK");
                    }
                }
            }
            else
            {
                await DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }
    }
    
}