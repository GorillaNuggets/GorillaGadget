using GorillaGadget.Model;
using System.Collections.Generic;
using System.Windows.Media;

namespace GorillaGadget.Service
{
    public class VictoryPoints
    {
        //
        //  Apply a color to the Victory Points. Salmon for a tie score and FloralWhite as default
        //

        public static List<Server> GetColors(List<Server> list)
        {
            list[0].VictoryPointsFgColor = list[0].VictoryPoints == list[1].VictoryPoints ? new SolidColorBrush(Colors.Salmon) :
                new SolidColorBrush(Colors.FloralWhite);

            list[1].VictoryPointsFgColor = list[1].VictoryPoints == list[0].VictoryPoints || list[1].VictoryPoints == list[2].VictoryPoints ?
                new SolidColorBrush(Colors.Salmon) : new SolidColorBrush(Colors.FloralWhite);

            list[2].VictoryPointsFgColor = list[2].VictoryPoints == list[1].VictoryPoints ? new SolidColorBrush(Colors.Salmon) :
                new SolidColorBrush(Colors.FloralWhite);

            return list;
        }
    }
}