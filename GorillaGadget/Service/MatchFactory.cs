using GorillaGadget.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace GorillaGadget.Service
{
    public class MatchFactory
    {
        // 
        //  Assemble all the matchup data from the matches list in the LoadData method
        // 

        public static Matchup[] GetMatchup(List<Match> matches, Dictionary<int, World> worlds)
        {
            var matchup = new Matchup[2] { new(), new() };
            foreach (Match match in matches)
            {
                var serverList = new List<Server>()
        {
            new()
            {
                ServerName = worlds[match.Worlds.Green].Name,
                ServerToolTip = ToolTips.GetServerToolTip(match.AllWorlds.Green, worlds),
                ServerBgColor = new SolidColorBrush(Colors.DarkGreen),
                VictoryPoints = match.VictoryPoints.Green,
                WarScore = match.Skirmishes[match.Skirmishes.Count-1].Scores.Green
            },
            new()
            {
                ServerName = worlds[match.Worlds.Blue].Name,
                ServerToolTip = ToolTips.GetServerToolTip(match.AllWorlds.Blue, worlds),
                ServerBgColor = new SolidColorBrush(Colors.DarkBlue),
                VictoryPoints = match.VictoryPoints.Blue,
                WarScore = match.Skirmishes[match.Skirmishes.Count-1].Scores.Blue
            },
            new()
            {
                ServerName = worlds[match.Worlds.Red].Name,
                ServerToolTip = ToolTips.GetServerToolTip(match.AllWorlds.Red, worlds),
                ServerBgColor = new SolidColorBrush(Colors.DarkRed),
                VictoryPoints = match.VictoryPoints.Red,
                WarScore = match.Skirmishes[match.Skirmishes.Count-1].Scores.Red
            }
        };
                serverList = serverList.OrderByDescending(x => x.VictoryPoints).ThenBy(x => x.WarScore).ToList();
                serverList = Ranks.GetRanks(serverList, match.Skirmishes.Count);
                serverList = VictoryPoints.GetColors(serverList);
                var region = Convert.ToInt32(match.Id[..1]) - 1;
                var tier = Convert.ToInt32(match.Id.Substring(match.Id.Length - 1, 1));
                matchup[region].RelinkDate = Relinks.GetRelinkDateString();
                matchup[region].RelinkWeek = Relinks.GetRelinkWeek(match.EndTime.ToLocalTime());
                matchup[region].Skirmishes = string.Format("Skirmish: {0} of 84", match.Skirmishes.Count);
                matchup[region].EndOfMatch = EndOfMatch.GetEndOfMatch(match.EndTime.ToLocalTime());
                matchup[region].EndDate = match.EndTime.ToLocalTime().ToShortDateString();
                var tierList = new Tier()
                {
                    TierNumber = string.Format("Tier {0}", tier.ToString()),
                    Servers = serverList,
                    NextMatchup = new()
                    {
                        new()
                        {
                            ServerName = serverList[0].ServerName,
                            ServerBgColor = new SolidColorBrush(Colors.DarkGreen),
                            ServerToolTip = serverList[0].ServerToolTip
                        },
                        new()
                        {
                            ServerName = serverList[1].ServerName,
                            ServerBgColor = new SolidColorBrush(Colors.DarkBlue),
                            ServerToolTip = serverList[1].ServerToolTip
                        },
                        new()
                        {
                            ServerName = serverList[2].ServerName,
                            ServerBgColor = new SolidColorBrush(Colors.DarkRed),
                            ServerToolTip = serverList[2].ServerToolTip
                        }
                    }
                };
                matchup[region].Tiers.Add(tierList);
            }
            matchup = SortServers.SortNextMatchup(matchup);
            return matchup;
        }
    }
}