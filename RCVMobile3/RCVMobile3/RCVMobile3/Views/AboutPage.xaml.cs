using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RCVMobile3.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            //в кавычки вам лучше вставить свою строку из письма, которое пришло вам на почту при регистрации, просто заменим London на Moskow и убрав uk. 
           
        }

        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void MenuBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Catalog(null));
        }
    }
}