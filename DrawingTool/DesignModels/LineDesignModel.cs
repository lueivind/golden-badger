using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawingTool
{
    /// <summary>
    /// Design model for <see cref="LineViewModel"/> and <see cref="LineListItemControl"
    /// </summary>
    public class LineDesignModel : LineViewModel
    {
        public LineDesignModel(string name, StructureClassViewModel structureClass, PageViewModel page, Line line) : base(name, structureClass, page, line)
        {
            Line.X1 = 412.41235123154;
            Line.X2 = 612.512311231451;
            Line.Y1 = 52.412312;
            Line.Y2 = 100.51215609;
        }


        /// <summary>
        /// Design instance.
        /// </summary>
        public static LineDesignModel Instance { get; } = new LineDesignModel("Line Design Model", new StructureClassViewModel("Structure Class View Model", new StructureExplorerViewModel()), new PageViewModel(), new Line());

    }
}
