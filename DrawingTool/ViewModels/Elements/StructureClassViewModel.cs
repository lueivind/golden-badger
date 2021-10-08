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
            Lines = new ObservableCollection<LineGraphicViewModel>();
            PolyLines = new ObservableCollection<PolyLineViewModel>();
        }

        #endregion

        #region Collections

        /// <summary>
        /// Collection of graphical elements.
        /// </summary>
        public ObservableCollection<LineGraphicViewModel> Lines { get; private set; }

        public ObservableCollection<PolyLineViewModel> PolyLines { get; private set; }

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
            foreach (LineGraphicViewModel line in Lines)
            {
                line.Line.Stroke = ColorBrush;
            }
            foreach (PolyLineViewModel polyline in PolyLines)
            {
                polyline.Polyline.Stroke = ColorBrush;
            }
        }

        public void AddGraphic(GraphicViewModel graphic)
        {
            graphic.DeleteGraphic += Graphic_DeleteGraphic;
            
            // line
            if(graphic.GetType() == typeof(LineGraphicViewModel))
            {
                Lines.Add((LineGraphicViewModel)graphic);
            }

            // polyline
            if (graphic.GetType() == typeof(PolyLineViewModel))
            {
                PolyLines.Add((PolyLineViewModel)graphic);
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Event fired when graphic wants to be deleted.
        /// </summary>
        private void Graphic_DeleteGraphic(object source, System.EventArgs args)
        {
            GraphicViewModel graphic = (GraphicViewModel)source;

            // line
            if (graphic.GetType() == typeof(LineGraphicViewModel))
            {
                Lines.Remove((LineGraphicViewModel)graphic);
            }

            // polyline
            if (graphic.GetType() == typeof(PolyLineViewModel))
            {
                PolyLines.Remove((PolyLineViewModel)graphic);
            }

        }

        #endregion

    }
}
