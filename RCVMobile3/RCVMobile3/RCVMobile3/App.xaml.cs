using RCVMobile3.Services;
using RCVMobile3.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RCVMobile3
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new AboutPage()) // здесь укажите вашу основную страницу
            {
                BarBackgroundColor = Color.Black, // Это для изменения цвета фона навигационного бара, если нужно
                BarTextColor = Color.White // Это для изменения цвета текста в навигационном баре, если нужно
            };
            NavigationPage.SetHasNavigationBar(MainPage, false); // Скрыть навигационный бар
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
