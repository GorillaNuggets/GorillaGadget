using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GorillaGadget.UserControls
{
    public partial class NextMatchupPanel : UserControl
    {
        public NextMatchupPanel()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown += HandleKeyPress;
        }
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {            
            if(this.Visibility == Visibility.Visible)
            {
                if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
                {
                    if (e.Key == Key.C)
                    {
                        var width = (int)MatchUI.ActualWidth;
                        var height = (int)MatchUI.ActualHeight;
                        var bitmap = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Default);
                        var dv = new DrawingVisual();
                        using (DrawingContext dc = dv.RenderOpen())
                        {
                            var vb = new VisualBrush(MatchUI);
                            dc.DrawRectangle(vb, null, new Rect(new Point(), new Size(width, height)));
                        }
                        bitmap.Render(dv);
                        Clipboard.SetImage(bitmap);
                    }
                }
            }
        }
    }
}