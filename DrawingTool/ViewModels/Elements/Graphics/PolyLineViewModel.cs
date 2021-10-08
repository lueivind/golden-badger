using System.Windows.Shapes;

namespace DrawingTool
{
    public class PolyLineViewModel : GraphicViewModel
    {
        public PolyLineViewModel(string name, Polyline polyline) : base(name)
        {
            Polyline = polyline;
        }

        public Polyline Polyline { get; private set; }
    }
}
