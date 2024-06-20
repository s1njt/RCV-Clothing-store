using ClosedXML.Excel;
using ManagerRCV.Model;
using Newtonsoft.Json;
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

namespace ManagerRCV
{
    /// <summary>
    /// Логика взаимодействия для ClothesPage.xaml
    /// </summary>
    public partial class ClothesPage : Window
    {
        public ClothesPage(User userData)
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
        private void StockBtn_Click(object sender, RoutedEventArgs e)
        {
            StockBtn.Background = new SolidColorBrush(Colors.Black);
            TicketsBtn.Background = new SolidColorBrush(Colors.White);
            LoadClothesAsync();
        }

        private void TicketsBtn_Click(object sender, RoutedEventArgs e)
        {
            TciketsLB.Visibility = Visibility.Visible;
            TicketsBtn.Background = new SolidColorBrush(Colors.Black);
            StockBtn.Background = new SolidColorBrush(Colors.White);
            LoadTicketsAsync();
        }

        private void PrintTicketsBtn_Click(object sender, RoutedEventArgs e)
        {
            var ticket = TciketsLB.ItemsSource as List<Ticket>;
            if (ticket != null)
            {
                ExportToExcel(ticket);
            }
        }
        private void ExportToExcel(List<Ticket> tickets)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Clothes");

            // Заголовки
            worksheet.Cell(1, 1).Value = "ID пользователя";
            worksheet.Cell(1, 2).Value = "ID товара";
            worksheet.Cell(1, 3).Value = "Адресс доставки";
            worksheet.Cell(1, 4).Value = "Статус доставки";

            // Данные
            for (int i = 0; i < tickets.Count; i++)
            {
                var ticket = tickets[i];
                worksheet.Cell(i + 2, 1).Value = ticket.ticket_acceptUserId;
                worksheet.Cell(i + 2, 2).Value = ticket.ticket_productsId;
                worksheet.Cell(i + 2, 3).Value = ticket.ticket_deliveryAdress;
                worksheet.Cell(i + 2, 4).Value = ticket.ticket_deliveryStatus;
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

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
