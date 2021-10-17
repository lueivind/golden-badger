using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        private bool dragging = false;

        /// <summary>
        /// Mainelement viewmodel currently selected.
        /// </summary>
        private StructureClassViewModel selectedViewModel;

        Point lastMouseDown;

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

        /// <summary>
        /// Get mouse position at mouse down.
        /// </summary>
        private void TreeViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                lastMouseDown = e.GetPosition(StructureExplorerTreeView);
            }
        }

        private void TreeViewItem_MouseMove(object sender, MouseEventArgs e)
        {
            // if left mouse button is pressed.
            if (e.LeftButton == MouseButtonState.Pressed)
            {

                Point currentPosition = e.GetPosition(StructureExplorerTreeView);
                if ((Math.Abs(currentPosition.X - lastMouseDown.X) > 10.0) || (Math.Abs(currentPosition.Y - lastMouseDown.Y) > 10.0))
                {
                    // cast to treeviewitem.
                    TreeViewItem item = (TreeViewItem)sender;
                    // serialize item.
                    DataObject itemSerialized = new DataObject(DataFormats.Serializable, item);
                    // do a drag and drop and pass along the item.
                    DragDrop.DoDragDrop(item, itemSerialized, DragDropEffects.Move);
                    dragging = true;
                }
            }
        }

        private void TreeViewItem_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;

            if (e.Data.GetDataPresent(DataFormats.Serializable))
            {
                TreeViewItem dropReceiverItem = (TreeViewItem)sender;
                TreeViewItem droppedItem = (TreeViewItem)e.Data.GetData(DataFormats.Serializable);

                if (ValidDrop(dropReceiverItem, droppedItem))
                {
                    e.Effects = DragDropEffects.Move;
                }
            }
            e.Handled = true;
        }

        private void TreeViewItem_Drop(object sender, DragEventArgs e)
        {
            // Event is fired for all ancestors in tree, only drop to first.
            if (!dragging)
                return;
            dragging = false;

            // get treeview items
            TreeViewItem dropReceiverItem = (TreeViewItem)sender;
            TreeViewItem droppedItem = (TreeViewItem)e.Data.GetData(DataFormats.Serializable);

            // get viewmodels
            if(dropReceiverItem.DataContext.GetType() != typeof(FolderViewModel))           // !!! TO DO: Should not happen --> investigate
            {
                // can't drop to structureviewmodel.
                return;
            }
            FolderViewModel dropReceiverViewModel = (FolderViewModel)dropReceiverItem.DataContext;
            IExplorerItem droppedViewModel = (IExplorerItem)droppedItem.DataContext;

            // remove from original source
            droppedViewModel.DeleteSelf();
            // move to drop receiver
            dropReceiverViewModel.AddChild(droppedViewModel);
        }

        /// <summary>
        /// Give user drop status feedback on mouse cursor symbol
        /// </summary>
        private void TreeViewItem_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (e.Effects.HasFlag(DragDropEffects.Move))
            {
                Mouse.SetCursor(Cursors.Hand);
            }
            else
            {
                Mouse.SetCursor(Cursors.No);
            }
            e.Handled = true;
        }

        private void TreeViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(((TreeViewItem)sender).DataContext.GetType() == typeof(StructureClassViewModel))
            {
                ((StructureClassViewModel)((TreeViewItem)sender).DataContext).MakeActive();
            }
        }

        private bool ValidDrop(TreeViewItem dropReceiverItem, TreeViewItem droppedItem)
        {
            // Drop rules
            // Drop rule #1 - Cant drop to self.
            // Drop rule #2 - Can only drop to folders.
            // Drop rule #3 - Cant drop to folder where dragged item already is.

            IExplorerItem dropReceiverItemViewModel = (IExplorerItem)dropReceiverItem.DataContext;
            IExplorerItem droppedItemViewModel = (IExplorerItem)droppedItem.DataContext;

            // Drop rule #1 - Cant drop to self.
            if (dropReceiverItem.DataContext == droppedItem.DataContext)
                return false;

            // Drop rule #2 - Can only drop to folders.
            if (dropReceiverItemViewModel.Type != ExplorerItemType.Folder)
                return false;

            // Drop rule #3 - Cant drop to folder where dragged item already is.
            //if (((FolderViewModel)dropReceiverItemViewModel).Children.Contains(droppedItemViewModel))
            //    return false;

            // Drop allowed.
            return true;
        }
    }
}
