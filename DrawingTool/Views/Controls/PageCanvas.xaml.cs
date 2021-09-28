using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawingTool
{
    /// <summary>
    /// Interaction logic for PageCanvas.xaml
    /// </summary>
    public partial class PageCanvas : UserControl
    {
        #region Private Members

        /// <summary>
        /// Viewmodel
        /// </summary>
        private PageViewModel viewModel;

        /// <summary>
        /// True if first point of a new line has not been set, ie. if false line command has started.
        /// </summary>
        private bool isFirstPoint = true;

        /// <summary>
        /// Keeping track of start of pan command.
        /// </summary>
        private Point panPoint;

        /// <summary>
        /// Canvas translation transform.
        /// </summary>
        TranslateTransform canvasTranslateTransform;

        /// <summary>
        /// Canvas scale transform
        /// </summary>
        ScaleTransform canvasScaleTransform;

        private double zoomIncrement = 0.05;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PageCanvas(PageViewModel viewModel)
        {
            InitializeComponent();

            // viemodel
            this.viewModel = viewModel;
            this.DataContext = this.viewModel;

            // initialize canvas transform
            canvasTranslateTransform = new TranslateTransform();
            canvasScaleTransform = new ScaleTransform();
            TransformGroup group = new TransformGroup();
            group.Children.Add(canvasTranslateTransform);
            group.Children.Add(canvasScaleTransform);
            pageCanvas.RenderTransform = group;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// A mouse button was pressed on the canvas.
        /// </summary>
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Left button was pressed --> New line command.
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                if (e.OriginalSource is Canvas)
                {
                    if (isFirstPoint)
                    { 
                        if (viewModel.CurrentStructureClass == null)
                            return;
                        isFirstPoint = false;
                        Point point = e.GetPosition((Canvas)e.OriginalSource);
                        Line line = new Line();
                        line.IsHitTestVisible = false;
                        line.Name = "Line" + viewModel.CurrentStructureClass.Graphics.Count.ToString();
                        line.Stroke = viewModel.CurrentStructureClass.ColorBrush;
                        line.X1 = point.X;
                        line.Y1 = point.Y;
                        line.X2 = point.X;
                        line.Y2 = point.Y;
                        line.StrokeThickness = 2;
                        pageCanvas.Children.Insert(0, line);
                    }
                    else
                    {
                        Line line = (Line)pageCanvas.Children[0];
                        line.IsHitTestVisible = true;
                        isFirstPoint = true;
                        viewModel.CurrentStructureClass.Graphics.Add(new GraphicViewModel(line.Name, line));
                    }
                }
            }

            // Middle mouse was pressed --> Pan command.
            if (e.MiddleButton == MouseButtonState.Pressed)
            {
                StartPan(e);
            }

        }

        /// <summary>
        /// Mouse is moving over the canvas.
        /// </summary>
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isFirstPoint)
            {
                if (e.OriginalSource is Canvas)
                {
                    Point point = e.GetPosition((Canvas)e.OriginalSource);
                    Line line = (Line)pageCanvas.Children[0];
                    line.X2 = point.X;
                    line.Y2 = point.Y;
                }
            }

            // Middle mouse is pressed --> Pan command.
            if (e.MiddleButton == MouseButtonState.Pressed)
            {
                Pan(e);
            }
        }

        /// <summary>
        /// Mouse wheel rotated over canvas.
        /// </summary>
        private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Zoom(e);
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Start pan operation.
        /// </summary>
        private void StartPan(MouseButtonEventArgs e)
        {
            panPoint = e.GetPosition(pageCanvas);
        }

        /// <summary>
        /// Pan canvas.
        /// </summary>
        private void Pan(MouseEventArgs e)
        {
            Point bPoint = e.GetPosition(pageCanvas);

            // get deltaX
            double deltaX = bPoint.X - panPoint.X;
            // apply deltaX to canvas offset
            canvasTranslateTransform.X += deltaX;

            // get deltaY
            double deltaY = bPoint.Y - panPoint.Y;
            // apply deltaY to canvas offset
            canvasTranslateTransform.Y += deltaY;
        }

        private void Zoom(MouseWheelEventArgs e)
        {
            Point position = e.GetPosition(pageCanvas);

            canvasScaleTransform.CenterX = position.X;
            canvasScaleTransform.CenterY = position.Y;

            // wheel up
            if (e.Delta > 0)
            {
                ZoomIn();
            }

            // wheel down
            if (e.Delta < 0)
            {
                ZoomOut();
            }

            Point cursorpos = Mouse.GetPosition(pageCanvas);

            double discrepancyX = cursorpos.X - position.X;
            double discrepancyY = cursorpos.Y - position.Y;

            canvasTranslateTransform.X += discrepancyX;
            canvasTranslateTransform.Y += discrepancyY;

            // https://stackoverflow.com/questions/22349953/scale-canvas-to-mouse-position

        }

        /// <summary>
        /// Zoom in on canvas.
        /// </summary>
        private void ZoomIn()
        {
            canvasScaleTransform.ScaleX += zoomIncrement;
            canvasScaleTransform.ScaleY += zoomIncrement;
        }

        /// <summary>
        /// Zoom out on canvas.
        /// </summary>
        private void ZoomOut()
        {
            canvasScaleTransform.ScaleX -= zoomIncrement;
            canvasScaleTransform.ScaleY -= zoomIncrement;
        }

        #endregion


    }
}
