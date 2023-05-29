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
        private readonly HttpClient httpClient = new();
        private readonly MainWindowViewModel _viewModel = new();

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

            _viewModel.Matchup = MatchFactory.GetMatchup(matches, worlds);
        }
        private async Task<List<T>> FetchJsonList<T>(string url)
        {
            return JsonSerializer.Deserialize<List<T>>(await CallApi(url)) ?? new List<T>();
        }
        private async Task<string> CallApi(string url)
        {
            return await httpClient.GetAsync(url).Result.Content.ReadAsStringAsync();
        }

        private void NaButton_Checked(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel.Matchup[0];
        }

        private void EuButton_Checked(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel.Matchup[1];
        }

        private void MatchButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMatchPanel.Visibility == Visibility.Visible)
            {
                CurrentMatchPanel.Visibility = Visibility.Collapsed;
                NextMatchPanel.Visibility = Visibility.Visible;
                matchButton.Content = "Back";
            }
            else
            {
                CurrentMatchPanel.Visibility = Visibility.Visible;
                NextMatchPanel.Visibility = Visibility.Collapsed;
                matchButton.Content = "Next Match";
            }
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
    }
}
