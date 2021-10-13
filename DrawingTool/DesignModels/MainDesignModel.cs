using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace DrawingTool
{
    public class MainDesignModel : MainViewModel
    {
        public MainDesignModel()
        {

        }

        public MainDesignModel(bool test)
        {
            ApplicationName = "MainDesignModel";

            if (test)
            {
                Pages = new ObservableCollection<PageViewModel>();
                Pages.Add(new PageViewModel("Test1", new BitmapImage(), this));
                Pages.Add(new PageViewModel("Test1", new BitmapImage(), this));
                Pages.Add(new PageViewModel("Test1", new BitmapImage(), this));
            }
        }

        /// <summary>
        /// Design instance.
        /// </summary>
        public static MainDesignModel Instance { get; } = new MainDesignModel();
    }
}
