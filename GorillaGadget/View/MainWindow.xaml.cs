using GorillaGadget.Model;
using GorillaGadget.Service;
using GorillaGadget.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace GorillaGadget
{
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient = new();
        private readonly MainWindowViewModel[] _viewModel = new MainWindowViewModel[2] { new(), new() };

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            const string worldsUrl = @"https://api.guildwars2.com/v2/worlds?ids=all";
            var worlds = (await FetchJsonList<World>(worldsUrl)).ToDictionary(x => x.Id);

            const string matchesUrl = @"https://api.guildwars2.com/v2/wvw/matches?ids=all";
            var matches = (await FetchJsonList<Match>(matchesUrl)).OrderBy(x => x.Id).ToList();

            var _matchup = MatchFactory.GetMatchup(matches, worlds);
            var _population = PopulationFactory.GetPopulation(worlds.Values.ToList());

            for (int index = 0; index < 2; index++)
            {
                _viewModel[index].Matchup = _matchup[index];
                _viewModel[index].Population = _population[index];
            }
        }

        private async Task<List<T>> FetchJsonList<T>(string url)
        {
            return JsonSerializer.Deserialize<List<T>>(await CallApi(url)) ?? new List<T>();
        }

        private async Task<string> CallApi(string url)
        {
            return await _httpClient.GetAsync(url).Result.Content.ReadAsStringAsync();
        }

        private void NaButton_Checked(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel[0];
        }

        private void EuButton_Checked(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel[1];
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MatchupWindow.Top = Properties.Settings.Default.WindowTop;
            MatchupWindow.Left = Properties.Settings.Default.WindowLeft;
            naButton.IsChecked = Properties.Settings.Default.NaSelected;
            euButton.IsChecked = Properties.Settings.Default.EuSelected;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.WindowTop = MatchupWindow.Top;
            Properties.Settings.Default.WindowLeft = MatchupWindow.Left;
            if (naButton.IsChecked == true)
            {
                Properties.Settings.Default.NaSelected = true;
            }
            else
            {
                Properties.Settings.Default.NaSelected = false;
            }

            if (euButton.IsChecked == true)
            {
                Properties.Settings.Default.EuSelected = true;
            }
            else
            {
                Properties.Settings.Default.EuSelected = false;
            }
            Properties.Settings.Default.Save();
        }

        private void populationButton_Click(object sender, RoutedEventArgs e)
        {
            if (Population_Panel.Visibility == Visibility.Collapsed)
            {
                populationButton.Content = "Back";
                PanelVisibilitySwitch(2);
            }
            else
            {
                populationButton.Content = "Population";
                PanelVisibilitySwitch(0);
            }
        }

        private void PanelVisibilitySwitch(int currentView)
        {
            switch (currentView)
            {
                case 0:
                    Current_Matchup_Panel.Visibility = Visibility.Visible;
                    Next_Matchup_Panel.Visibility = Visibility.Collapsed;
                    Population_Panel.Visibility = Visibility.Collapsed;                    
                    matchButton.Visibility = Visibility.Visible;
                    matchButton.Content = "Next Matchup";
                    break;
                case 1:
                    Current_Matchup_Panel.Visibility = Visibility.Collapsed;
                    Next_Matchup_Panel.Visibility = Visibility.Visible;
                    Population_Panel.Visibility = Visibility.Collapsed;                    
                    matchButton.Visibility = Visibility.Visible;
                    matchButton.Content = "Back";
                    break;
                case 2:
                    Current_Matchup_Panel.Visibility = Visibility.Collapsed;
                    Next_Matchup_Panel.Visibility = Visibility.Collapsed;
                    Population_Panel.Visibility = Visibility.Visible;                    
                    matchButton.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void matchButton_Click(object sender, RoutedEventArgs e)
        {
            if (Current_Matchup_Panel.Visibility == Visibility.Visible)
            {
                PanelVisibilitySwitch(1);
            }
            else
            {
                PanelVisibilitySwitch(0);
            }
        }
    }
}