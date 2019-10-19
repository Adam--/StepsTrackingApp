using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StepsTrackingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage()
        {
            InitializeComponent();
        }

        private async void MenuTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await this.MenuButton.FadeTo(0, 25);
            await this.MenuButton.FadeTo(1, 25);
            await this.Navigation.PopModalAsync();
        }
    }
}