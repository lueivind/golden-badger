using IronPdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DrawingTool
{
    public class MainViewModel : BaseViewModel
    {
        #region Private Members

        private bool devMode; 

        #endregion

        #region Constructor 

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainViewModel()
        {
            // collections
            Pages = new ObservableCollection<PageViewModel>();

            var pdf = PdfDocument.FromFile("Resources/test.pdf");
            string[] strings = pdf.RasterizeToImageFiles("*.png");

            foreach (string s in strings)
            {
                var path = Path.Combine(Environment.CurrentDirectory, s);
                var uri = new Uri(path);

                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = uri;
                image.EndInit();
             
                PageViewModel page = new PageViewModel("Page" + Pages.Count.ToString(), image);
                Pages.Add(page);
            }

        }

        #endregion

        #region Collections

        public ObservableCollection<PageViewModel> Pages { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Currently selected page.
        /// </summary>
        public PageViewModel CurrentPage
        {
            get => currentPage;
            set
            {
                if(currentPage != value)
                {
                    currentPage = value;
                    OnPropertyChanged(nameof(CurrentPage));
                }
            }
        }
        private PageViewModel currentPage;
        #endregion

        #region Commands

        #endregion

        #region Helpers

        #endregion
    }
}
