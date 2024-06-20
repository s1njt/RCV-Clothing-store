using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCVMobile3.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RCVMobile3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Catalog : ContentPage
    {
        private User userData;
        public Catalog(User userData)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.userData = userData;
            BindingContext = userData;

        }

        private async void CatalogMenuBtn_Clicked(object sender, EventArgs e)
        {
            CatalogMenuSL.IsVisible = true;
            await CatalogMenuSL.FadeTo(1, 1000);
        }

        private async void AuhClickBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void NovinkiButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NovinkiPage(userData));
        }

        private async void ProfileBtn_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}