using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RCVdesktopchik.Models;

namespace RCVdesktopchik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var email = LoginTextBox.Text;
            var password = PasswodInputBox.Password;

            var data = new JObject
            {
                { "user_email", email },
                { "user_password", password }

            };

            var response = await HttpClientHelper.PostAsync<JObject>("http://192.168.45.250:3000/api/User/Authenticate", data);

            if (response.IsSuccessStatusCode)
            {
                using (var client = new HttpClient())
                {
                    var userDataResponse = await client.GetAsync("http://192.168.45.250:3000/api/User/GetUserByEmailAndPassword?email=" + email + "&password=" + password);

                    if (userDataResponse.IsSuccessStatusCode)
                    {
                        var userDataString = await userDataResponse.Content.ReadAsStringAsync();
                        var userData = JsonConvert.DeserializeObject<User>(userDataString);

                        // Передача данных на следующую страницу
                       AdminMainPage adminMainPage = new AdminMainPage(userData);
                        adminMainPage.Show();
                        this.Hide();
                    }
                    else
                    {
                         MessageBox.Show("Пользователь не найден");
                    }
                }
            }
            else
            {
                MessageBox.Show("Неправильно введены данные");
            }
        }
    }
}
