using System;
using System.Windows.Controls;
using System.Windows.Input;
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
        public GraphicViewModel(string name)
        {
            Name = name;

            // commands
            DeleteCommand = new RelayCommand(OnDeleteGraphics);
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
        public Shape Shape { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Command to delete self.
        /// </summary>
        public ICommand DeleteCommand { get; set; }

        #endregion

        #region Event: Delete Graphic

        /// <summary>
        /// Event delegate.
        /// </summary>
        public delegate void DeleteGraphicEventHandler(object source, EventArgs args);

        /// <summary>
        /// Event based on delete, can be subscribed to.
        /// </summary>
        public event DeleteGraphicEventHandler DeleteGraphic;

        /// <summary>
        /// Raise the event.
        /// </summary>
        protected virtual void OnDeleteGraphics()
        {
            // delete line from canvas
            Canvas canvas = (Canvas)Shape.Parent;
            canvas.Children.Remove(Shape);

            // delete viewmodel
            DeleteGraphic?.Invoke(this, EventArgs.Empty);
        }

        #endregion




    }
}
