using System;
using System.Collections.Generic;
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
            Lines = new ObservableCollection<LineViewModel>();
            //PolyLines = new ObservableCollection<PolylineViewModel>();
            //Areas = new ObservableCollection<AreaViewModel>();
            //Counters = new ObservableCollection<CounterViewModel>();
            // color
            Colors = ColorBrush.ColorBrushes();
            ColorBrush = Colors[0];
        }

        /// <summary>
        /// Dummy constructor
        /// </summary>
        public StructureClassViewModel()
        {

        }

        #endregion

        #region Collections

        /// <summary>
        /// Collection of graphical line elements.
        /// </summary>
        public ObservableCollection<LineViewModel> Lines { get; private set; }

        ///// <summary>
        ///// Collection of graphical poyline elements.
        ///// </summary>
        //public ObservableCollection<PolylineViewModel> PolyLines { get; private set; }

        ///// <summary>
        ///// Collection of graphical area elements.
        ///// </summary>
        //public ObservableCollection<AreaViewModel> Areas { get; private set; }

        ///// <summary>
        ///// Collection of graphical counter elements.
        ///// </summary>
        //public ObservableCollection<CounterViewModel> Counters { get; private set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Name of class.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Color of this structure class.
        /// </summary>
        public ColorBrush ColorBrush
        {
            get => colorBrush;
            set
            {
                if(colorBrush != value)
                {
                    colorBrush = value;
                    OnColorChanged();
                }
            }
        }
        private ColorBrush colorBrush;
        /// <summary>
        /// List of colors.
        /// </summary>
        public List<ColorBrush> Colors { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Set color of graphical elements under this structure class.
        /// </summary>
        public void SetColor(Brush brush)
        {
            foreach (LineViewModel line in Lines)
            {
                line.Line.Stroke = ColorBrush.Color;
            }
            //foreach (PolylineViewModel polyline in PolyLines)
            //{
            //    polyline.Polyline.Stroke = ColorBrush.Color;
            //}
        }

        public void AddGraphic(GraphicViewModel graphic)
        {
            graphic.DeleteGraphic += Graphic_DeleteGraphic;
            
            // line
            if(graphic.GetType() == typeof(LineViewModel))
            {
                Lines.Add((LineViewModel)graphic);
            }

            //// polyline
            //if (graphic.GetType() == typeof(PolylineViewModel))
            //{
            //    PolyLines.Add((PolylineViewModel)graphic);
            //}
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
            if (graphic.GetType() == typeof(LineViewModel))
            {
                Lines.Remove((LineViewModel)graphic);
            }

            // polyline
            //if (graphic.GetType() == typeof(PolylineViewModel))
            //{
            //    PolyLines.Remove((PolylineViewModel)graphic);
            //}

        }

        #endregion

        #region Event: Structure Class Color Changed

        /// <summary>
        /// Event delegate.
        /// </summary>
        public delegate void ColorChangedEventHandler(object source, EventArgs args);

        /// <summary>
        /// Event based on delete, can be subscribed to.
        /// </summary>
        public event ColorChangedEventHandler ColorChanged;

        /// <summary>
        /// Raise the event.
        /// </summary>
        protected virtual void OnColorChanged()
        {
            ColorChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

    }
}
