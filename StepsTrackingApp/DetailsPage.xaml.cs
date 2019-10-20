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

            this.StaticMapImage.Source = $"https://api.mapbox.com/styles/v1/mapbox/light-v9/static/-82.9332,40.1261,13.58,0,0/300x200@2x?access_token={ApiKeys.MAPBOX_API_KEY}";
        }

        private async void MenuTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await this.MenuButton.FadeTo(0, 25);
            await this.MenuButton.FadeTo(1, 25);
            await this.Navigation.PopModalAsync();
        }
    }
}