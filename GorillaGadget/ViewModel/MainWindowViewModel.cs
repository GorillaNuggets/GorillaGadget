using CommunityToolkit.Mvvm.ComponentModel;
using GorillaGadget.Model;
using System.Collections.Generic;

namespace GorillaGadget.ViewModel
{
    public sealed partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty] Matchup _matchup = new();
        [ObservableProperty] List<PopulationModel> _population = new();
    }
}