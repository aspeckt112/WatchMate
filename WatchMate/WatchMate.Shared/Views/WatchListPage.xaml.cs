using WatchMate.Shared.ViewModels;
using Xamarin.Forms.Xaml;

namespace WatchMate.Shared.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WatchListPage
    {
        public WatchListPage()
        {
            InitializeComponent();
            BindingContext = new WatchListPageViewModel(
                navgation: Navigation
            );
        }
    }
}