using GorillaGadget.Model;
using System.Windows.Media;

namespace GorillaGadget.Service
{
    public class SortServers
    {
        //
        //  Check for tie scores and sort the next matchup list
        //
        public static Matchup[] SortNextMatchup(Matchup[] matchup)
        {
            for (int region = 0; region < 2; region++)
            {
                var relinkDate = Relinks.GetRelinkDate().ToShortDateString();
                switch (matchup[region].EndDate != relinkDate)
                {
                    case true:
                        for (int tier = 0; tier < matchup[region].Tiers.Count - 1; tier++)
                        {
                            if (matchup[region].Tiers[tier].Servers[1].VictoryPoints != matchup[region].Tiers[tier].Servers[2].VictoryPoints
                                && matchup[region].Tiers[tier + 1].Servers[0].VictoryPoints != matchup[region].Tiers[tier + 1].Servers[1].VictoryPoints)
                            {
                                (matchup[region].Tiers[tier + 1].NextMatchup[0].ServerName, matchup[region].Tiers[tier].NextMatchup[2].ServerName) =
                                (matchup[region].Tiers[tier].NextMatchup[2].ServerName, matchup[region].Tiers[tier + 1].NextMatchup[0].ServerName);

                                (matchup[region].Tiers[tier + 1].NextMatchup[0].ServerToolTip, matchup[region].Tiers[tier].NextMatchup[2].ServerToolTip) =
                                (matchup[region].Tiers[tier].NextMatchup[2].ServerToolTip, matchup[region].Tiers[tier + 1].NextMatchup[0].ServerToolTip);
                            }
                        }
                        break;
                    case false:
                        for (int tier = 0; tier < matchup[region].Tiers.Count; tier++)
                        {
                            for (int server = 0; server < 3; server++)
                            {
                                matchup[region].Tiers[tier].NextMatchup[server].ServerName = "Relinks - No Data Available";
                                matchup[region].Tiers[tier].NextMatchup[server].ServerBgColor = new SolidColorBrush(Color.FromRgb(66, 66, 66));
                                matchup[region].Tiers[tier].NextMatchup[server].ServerToolTip = "No Data Available";
                            }
                        }
                        break;
                }
            }
            return matchup;
        }
    }
}