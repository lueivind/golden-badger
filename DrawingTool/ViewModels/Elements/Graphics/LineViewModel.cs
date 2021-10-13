using System;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawingTool
{
    public class LineViewModel : GraphicViewModel
    {

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LineViewModel(string name, StructureClassViewModel structureClass, PageViewModel page,  Line line) : base(name, structureClass, page)
        {
            Shape = line;
            Line = line;

            // bind line stroke color to viewmodel color.
            Line.DataContext = this;
            Line.SetBinding(Line.StrokeProperty, nameof(ColorBrush) + "." + nameof(ColorBrush.Color));
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Graphical element
        /// </summary>
        public Line Line { get; private set; }

        /// <summary>
        /// Absolute length of element
        /// </summary>
        public double Length
        {
            get
            {
                double a = Math.Abs(Line.X2 - Line.X1);
                double b = Math.Abs(Line.Y2 - Line.Y1);
                double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                return c;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Return coordinates as string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"({Line.X1},{Line.Y1}) -> ({Line.X2},{Line.Y2})";
        }

        #endregion
    }
}
