using System.Collections.Generic;
using System.Windows.Media;

namespace GorillaGadget.Model
{
    public class Matchup
    {
        public string RelinkDate { get; set; } = string.Empty;
        public string RelinkWeek { get; set; } = string.Empty;
        public string Skirmishes { get; set; } = string.Empty;
        public string EndOfMatch { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public List<Tier> Tiers { get; set; } = new();
    }
    public class Tier
    {
        public string TierNumber { get; set; } = string.Empty;
        public List<Server> Servers { get; set; } = new();
        public List<NextMatch> NextMatchup { get; set; } = new();
    }
    public class Server
    {
        public string ServerName { get; set; } = string.Empty;
        public string ServerToolTip { get; set; } = string.Empty;
        public SolidColorBrush ServerBgColor { get; set; } = new();
        public string Rank { get; set; } = string.Empty;
        public bool Secured { get; set; }
        public string RankToolTip { get; set; } = string.Empty;
        public SolidColorBrush RankFgColor { get; set; } = new();
        public SolidColorBrush RankBgColor { get; set; } = new();
        public int VictoryPoints { get; set; }
        public SolidColorBrush VictoryPointsFgColor { get; set; } = new();
        public int WarScore { get; set; }
    }
    public class NextMatch
    {
        public string ServerName { get; set; } = string.Empty;
        public string ServerToolTip { get; set; } = string.Empty;
        public SolidColorBrush ServerBgColor { get; set; } = new();
    }
}