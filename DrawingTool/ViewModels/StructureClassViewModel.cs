using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;

namespace DrawingTool
{
    /// <summary>
    /// Viewmodel for wall type / structure class
    /// </summary>
    public class StructureClassViewModel : BaseViewModel, IExplorerItem
    {
        private StructureExplorerViewModel explorer;

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public StructureClassViewModel(string name, StructureExplorerViewModel explorer)
        {
            Name = name;
            this.explorer = explorer;

            // collections
            Lines = new ObservableCollection<LineViewModel>();
            //PolyLines = new ObservableCollection<PolylineViewModel>();
            //Areas = new ObservableCollection<AreaViewModel>();
            //Counters = new ObservableCollection<CounterViewModel>();
            // color

            Colors = ColorBrush.ColorBrushes();
            ColorBrush = Colors[0];

            // commands
            DeleteCommand = new RelayCommand(DeleteSelf);
            MakeActiveCommand = new RelayCommand(MakeActive);
            RenameCommand = new RelayCommand(Rename);

            explorer.ActiveStructureClassChanged += Explorer_ActiveStructureClassChanged;
        }

        /// <summary>
        /// Dummy constructor
        /// </summary>
        //public StructureClassViewModel()
        //{

        //}

        #endregion

        #region Collections

        /// <summary>
        /// Collection of graphical line elements.
        /// </summary>
        public ObservableCollection<LineViewModel> Lines { get; private set; }

        ///// <summary>
        ///// Collection of graphical poyline elements.
        ///// </summary>
        //public ObservableCollection<PolylineViewModel> PolyLines { get; private set; }

        ///// <summary>
        ///// Collection of graphical area elements.
        ///// </summary>
        //public ObservableCollection<AreaViewModel> Areas { get; private set; }

        ///// <summary>
        ///// Collection of graphical counter elements.
        ///// </summary>
        //public ObservableCollection<CounterViewModel> Counters { get; private set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Name of class.
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                if(name != value)
                {
                    if(value.Replace(" ", "") != "") // dont allow whitespace string
                    {
                        name = value.Trim(); // trim trailing whitespace
                        OnPropertyChanged(nameof(Name));
                    }
                }
            }
        }
        private string name;

        /// <summary>
        /// Is renaming.
        /// </summary>
        public bool Renaming
        {
            get => renaming;
            set
            {
                if(renaming != value)
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
        public ExplorerItemType Type => ExplorerItemType.StructureClass;

        /// <summary>
        /// Color of this structure class.
        /// </summary>
        public ColorBrush ColorBrush
        {
            get => colorBrush;
            set
            {
                if(colorBrush != value)
                {
                    colorBrush = value;
                    OnColorChanged();
                }
            }
        }
        private ColorBrush colorBrush;

        /// <summary>
        /// List of colors.
        /// </summary>
        public List<ColorBrush> Colors { get; }

        /// <summary>
        /// True if this is the active structure class.
        /// </summary>
        public bool IsActive
        {
            get => isActive;
            private set
            {
                if(isActive != value)
                {
                    isActive = value;
                    OnPropertyChanged(nameof(IsActive));
                }
            }
        }
        private bool isActive;

        #endregion

        #region Commands

        /// <summary>
        /// Command for deleting self.
        /// </summary>
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// Command for setting structure class as active.
        /// </summary>
        public ICommand MakeActiveCommand { get; set; }

        /// <summary>
        /// Command for renaming structure class.
        /// </summary>
        public ICommand RenameCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Set color of graphical elements under this structure class.
        /// </summary>
        public void SetColor(Brush brush)
        {
            foreach (LineViewModel line in Lines)
            {
                line.Line.Stroke = ColorBrush.Color;
            }
        }

        public void AddGraphic(GraphicViewModel graphic)
        {
            graphic.DeleteGraphic += Graphic_DeleteGraphic;
            
            // line
            if(graphic.GetType() == typeof(LineViewModel))
            {
                Lines.Add((LineViewModel)graphic);
            }
        }

        /// <summary>
        /// Delete self.
        /// </summary>
        public void DeleteSelf()
        {
            OnDelete();
        }

        public void MakeActive()
        {
            IsActive = true;
            explorer.NotifyOnActiveStructure(this);
        }

        public void MakeNotActive()
        {
            IsActive = false;
        }

        /// <summary>
        /// Rename structure class.
        /// </summary>
        private void Rename()
        {
            Renaming = true;
        }

        #endregion

        #region Event Subscribtions

        /// <summary>
        /// Event fired when graphic wants to be deleted.
        /// </summary>
        private void Graphic_DeleteGraphic(object source, System.EventArgs args)
        {
            GraphicViewModel graphic = (GraphicViewModel)source;

            // line
            if (graphic.GetType() == typeof(LineViewModel))
            {
                Lines.Remove((LineViewModel)graphic);
            }
        }

        private void Explorer_ActiveStructureClassChanged(object source, StructureClassEventArgs args)
        {
            if(this != args.StructureClass)
            {
                MakeNotActive();
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Structure class changed color.
        /// </summary>
        public event EventHandler ColorChanged;
        protected virtual void OnColorChanged()
        {
            ColorChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Structure class asking to be deleted.
        /// </summary>
        public event EventHandler Delete;
        protected virtual void OnDelete()
        {
            Delete?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
