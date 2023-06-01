using System.Windows.Media;

namespace GorillaGadget.Model
{
    public class PopulationModel
    {
        public int Region { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Rank { get; set; }
        public string Population { get; set; } = string.Empty;
        public SolidColorBrush BgColor { get; set; } = new();
        public string Gems { get; set; } = string.Empty;        
    }
}