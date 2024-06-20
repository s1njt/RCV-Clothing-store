using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RCVdesktopchik
{
    /// <summary>
    /// Логика взаимодействия для AddClothePage.xaml
    /// </summary>
    public partial class AddClothePage : Window
    {
        public AddClothePage()
        {
            InitializeComponent();
        }

        private async void AddClothePage_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private async void  AddClothe_Click(object sender, RoutedEventArgs e)
        {
            var name = NameTB.Text;
            var price = PriceTB.Text;
            var description = DescriptionTB.Text;
            var csize = SizeTB.Text;
            var ctype = Convert.ToInt32(TypeTB.Text);
            var image = PhotoTB.Text;
            var color = "ЧЁРНЫЙ";
            var textile = "ХЛОПОК 100%";

            var data = new JObject
            {
                {"clothe_name",name },
                {"clothe_price",price },
                {"clothe_description",description },
                {"clothe_size",csize },
                {"clothe_type",ctype },
                {"clothe_image",image },
                {"clothe_color",color},
                {"clothe_textile",textile}
            };

            var response = await HttpClientHelper.PostAsync<JObject>("http://192.168.45.250:3000/api/Clothes/AddClothe", data);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Товар " + name + " был успешно добавлен");
            }
            else
            {
                MessageBox.Show("Данные введены некорреткно");
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminMainPage adminMainPage = new AdminMainPage(null);
            adminMainPage.Show();
            this.Hide();
        }
    }
    
}
