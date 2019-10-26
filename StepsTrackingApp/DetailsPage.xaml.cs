using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StepsTrackingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        private CancellationTokenSource getLocationTokenSource;

        public DetailsPage()
        {
            InitializeComponent();
            this.Appearing += this.DetailsPage_Appearing;
            this.Disappearing += this.DetailsPage_Disappearing;
        }

        private void DetailsPage_Disappearing(object sender, EventArgs e)
        {
            if (getLocationTokenSource != null && !getLocationTokenSource.IsCancellationRequested)
            {
                getLocationTokenSource.Cancel();
            }
        }

        private async void DetailsPage_Appearing(object sender, EventArgs e)
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                this.getLocationTokenSource = new CancellationTokenSource(30000);
                var request = new GeolocationRequest(GeolocationAccuracy.Low);
                location = await Geolocation.GetLocationAsync(request, getLocationTokenSource.Token);
            }
            this.StaticMapImage.Source = $"https://api.mapbox.com/styles/v1/mapbox/light-v9/static/{location.Longitude},{location.Latitude},13.58,0,0/300x200@2x?access_token={ApiKeys.MAPBOX_API_KEY}";
        }

        private async void MenuTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await this.MenuButton.FadeTo(0, 25);
            await this.MenuButton.FadeTo(1, 25);
            await this.Navigation.PopModalAsync();
        }
    }
}