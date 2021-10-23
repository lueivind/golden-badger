using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
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
        public LineViewModel(Canvas canvas, MainViewModel viewModel, Line line) : base(canvas, viewModel)
        {
            Line = line;
            Shape = line;
            Name = "Line";

            // add self to structure class
            MainViewModel.StructureExplorer.ActiveStructureClass.AddGraphic(this);

            // create overlay canvas for line element, use parent canvas dimensions
            GraphicOverlayCanvas = new Canvas();
            GraphicOverlayCanvas.Height = ParentCanvas.ActualHeight;
            GraphicOverlayCanvas.Width = ParentCanvas.ActualWidth;
            GraphicOverlayCanvas.DataContext = this;
            // add overlay canvas to parent canvas
            ParentCanvas.Children.Add(GraphicOverlayCanvas);

            // construct and add elements to overlay canvas
            Line.Stroke = ColorBrush.Color;
            GraphicOverlayCanvas.Children.Add(Line);
            OverlayLine = new Line()
            {
                X1 = Line.X1,
                X2 = Line.X2,
                Y1 = Line.Y1,
                Y2 = Line.Y2,
                StrokeThickness = 10,
                Opacity = 0.3,
                Stroke = Brushes.AliceBlue,
                Cursor = Cursors.Hand,

         
        };
            OverlayLine.SetValue(Canvas.ZIndexProperty, 2);
            GraphicOverlayCanvas.Children.Add(OverlayLine);

            // collections
            OverlayShapes = new List<Shape>();

            // bind line stroke color to viewmodel color.
            Line.DataContext = this;
            Line.Focusable = true;
            Line.SetValue(Canvas.ZIndexProperty, 1);
            Line.SetBinding(Line.StrokeProperty, nameof(ColorBrush) + "." + nameof(ColorBrush.Color));
            Line.MouseDown += Line_MouseDown;
            Line.MouseEnter += Line_MouseEnter;
            Line.MouseLeave += Line_MouseLeave;
            Line.GotFocus += Line_GotFocus;
            Line.LostFocus += Line_LostFocus;
            Line.MouseMove += Line_MouseMove;
            Line.Cursor = Cursors.Hand;

            OverlayLine.MouseEnter += OverlayLine_MouseEnter;
            OverlayLine.MouseLeave += OverlayLine_MouseLeave;
            OverlayLine.MouseDown += OverlayLine_MouseDown;

        }

        private void OverlayLine_MouseLeave(object sender, MouseEventArgs e)
        {
            foreach (Shape s in OverlayShapes)
            {
                GraphicOverlayCanvas.Children.Remove(s);
            }
        }

        private void OverlayLine_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Select();
            }
        }

        private void OverlayLine_MouseEnter(object sender, MouseEventArgs e)
        {
            if (IsSelected)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Height = 20;
                ellipse.Width = 20;
                ellipse.Stroke = Brushes.Black;
                ellipse.Style = (Style)Application.Current.Resources["EndPointEllipse"];
                ellipse.SetValue(Canvas.LeftProperty, Line.X1 - (ellipse.Width / 2));
                ellipse.SetValue(Canvas.TopProperty, Line.Y1 - (ellipse.Height / 2));
                ellipse.SetValue(Canvas.ZIndexProperty, 0);
                // !!!!!!!!!!!!!!!!! breaks MVVM
     
                OverlayShapes.Add(ellipse);
                GraphicOverlayCanvas.Children.Add(ellipse);
            }
        }

        public override void Select()
        {
            base.Select();
            Line.StrokeDashArray = new DoubleCollection() { 2 };

        }

        public override void DeSelect()
        {
            base.DeSelect();
            Line.StrokeDashArray = null;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Graphical element
        /// </summary>
        public Line Line { get; private set; }

        public Line OverlayLine { get; private set; }

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

        #region Collections

        private List<Shape> OverlayShapes;

        #endregion

        #region Events

        private void Line_MouseMove(object sender, MouseEventArgs e)
        {
 

        }

        private void Line_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void Line_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Line_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        }


        private void Line_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
        }

        private void Line_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
  
        }

        #endregion
    }
}
