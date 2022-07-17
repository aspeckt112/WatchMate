using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using WatchMate.Shared.Services.Api;
using WatchMate.Shared.Services.Configuration;
using WatchMate.Shared.Views;
using Xamarin.Forms;

namespace WatchMate.Shared
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            base.OnStart();
            ReconcileConfiguration();
        }

        protected override void OnResume()
        {
            base.OnResume();
            ReconcileConfiguration();
        }

        internal static Lazy<IApiService> LazyApiService = new(() =>
            new ApiService(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip,
            }), LazyThreadSafetyMode.PublicationOnly);

        internal static Lazy<IConfigurationService> LazyConfigurationService =
            new(() => new ConfigurationService(LazyApiService.Value), LazyThreadSafetyMode.PublicationOnly);

        void ReconcileConfiguration() => LazyConfigurationService.Value.ReconcileConfiguration();
    }
}
