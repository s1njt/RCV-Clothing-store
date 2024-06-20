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
    public partial class ProfilePage : ContentPage
    {
        private User userData;

        public ProfilePage(User userData)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.userData = userData;

            EmailLabel.Text = userData.user_email;
                NickLabel.Text = userData.user_nickname;
                PhoneLabel.Text = userData.user_phone;
                CityLabel.Text = userData.user_city;
            var NavUD = userData;
        }

        private async void EditProfileBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProfilePage(userData));
        }

        private async void TicketsBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TicketsPage(userData));
        }

        private void TicketsLV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private async void MenuBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Catalog(userData));
        }

        private async void CartBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage(userData));
        }
    }
}