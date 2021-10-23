using System.Collections.ObjectModel;

namespace DrawingTool
{
    public class StructureExplorerViewModel : BaseViewModel
    {
        private bool dummyData = true;

        /// <summary>
        /// Default constructor
        /// </summary>
        public StructureExplorerViewModel()
        {
            Children = new ObservableCollection<IExplorerItem>();
            var explorer = new FolderViewModel("Structure Explorer", this);
            explorer.LockName();
            Children.Add(explorer);

            // dummy data
            if (dummyData)
            {
                explorer.AddStructureClass();
                ((StructureClassViewModel)explorer.Children[0]).Renaming = false;
                explorer.AddStructureClass();
                explorer.AddStructureClass();
            }

        }

        public StructureClassViewModel ActiveStructureClass
        {
            get => activeStructureClass;
            private set
            {
                if (activeStructureClass != value)
                {
                    activeStructureClass = value;
                    OnPropertyChanged(nameof(ActiveStructureClass));
                }
            }
        }
        private StructureClassViewModel activeStructureClass;

        /// <summary>
        /// A new <see cref="StructureClassViewModel"/> is set as active.
        /// </summary>
        /// <param name="activeStructureClass"><see cref="StructureClassViewModel"/> set as active.</param>
        public void NotifyOnActiveStructure(StructureClassViewModel activeStructureClass)
        {
            // Notify active structure class has changed.
            OnActiveStructureClassChanged(activeStructureClass);
            // Change active structure class.
            ActiveStructureClass = activeStructureClass;
        }

        /// <summary>
        /// Explorer children.
        /// </summary>
        public ObservableCollection<IExplorerItem> Children { get; set; }

        public delegate void ActiveStructureClassChangedEventHandler(object source, StructureClassEventArgs args);
        public event ActiveStructureClassChangedEventHandler ActiveStructureClassChanged;
        protected virtual void OnActiveStructureClassChanged(StructureClassViewModel activeStructureClass)
        {
            ActiveStructureClassChanged?.Invoke(this, new StructureClassEventArgs(activeStructureClass));
        }

    }
}
