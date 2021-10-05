using System;
using System.Windows.Shapes;

namespace DrawingTool
{
    /// <summary>
    /// Viewmodel for graphical element
    /// </summary>
    public class GraphicViewModel : BaseViewModel
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public GraphicViewModel(string name, Line line)
        {
            Name = name;
            Line = line;

        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Name of element
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Graphical element
        /// </summary>
        public Line Line { get; set; }

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
