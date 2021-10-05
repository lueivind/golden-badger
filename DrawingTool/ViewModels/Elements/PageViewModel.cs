using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DrawingTool
{
    public class PageViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// Default color brushes for structure class color.
        /// </summary>
        private List<Brush> DefaultBrushes;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PageViewModel(string name, BitmapImage image)
        {
            Name = name;
            Image = image;

            // collections
            StructureClasses = new ObservableCollection<StructureClassViewModel>();

            // lists
            DefaultBrushes = new List<Brush>();

            // canvas
            PageCanvas = new PageCanvas(this);

            // commands
            AddStructureClassCommand = new RelayCommand(AddStructureClass);
            CanvasResetCommand = new RelayCommand(PageCanvas.Reset);
            CanvasFitCommand = new RelayCommand(PageCanvas.Fit);
            CanvasCenterCommand = new RelayCommand(PageCanvas.Center);
            CanvasZoomInCommand = new RelayCommand(PageCanvas.ZoomIn);
            CanvasZoomOutCommand = new RelayCommand(PageCanvas.ZoomOut);

            // dummy sctructures classes
            AddStructureClass();
            AddStructureClass();
            AddStructureClass();

        }

        #endregion

        #region Collections

        /// <summary>
        /// Collection of structure classes.
        /// </summary>
        public ObservableCollection<StructureClassViewModel> StructureClasses { get; set; }

        #endregion

        #region Public Properties

        public string Name { get; set; }

        public ImageSource ImageSource { get; set; }

        public BitmapImage Image { get; set; }

        //public Canvas PageCanvas { get; set; }

        public PageCanvas PageCanvas { get; set; }

        public StructureClassViewModel CurrentStructureClass { get; set; }
 

        #endregion

        #region Commands

        /// <summary>
        /// Command for adding new structure class.
        /// </summary>
        public ICommand AddStructureClassCommand { get; set; }


        /// <summary>
        /// Command to reset page canvas view.
        /// </summary>
        public ICommand CanvasResetCommand { get; set; }

        /// <summary>
        /// Command to make page canvas view fit.
        /// </summary>
        public ICommand CanvasFitCommand { get; set; }

        /// <summary>
        /// Command to center the canvas.
        /// </summary>
        public ICommand CanvasCenterCommand { get; set; }

        /// <summary>
        /// Command to zoom the canvas out.
        /// </summary>
        public ICommand CanvasZoomInCommand { get; set; }

        /// <summary>
        /// Command to zoom the canvas in.
        /// </summary>
        public ICommand CanvasZoomOutCommand { get; set; }

        #endregion

        #region Helpers

        /// <summary>
        /// Add new structure class.
        /// </summary>
        private void AddStructureClass()
        {
            StructureClassViewModel structureClass = new StructureClassViewModel("Structure Class " + StructureClasses.Count.ToString());
            structureClass.SetColor(GetBrush());
            DefaultBrushes.RemoveAt(0);
            StructureClasses.Add(structureClass);
        }

        /// <summary>
        /// Get a color brush.
        /// </summary>
        private Brush GetBrush()
        {
            // check if brush list is depleted.
            if (DefaultBrushes.Count < 1)
            {
                // refill brush list.
                DefaultBrushes = GetBrushes();
            }
            // return color brush.
            return DefaultBrushes[0];

        }

        /// <summary>
        /// Get list of color brushes.
        /// </summary>
        private List<Brush> GetBrushes()
        {
            return new List<Brush>()
            {
                Brushes.Red,
                Brushes.Blue,
                Brushes.Green,
                Brushes.AliceBlue,
                Brushes.PaleGoldenrod,
                Brushes.Orchid,
                Brushes.OrangeRed,
                Brushes.Orange,
                Brushes.OliveDrab,
                Brushes.Olive,
                Brushes.OldLace,
                Brushes.Navy,
                Brushes.NavajoWhite,
                Brushes.Moccasin,
                Brushes.MistyRose,
                Brushes.MintCream,
                Brushes.MidnightBlue,
                Brushes.MediumVioletRed,
                Brushes.MediumTurquoise,
                Brushes.MediumSpringGreen,
                Brushes.MediumSlateBlue,
                Brushes.LightSkyBlue,
                Brushes.LightSlateGray,
                Brushes.LightSteelBlue,
                Brushes.LightYellow,
                Brushes.Lime,
                Brushes.LimeGreen,
                Brushes.PaleGreen,
                Brushes.Linen,
                Brushes.Maroon,
                Brushes.MediumAquamarine,
                Brushes.MediumBlue,
                Brushes.MediumOrchid,
                Brushes.MediumPurple,
                Brushes.MediumSeaGreen,
                Brushes.Magenta,
                Brushes.PaleTurquoise,
                Brushes.PaleVioletRed,
                Brushes.PapayaWhip,
                Brushes.SlateGray,
                Brushes.Snow,
                Brushes.SpringGreen,
                Brushes.SteelBlue,
                Brushes.Tan,
                Brushes.Teal,
                Brushes.SlateBlue,
                Brushes.Thistle,
                Brushes.Transparent,
                Brushes.Turquoise,
                Brushes.Violet,
                Brushes.Wheat,
                Brushes.White,
                Brushes.WhiteSmoke,
                Brushes.Tomato,
                Brushes.LightSeaGreen,
                Brushes.SkyBlue,
                Brushes.Sienna,
                Brushes.PeachPuff,
                Brushes.Peru,
                Brushes.Pink,
                Brushes.Plum,
                Brushes.PowderBlue,
                Brushes.Purple,
                Brushes.Silver,
                Brushes.RoyalBlue,
                Brushes.SaddleBrown,
                Brushes.Salmon,
                Brushes.SandyBrown,
                Brushes.SeaGreen,
                Brushes.SeaShell,
                Brushes.RosyBrown,
                Brushes.Yellow,
                Brushes.LightSalmon,
                Brushes.LightGreen,
                Brushes.DarkRed,
                Brushes.DarkOrchid,
                Brushes.DarkOrange,
                Brushes.DarkOliveGreen,
                Brushes.DarkMagenta,
                Brushes.DarkKhaki,
                Brushes.DarkGreen,
                Brushes.DarkGray,
                Brushes.DarkGoldenrod,
                Brushes.DarkCyan,
                Brushes.DarkBlue,
                Brushes.Cyan,
                Brushes.Crimson,
                Brushes.Cornsilk,
                Brushes.CornflowerBlue,
                Brushes.Coral,
                Brushes.Chocolate,
                Brushes.AntiqueWhite,
                Brushes.Aqua,
                Brushes.Aquamarine,
                Brushes.Azure,
                Brushes.Beige,
                Brushes.Bisque,
                Brushes.DarkSalmon,
                Brushes.Black,
                Brushes.BlueViolet,
                Brushes.Brown,
                Brushes.BurlyWood,
                Brushes.CadetBlue,
                Brushes.Chartreuse,
                Brushes.BlanchedAlmond,
                Brushes.DarkSeaGreen,
                Brushes.DarkSlateBlue,
                Brushes.DarkSlateGray,
                Brushes.HotPink,
                Brushes.IndianRed,
                Brushes.Indigo,
                Brushes.Ivory,
                Brushes.Khaki,
                Brushes.Lavender,
                Brushes.Honeydew,
                Brushes.LavenderBlush,
                Brushes.LemonChiffon,
                Brushes.LightBlue,
                Brushes.LightCoral,
                Brushes.LightCyan,
                Brushes.LightGoldenrodYellow,
                Brushes.LightGray,
                Brushes.LawnGreen,
                Brushes.LightPink,
                Brushes.GreenYellow,
                Brushes.Gray,
                Brushes.DarkTurquoise,
                Brushes.DarkViolet,
                Brushes.DeepPink,
                Brushes.DeepSkyBlue,
                Brushes.DimGray,
                Brushes.DodgerBlue,
                Brushes.Firebrick,
                Brushes.ForestGreen,
                Brushes.Fuchsia,
                Brushes.Gainsboro,
                Brushes.GhostWhite,
                Brushes.Gold,
                Brushes.Goldenrod,
                Brushes.FloralWhite,
                Brushes.YellowGreen
            };
        }

        #endregion

    }
}
