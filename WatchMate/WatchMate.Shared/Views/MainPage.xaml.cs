using Xamarin.Forms.Xaml;

namespace WatchMate.Shared.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage.Title;
        }
    }
}