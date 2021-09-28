using System.Windows;
using System.Windows.Controls;

namespace DrawingTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members

        /// <summary>
        /// Mainwindow viewmodel.
        /// </summary>
        private MainViewModel viewModel;

        /// <summary>
        /// Mainelement viewmodel currently selected.
        /// </summary>
        private StructureClassViewModel selectedViewModel;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainViewModel();
            this.DataContext = viewModel;
        }

        #endregion

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView list = (ListView)sender;
            selectedViewModel = (StructureClassViewModel)list.SelectedItem;

            viewModel.CurrentPage.CurrentStructureClass = (StructureClassViewModel)list.SelectedItem;
        }

        private void ListViewPages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView list = (ListView)sender;
            viewModel.CurrentPage = (PageViewModel)list.SelectedItem;
            //MainCanvas = viewModel.CurrentPage.PageCanvas;
            //MainCanvas.UpdateDefaultStyle();
        }
    }
}
