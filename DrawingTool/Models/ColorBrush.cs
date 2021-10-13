using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace DrawingTool
{
    public class ColorBrush
    {
        public ColorBrush(string name, Brush color)
        {
            Name = name;
            Color = color;
        }

        public string Name { get; set; }

        public Brush Color { get; set; }

        public static List<ColorBrush> ColorBrushes()
        {
            List<ColorBrush> colorBrushes = new List<ColorBrush>();
            colorBrushes.Add(new ColorBrush("Red", Brushes.Red));
            colorBrushes.Add(new ColorBrush("Blue", Brushes.Blue));
            colorBrushes.Add(new ColorBrush("Green", Brushes.Green));
            colorBrushes.Add(new ColorBrush("Yellow", Brushes.Yellow));
            colorBrushes.Add(new ColorBrush("Violet", Brushes.Violet));
            colorBrushes.Add(new ColorBrush("Indigo", Brushes.Indigo));
            colorBrushes.Add(new ColorBrush("Orange", Brushes.Orange));
            colorBrushes.Add(new ColorBrush("Black", Brushes.Black));
            colorBrushes.Add(new ColorBrush("White", Brushes.White));
            return colorBrushes;
        }

        public static ObservableCollection<ColorBrush> ColorBrushCollection()
        {
            ObservableCollection<ColorBrush> colorBrushes = new ObservableCollection<ColorBrush>();
            colorBrushes.Add(new ColorBrush("Red", Brushes.Red));
            colorBrushes.Add(new ColorBrush("Blue", Brushes.Blue));
            colorBrushes.Add(new ColorBrush("Green", Brushes.Green));
            colorBrushes.Add(new ColorBrush("Yellow", Brushes.Yellow));
            colorBrushes.Add(new ColorBrush("Violet", Brushes.Violet));
            colorBrushes.Add(new ColorBrush("Indigo", Brushes.Indigo));
            colorBrushes.Add(new ColorBrush("Orange", Brushes.Orange));
            colorBrushes.Add(new ColorBrush("Black", Brushes.Black));
            colorBrushes.Add(new ColorBrush("White", Brushes.White));
            return colorBrushes;
        }

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
    }
}
