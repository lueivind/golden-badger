using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawingTool
{
    public class LineViewModel : GraphicViewModel
    {
        private MainViewModel mainViewModel;

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LineViewModel(string name, StructureClassViewModel structureClass, PageViewModel page,  Line line) : base(name, structureClass, page)
        {
            Shape = line;
            Line = line;

            // collections
            OverlayShapes = new List<Shape>();

            // bind line stroke color to viewmodel color.
            Line.DataContext = this;
            Line.Focusable = true;
            Line.SetBinding(Line.StrokeProperty, nameof(ColorBrush) + "." + nameof(ColorBrush.Color));
            Line.MouseDown += Line_MouseDown;
            Line.MouseEnter += Line_MouseEnter;
            Line.MouseLeave += Line_MouseLeave;
            Line.GotFocus += Line_GotFocus;
            Line.LostFocus += Line_LostFocus;
            Line.MouseMove += Line_MouseMove;
            Line.Cursor = Cursors.Hand;
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
            if (IsSelected)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Height = 20;
                ellipse.Width = 20;
                ellipse.Stroke = Brushes.Black;
                ellipse.SetValue(Canvas.LeftProperty, Line.X1 - (ellipse.Width / 2));
                ellipse.SetValue(Canvas.TopProperty, Line.Y1 - (ellipse.Height / 2));
                OverlayShapes.Add(ellipse);
                Page.PageCanvas.pageCanvas.Children.Add(ellipse);
            }

        }

        private void Line_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            foreach(Shape s in OverlayShapes)
            {
                Page.PageCanvas.pageCanvas.Children.Remove(s);
            }
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
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Select();
            }
        }

        #endregion
    }
}
