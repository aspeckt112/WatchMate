using System.Threading.Tasks;
using WatchMate.Shared.Views;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace WatchMate.Shared.ViewModels
{
    internal class WatchListPageViewModel : BaseViewModel
    {
        readonly INavigation _navgation;

        public WatchListPageViewModel(INavigation navgation)
        {
            _navgation = navgation;
        }

        AsyncCommand? _goToSearchPageCommand;

        public AsyncCommand GoToSearchPageCommand =>
            _goToSearchPageCommand ??= new AsyncCommand(OnGoToSearchPageCommandExecuted);

        async Task OnGoToSearchPageCommandExecuted()
        {
            await _navgation.PushAsync(new SearchPage()).ConfigureAwait(false);
        }
    }
}