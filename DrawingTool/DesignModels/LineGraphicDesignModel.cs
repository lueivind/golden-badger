using System.Windows.Shapes;

namespace DrawingTool
{
    /// <summary>
    /// Design model for <see cref="LineGraphicViewModel"/> and <see cref="LineListItemControl"
    /// </summary>
    public class LineGraphicDesignModel : LineGraphicViewModel
    {
        public LineGraphicDesignModel(string name, Line line) : base(name, line)
        {
            Line.X1 = 412.41235123154;
            Line.X2 = 612.512311231451;
            Line.Y1 = 52.412312;
            Line.Y2 = 100.51215609;
        }

        /// <summary>
        /// Design instance.
        /// </summary>
        public static LineGraphicDesignModel Instance { get; } = new LineGraphicDesignModel("ThridDesignLine", new Line());

    }
}
