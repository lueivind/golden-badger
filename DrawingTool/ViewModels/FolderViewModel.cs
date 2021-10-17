using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DrawingTool
{
    public class FolderViewModel : BaseViewModel, IExplorerItem
    {
        private StructureExplorerViewModel explorer;

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public FolderViewModel(string name, StructureExplorerViewModel explorer)
        {
            Name = name;
            this.explorer = explorer;

            // collections
            Children = new ObservableCollection<IExplorerItem>();
            // commands
            AddFolderCommand = new RelayCommand(AddFolder);
            AddStructureClassCommand = new RelayCommand(AddStructureClass);
            DeleteCommand = new RelayCommand(DeleteSelf);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Folder name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// <see cref="IExplorerItem"/> type
        /// </summary>
        public ExplorerItemType Type => ExplorerItemType.Folder;

        /// <summary>
        /// Delete self.
        /// </summary>
        public void DeleteSelf()
        {
            OnDelete();
        }

        #endregion

        #region Collections

        /// <summary>
        /// Folder children.
        /// </summary>
        public ObservableCollection<IExplorerItem> Children { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Command for adding new folder.
        /// </summary>
        public ICommand AddFolderCommand { get; set; }
        
        /// <summary>
        /// Command for adding new structure class.
        /// </summary>
        public ICommand AddStructureClassCommand { get; set; }
        
        /// <summary>
        /// Command for deleting self.
        /// </summary>
        public ICommand DeleteCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Add new folder.
        /// </summary>
        public void AddFolder()
        {
            FolderViewModel folder = new FolderViewModel("Folder " + Children.Count.ToString(), explorer);
            folder.Delete += Child_Delete;
            Children.Add(folder);
        }

        /// <summary>
        /// Add new structure class
        /// </summary>
        public void AddStructureClass()
        {
            StructureClassViewModel structure = new StructureClassViewModel("New Structure Class " + this.Children.Count.ToString(), explorer);
            structure.Delete += Child_Delete;
            Children.Add(structure);
        }

        /// <summary>
        /// From drop
        /// </summary>
        public void AddChild(IExplorerItem item)
        {
            Children.Add(item);
            item.Delete += Child_Delete;
        }

        /// <summary>
        /// Child is asking to be deleted.
        /// </summary>
        private void Child_Delete(object source, EventArgs args)
        {

            Children.Remove((IExplorerItem)source);

        }

        #endregion

        #region Events

        /// <summary>
        /// Folder asking to be deleted.
        /// </summary>
        public event EventHandler Delete;
        protected virtual void OnDelete()
        {
            Delete?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
