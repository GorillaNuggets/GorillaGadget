using GorillaGadget.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace GorillaGadget.Service
{
    public class PopulationFactory
    {
        //
        // Create a list of server populations for both regions (NA and EU)
        //

        public static List<PopulationModel>[] GetPopulation(List<World> worlds)
        {
            var result = new List<PopulationModel>[2] { new(), new() };
            foreach (World world in worlds)
            {
                byte alpha = 125;
                var region = world.Id > 2000 ? 1 : 0;
                var rank = 0;
                var population = world.Population;
                var bgcolor = new SolidColorBrush(Color.FromArgb(alpha, 255, 0, 0));
                var gems = string.Empty;

                if (world.Population == "VeryHigh")
                {
                    rank = 1;
                    population = "Very High";
                    bgcolor = new SolidColorBrush(Color.FromArgb(alpha, 255, 140, 0));
                    gems = "1800 Gems";
                }
                if (world.Population == "High")
                {
                    rank = 2;
                    bgcolor = new SolidColorBrush(Color.FromArgb(alpha, 255, 215, 0));
                    gems = "1000 Gems";
                }
                if (world.Population == "Medium")
                {
                    rank = 3;
                    bgcolor = new SolidColorBrush(Color.FromArgb(alpha, 0, 128, 0));
                    gems = "500 Gems";
                }
                var temp = new PopulationModel()
                {
                    Region = region,
                    Name = world.Name,
                    Rank = rank,
                    Population = population,
                    BgColor = bgcolor,
                    Gems = gems
                };
                result[region].Add(temp);
                result[region] = result[region].OrderBy(x => x.Rank).ToList();
            }
            return result;
        }
    }
}