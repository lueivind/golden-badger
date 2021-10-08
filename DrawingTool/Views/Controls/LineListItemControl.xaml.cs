using System.Windows.Controls;

namespace DrawingTool
{
    /// <summary>
    /// Interaction logic for GraphicListItemControl.xaml
    /// </summary>
    public partial class LineListItemControl : UserControl
    {
        #region Private Members

        /// <summary>
        /// Controll viewmodel.
        /// </summary>
        GraphicViewModel _viewModel;

        #endregion

        #region Contructor 

        /// <summary>
        /// Default constructor
        /// </summary>
        public LineListItemControl()
        {
            InitializeComponent();
        }

        #endregion
    }
}
