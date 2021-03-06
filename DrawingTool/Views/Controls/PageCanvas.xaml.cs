using System;
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
        /// Main view model reference.
        /// </summary>
        private MainViewModel mainViewModel;

        /// <summary>
        /// Page view model reference.
        /// </summary>
        private PageViewModel pageViewModel;

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

        /// <summary>
        /// Selected graphic
        /// </summary>
        private GraphicViewModel selectedGraphic;
       
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PageCanvas(PageViewModel pageViewModel, MainViewModel mainViewModel)
        {
            InitializeComponent();

            // get pageViewModel
            this.pageViewModel = pageViewModel;
            DataContext = this.pageViewModel;

            // get mainViewModel
            this.mainViewModel = mainViewModel;

            // initialize canvas transform
            canvasTranslateTransform = new TranslateTransform();
            canvasScaleTransform = new ScaleTransform();
            TransformGroup group = new TransformGroup();
            group.Children.Add(canvasTranslateTransform);
            group.Children.Add(canvasScaleTransform);
            pageCanvas.RenderTransform = group;
            canvasScaleTransform.CenterX = pageCanvas.Width / 2;
            canvasScaleTransform.CenterY = pageCanvas.Height / 2;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// A mouse button was pressed on the canvas.
        /// </summary>
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var canvas = (Canvas)sender;

    

            // Left button was pressed --> New line command.
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                // check for selection
                if(e.OriginalSource is Shape shape)
                {
                    if(shape.DataContext is GraphicViewModel graphic)
                    {
                        if (selectedGraphic != null)
                        {
                            selectedGraphic.DeSelect();
                        };
                        selectedGraphic = graphic;
                    }
                }


                if (e.OriginalSource is Canvas)
                {
                    // Deselect
                    foreach(object obj in ((Canvas)sender).Children)
                    {
                        if(obj is Canvas overlayCanvas)
                        {
                            if(overlayCanvas.DataContext is GraphicViewModel graphic)
                            {
                                if (graphic.IsSelected)
                                {
                                    graphic.DeSelect();
                                    return;
                                }
                            }
                        }
                    }


                    // Draw Line
                    if (isFirstPoint)
                    {       
                        // check for active structure class.
                        if (mainViewModel.StructureExplorer.ActiveStructureClass == null)
                            return;

                        // line first point
                        isFirstPoint = false;

                        // get mouse position
                        Point point = e.GetPosition((Canvas)e.OriginalSource);
                        
                        // construct line
                        Line line = new Line();
                        line.IsHitTestVisible = false;
                        line.Stroke = Brushes.Yellow;
                        line.X1 = point.X;
                        line.Y1 = point.Y;
                        line.X2 = point.X;
                        line.Y2 = point.Y;
                        line.StrokeThickness = 2;
                        pageCanvas.Children.Insert(0, line);
                    }
                    else
                    {
                        // Line second point.

                        Line line = (Line)pageCanvas.Children[0];
                        line.IsHitTestVisible = true;
                        isFirstPoint = true;

                        pageCanvas.Children.RemoveAt(0);
                        LineViewModel model = new LineViewModel(pageCanvas, mainViewModel, line);
                        //mainViewModel.StructureExplorer.ActiveStructureClass.AddGraphic(new LineViewModel(line.Name, mainViewModel.StructureExplorer.ActiveStructureClass, mainViewModel.CurrentPage, line));
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

        #endregion

        #region Methods

        /// <summary>
        /// Reset canvas view.
        /// </summary>
        public void Reset()
        {
            // reset translation
            canvasTranslateTransform.X = 0;
            canvasTranslateTransform.Y = 0;

            // reset scale
            canvasScaleTransform.CenterX = pageCanvas.Width / 2;
            canvasScaleTransform.CenterY = pageCanvas.Height / 2;
            canvasScaleTransform.ScaleX = 1;
            canvasScaleTransform.ScaleY = 1;
         
        }

        /// <summary>
        /// Fit whole image in canvas view.
        /// </summary>
        public void Fit()
        {

            // grid dimensions
            var gridHeight = pageGrid.ActualHeight;
            var gridWidth = pageGrid.ActualWidth;

            // image dimensions
            var imageHeight = image.ActualHeight;
            var imageWidth = image.ActualWidth;

            // container width divided by image width
            var heightRelation = gridHeight / imageHeight;
            // container height divived by image height
            var widthRelation = gridWidth / imageWidth;

            // scale to the lowest value
            if(heightRelation > widthRelation)
            {
                // scale to width
                canvasScaleTransform.ScaleY = widthRelation;
                canvasScaleTransform.ScaleX = widthRelation;
            }
            else
            {
                // scale to height
                canvasScaleTransform.ScaleY = heightRelation;
                canvasScaleTransform.ScaleX = heightRelation;

            }

            // center image
            Center();
        }

        /// <summary>
        /// Center canvas in parent container.
        /// </summary>
        public void Center()
        {
            // set scale center to center of canvas
            canvasScaleTransform.CenterX = pageCanvas.Width / 2;
            canvasScaleTransform.CenterY = pageCanvas.Height / 2;
            // reset translation to reset to center alignment
            canvasTranslateTransform.X = 0;
            canvasTranslateTransform.Y = 0;
        }

        /// <summary>
        /// Zoom in on canvas.
        /// </summary>
        public void ZoomIn()
        {
            canvasScaleTransform.ScaleX += zoomIncrement;
            canvasScaleTransform.ScaleY += zoomIncrement;
        }

        /// <summary>
        /// Zoom out on canvas.
        /// </summary>
        public void ZoomOut()
        {
            canvasScaleTransform.ScaleX -= zoomIncrement;
            canvasScaleTransform.ScaleY -= zoomIncrement;
        }

        #endregion


    }
}
