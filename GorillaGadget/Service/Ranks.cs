using GorillaGadget.Model;
using System.Collections.Generic;
using System.Windows.Media;

namespace GorillaGadget.Service
{
    public class Ranks
    {
        //
        //  Assemble all the data relating to the servers rank in the current matchup
        //

        public static List<Server> GetRanks(List<Server> list, int skirmish)
        {
            var high = skirmish < 84 ? (84 - skirmish) * 5 : 5;
            var low = skirmish < 84 ? (84 - skirmish) * 3 : 3;

            list[0].Secured = list[0].VictoryPoints + low > list[1].VictoryPoints + high;
            list[2].Secured = list[2].VictoryPoints + high < list[1].VictoryPoints + low;
            list[1].Secured = list[0].Secured && list[2].Secured;

            list[0].Rank = "1";
            list[1].Rank = "2";
            list[2].Rank = "3";

            list[0].RankToolTip = list[0].Secured ? "1st place is secure" : "1st place is not secure";
            list[1].RankToolTip = list[1].Secured ? "2nd place is secure" : "2nd place is not secure";
            list[2].RankToolTip = list[2].Secured ? "3rd place is secure" : "3rd place is not secure";

            for (int index = 0; index < 3; index++)
            {
                switch (list[index].Secured)
                {
                    case true:
                        list[index].RankFgColor = new SolidColorBrush(Colors.DarkGray);
                        list[index].RankBgColor = new SolidColorBrush(Color.FromRgb(66, 66, 66));
                        break;
                    case false:
                        list[index].RankFgColor = new SolidColorBrush(Colors.DarkGray);
                        list[index].RankBgColor = new SolidColorBrush(Color.FromRgb(22, 22, 22));
                        break;
                }
            }

            return list;
        }
    }
}