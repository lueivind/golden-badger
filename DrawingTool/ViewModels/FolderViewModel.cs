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
            RenameCommand = new RelayCommand(Rename);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Folder name
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    if (value.Replace(" ", "") != "") // dont allow whitespace string
                    {
                        name = value.Trim(); // trim trailing whitespace
                        OnPropertyChanged(nameof(Name));
                    }
                }
            }
        }
        private string name;

        /// <summary>
        /// Name is locked, folder cannot be renamed.
        /// </summary>
        public bool NameLocked
        {
            get => nameLocked;
            private set
            {
                if(nameLocked != value)
                {
                    nameLocked = value;
                    OnPropertyChanged(nameof(NameLocked));
                }
            }
        }
        private bool nameLocked;

        /// <summary>
        /// Is renaming.
        /// </summary>
        public bool Renaming
        {
            get => renaming;
            set
            {
                if (renaming != value)
                {
                    renaming = value;
                    OnPropertyChanged(nameof(Renaming));
                }
            }
        }
        private bool renaming;

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

        /// <summary>
        /// Lock folder name
        /// </summary>
        public void LockName()
        {
            NameLocked = true;
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

        /// <summary>
        /// Command for renaming structure class.
        /// </summary>
        public ICommand RenameCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Add new folder.
        /// </summary>
        public void AddFolder()
        {
            FolderViewModel folder = new FolderViewModel("Folder " + Children.Count.ToString(), explorer);
            folder.Rename();
            folder.Delete += Child_Delete;
            Children.Add(folder);
        }

        /// <summary>
        /// Add new structure class
        /// </summary>
        public void AddStructureClass()
        {
            StructureClassViewModel structure = new StructureClassViewModel("New Structure Class " + this.Children.Count.ToString(), explorer);
            structure.Rename();
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

        /// <summary>
        /// Rename structure class.
        /// </summary>
        private void Rename()
        {
            Renaming = true;
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
