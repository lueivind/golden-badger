using System.Collections.ObjectModel;
using System.Windows.Media;

namespace DrawingTool
{
    /// <summary>
    /// Viewmodel for wall type / structure class
    /// </summary>
    public class StructureClassViewModel : BaseViewModel
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public StructureClassViewModel(string name)
        {
            Name = name;

            // collections
            Graphics = new ObservableCollection<GraphicViewModel>();
        }

        #endregion

        #region Collections

        /// <summary>
        /// Collection of graphical elements.
        /// </summary>
        public ObservableCollection<GraphicViewModel> Graphics { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Name of class.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Color on graphical elements under this structure class.
        /// </summary>
        public Brush ColorBrush { get; private set; } = Brushes.LightSteelBlue;

        #endregion

        #region Methods

        /// <summary>
        /// Set color of graphical elements under this structure class.
        /// </summary>
        public void SetColor(Brush brush)
        {
            ColorBrush = brush;
            foreach (GraphicViewModel sub in Graphics)
            {
                sub.Line.Stroke = ColorBrush;
            }
        }

        #endregion


    }
}
