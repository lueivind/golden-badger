using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawingTool
{
    /// <summary>
    /// Design model for <see cref="LineViewModel"/> and <see cref="LineListItemControl"
    /// </summary>
    public class LineDesignModel : LineViewModel
    {
        public LineDesignModel(Canvas canvas, MainViewModel viewModel, Line line) : base(canvas, viewModel, line)
        {
            Line.X1 = 412.41235123154;
            Line.X2 = 612.512311231451;
            Line.Y1 = 52.412312;
            Line.Y2 = 100.51215609;
            Name = "Line Design Model";
        }


        /// <summary>
        /// Design instance.
        /// </summary>
        public static LineDesignModel Instance { get; } = new LineDesignModel(new Canvas(), new MainViewModel(), new Line());

    }
}
