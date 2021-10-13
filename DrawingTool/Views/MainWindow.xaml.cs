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

        /// <summary>
        /// Structure class list selection  changed.
        /// </summary>
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ListView list = (ListView)sender;
            //selectedViewModel = (StructureClassViewModel)list.SelectedItem;

            //viewModel.SetCurrentStructureClass((StructureClassViewModel)list.SelectedItem);
        }

        /// <summary>
        /// Page list selection changed.
        /// </summary>
        private void ListViewPages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ListView list = (ListView)sender;
            //viewModel.SetCurrentPage((PageViewModel)list.SelectedItem);
        }
    }
}
