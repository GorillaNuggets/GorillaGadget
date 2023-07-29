using GorillaGadget.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GorillaGadget.Service
{
    public class ToolTips
    {
        //
        //  Create the tooltip data for a server
        //

        public static string GetServerToolTip(IReadOnlyList<int> links, Dictionary<int, World> worlds)
        {
            links = links.Reverse().ToList();
            var result = string.Empty;
            foreach (var link in links)
            {
                if (link < 10000)
                {
                    if (worlds[link].Population == "VeryHigh")
                    {
                        result += string.Format("{0,-22}{1,-8}\r\n", worlds[link].Name, "Very High");
                    }
                    else
                    {
                        result += string.Format("{0,-22}{1,-8}\r\n", worlds[link].Name, worlds[link].Population);
                    }
                }
            }
            return result;
        }
    }
}