using CommunityToolkit.Mvvm.ComponentModel;
using GorillaGadget.Model;

namespace GorillaGadget.ViewModel
{
    public sealed partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty] Matchup[] _matchup = new Matchup[2];
    }
}