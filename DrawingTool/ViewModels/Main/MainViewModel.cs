using IronPdf;
using Microsoft.Win32;
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

        /// <summary>
        /// Default color brushes for structure class color.
        /// </summary>
        private List<Brush> DefaultBrushes;

        private bool importPdfOnLoad = true;
        private readonly string importPdfOnLoadPath = "Resources/test.pdf";

        private string fileName;

        #endregion

        #region Constructor 

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainViewModel()
        {
            // initalize
            intialize();

            // import pdf on start
            if (importPdfOnLoad)
            {
                ConvertPDF(importPdfOnLoadPath);
            }
        }

        /// <summary>
        /// Do initialization opertaions during construct.
        /// </summary>
        private void intialize()
        {
            // collections
            Pages = new ObservableCollection<PageViewModel>();
            StructureClasses = new ObservableCollection<StructureClassViewModel>();

            // commands
            ImportCommand = new RelayCommand(Import);
            AddStructureClassCommand = new RelayCommand(AddStructureClass);

            // dummy sctructures classes
            AddStructureClass();
            AddStructureClass();
            AddStructureClass();
        }

        #endregion

        #region Collections

        /// <summary>
        /// Collection of pages
        /// </summary>
        public ObservableCollection<PageViewModel> Pages { get; set; }


        /// <summary>
        /// Collection of structure classes.
        /// </summary>
        public ObservableCollection<StructureClassViewModel> StructureClasses { get; set; }

        #endregion

        #region Public Properties

        public string ApplicationName { get; set; } = "Golden-Badger";

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

        /// <summary>
        /// Currently selected structure class.
        /// </summary>
        public StructureClassViewModel CurrentStructureClass { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Command to import file.
        /// </summary>
        public ICommand ImportCommand { get; set; }

        /// <summary>
        /// Command for adding new structure class.
        /// </summary>
        public ICommand AddStructureClassCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Set current page.
        /// </summary>
        public void SetCurrentPage(PageViewModel page)
        {
            CurrentPage = page;
        }

        /// <summary>
        /// Set current structure class.
        /// </summary>
        public void SetCurrentStructureClass(StructureClassViewModel structureClass)
        {
            CurrentStructureClass = structureClass;
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Import file.
        /// </summary>
        private void Import()
        {
            // Open filedialog
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Pdf Files|*.pdf";

            // Remember location of last import if it exists
            if (fileName != null)
                fileDialog.InitialDirectory = fileName;
            else
                fileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // If file selcted by user.
            if (fileDialog.ShowDialog() == false)
                return;

            // Convert file
            fileName = fileDialog.FileName;
            ConvertPDF(fileName);
        }

        /// <summary>
        /// Convert file from PDF to PNG.
        /// </summary>
        private void ConvertPDF(string filename)
        {
            var pdf = PdfDocument.FromFile(filename);
            string[] strings = pdf.RasterizeToImageFiles("*.png");

            foreach (string s in strings)
            {
                var path = Path.Combine(Environment.CurrentDirectory, s);
                var uri = new Uri(path);

                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = uri;
                image.EndInit();

                PageViewModel page = new PageViewModel("Page" + Pages.Count.ToString(), image, this);
                Pages.Add(page);
            }
        }

        /// <summary>
        /// Add new structure class.
        /// </summary>
        private void AddStructureClass()
        {
            StructureClasses.Add(new StructureClassViewModel("Structure Class " + StructureClasses.Count.ToString()));
        }

        #endregion

    }
}
