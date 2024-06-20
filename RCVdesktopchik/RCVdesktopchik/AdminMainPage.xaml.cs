using Newtonsoft.Json;
using RCVdesktopchik.Models;
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
using System.Windows.Shapes;
using ClosedXML;
using ClosedXML.Excel;

namespace RCVdesktopchik
{
    /// <summary>
    /// Логика взаимодействия для AdminMainPage.xaml
    /// </summary>
    public partial class AdminMainPage : Window
    {
        public  AdminMainPage(User userData)
        {
            InitializeComponent();

            DataContext = userData;

           
            LoadClothesAsync();
        }

        private async void LoadClothesAsync()
        {
            string url = "http://192.168.45.250:3000/api/CLothes/GetClothes";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string json = await response.Content.ReadAsStringAsync();

                    // Десериализация JSON в список объектов Clothe
                    List<Clothe> clothes = JsonConvert.DeserializeObject<List<Clothe>>(json);

                    // Установка свойства ItemsSource ListView на список объектов Clothe
                    ClothesLB.ItemsSource = clothes;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Ошибка HTTP-запроса: {ex.Message}");
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Ошибка десериализации JSON: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
        private async void LoadTicketsAsync()
        {
            string url = "http://192.168.45.250:3000/api/Tickets/GetTickets";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string json = await response.Content.ReadAsStringAsync();

                    // Десериализация JSON в список объектов Clothe
                    List<Ticket> clothes = JsonConvert.DeserializeObject<List<Ticket>>(json);

                    // Установка свойства ItemsSource ListView на список объектов Clothe
                    TciketsLB.ItemsSource = clothes;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Ошибка HTTP-запроса: {ex.Message}");
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Ошибка десериализации JSON: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void AddClotheNavigate_Click(object sender, RoutedEventArgs e)
        {
            AddClothePage addClothePage = new AddClothePage();
            addClothePage.Show();
            this.Hide();
        }

        private void SupportButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void PrintStatistic_Click(object sender, RoutedEventArgs e)
        {
            var clothe = ClothesLB.ItemsSource as List<Clothe>;
            if (clothe != null)
            {
                ExportToExcel(clothe);
            }
        }
        private void ExportToExcel(List<Clothe> clothes)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Clothes");

            // Заголовки
            worksheet.Cell(1, 1).Value = "Image";
            worksheet.Cell(1, 2).Value = "Name";
            worksheet.Cell(1, 3).Value = "Price";
            worksheet.Cell(1, 4).Value = "Size";

            // Данные
            for (int i = 0; i < clothes.Count; i++)
            {
                var ticket = clothes[i];
                worksheet.Cell(i + 2, 1).Value = ticket.clothe_image;
                worksheet.Cell(i + 2, 2).Value = ticket.clothe_name;
                worksheet.Cell(i + 2, 3).Value = ticket.clothe_price;
                worksheet.Cell(i + 2, 4).Value = ticket.clothe_size;
            }

            // Сохранить файл
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Save an Excel File"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                workbook.SaveAs(saveFileDialog.FileName);
            }
        }

        private void TicketsButton_Click(object sender, RoutedEventArgs e)
        {
            TciketsLB.Visibility = Visibility.Visible;
            TicketsButton.Background = new SolidColorBrush(Colors.Black);
            StockButton.Background = new SolidColorBrush(Colors.White);
            LoadTicketsAsync();
        }

        private void StockButton_Click(object sender, RoutedEventArgs e)
        {
            StockButton.Background = new SolidColorBrush(Colors.Black);
            TicketsButton.Background = new SolidColorBrush(Colors.White);
            LoadClothesAsync();
        }

        private async void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

          
    }
}
