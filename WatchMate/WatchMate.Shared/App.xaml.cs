using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using WatchMate.Shared.Services.Api;
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

        internal static Lazy<IApiService> LazyApiService = new(() =>
            new ApiService(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip,
            }), LazyThreadSafetyMode.PublicationOnly);
    }
}
