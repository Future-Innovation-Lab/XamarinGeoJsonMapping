using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinGeoJsonMapping.Views;

namespace XamarinGeoJsonMapping
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MapGeoJsonPage());
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
