using System.Windows.Media.Imaging;

namespace DrawingTool
{
    public class PageDesignModel : PageViewModel
    {
        public PageDesignModel(string name, BitmapImage image, MainViewModel mainViewModel) : base(name, image, mainViewModel)
        {
        }

        public static PageDesignModel Instance { get; } = new PageDesignModel("Page Design Model", new BitmapImage(), new MainViewModel());

    }
}
