using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawingTool
{
    /// <summary>
    /// Viewmodel for graphical element
    /// </summary>
    public class GraphicViewModel : BaseViewModel
    {

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public GraphicViewModel(string name, StructureClassViewModel structureClass, PageViewModel page)
        {
            Name = name;
            Page = page;

            // commands
            DeleteCommand = new RelayCommand(OnDeleteGraphics);
            GoToPageCommand = new RelayCommand(GoToPage);

            // subscribe to events
            structureClass.ColorChanged += StructureClass_ColorChanged;

            // color
            Colors = ColorBrush.ColorBrushCollection();
            Colors.Insert(0, new ColorBrush("By Structure Class", structureClass.ColorBrush.Color));
            ColorBrush = Colors[0];
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Set graphic color by parent <see cref="StructureClassViewModel"/> <see cref="StructureClassViewModel.ColorBrush"/>
        /// </summary>
        public bool ColorByStructure { get; private set; } = true;

        /// <summary>
        /// Name of element
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Shape is selected in canvas.
        /// </summary>
        public bool IsSelected
        {
            get => isSelected;
            private set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }
        private bool isSelected;


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
                    OnPropertyChanged(nameof(ColorBrush));
                }
            }
        }
        private ColorBrush colorBrush;

        /// <summary>
        /// List of colors.
        /// </summary>
        public ObservableCollection<ColorBrush> Colors { get; set; }

        /// <summary>
        /// Graphical element
        /// </summary>
        public Shape Shape { get; set; }

        /// <summary>
        /// Page in which this graphic exist.
        /// </summary>
        public PageViewModel Page { get; private set; }

        #endregion

        #region Commands

        /// <summary>
        /// Command to delete self.
        /// </summary>
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// Command to go to page where this graphic exist.
        /// </summary>
        public ICommand GoToPageCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Go to page where this graphic exist.
        /// </summary>
        private void GoToPage()
        {
            Page.MakeSelfCurrentMake();
        }


        /// <summary>
        /// Select shape in canvas.
        /// </summary>
        public virtual void Select() 
        {
            IsSelected = true;
        }

        /// <summary>
        /// Deselect shape in canvas.
        /// </summary>
        public virtual void DeSelect() 
        {
            IsSelected = false;
        }

        #endregion

        #region Events

        /// <summary>
        /// Called when parent structure class changes color.
        /// </summary>
        private void StructureClass_ColorChanged(object source, EventArgs args)
        {
            // check if graphic follows structure class color
            ColorByStructure = Colors[0] == ColorBrush ? true : false;

            // set "By Structure Class" color.
            Colors[0] = new ColorBrush("By Structure Class", ((StructureClassViewModel)source).ColorBrush.Color);
            
            // if graphic is color by structure follow structure class color change.
            if (ColorByStructure)
            {
                ColorBrush = Colors[0];
            }
        }

        #endregion

        #region Event: Delete Graphic

        /// <summary>
        /// Event delegate.
        /// </summary>
        public delegate void DeleteGraphicEventHandler(object source, EventArgs args);

        /// <summary>
        /// Event based on delete, can be subscribed to.
        /// </summary>
        public event DeleteGraphicEventHandler DeleteGraphic;

        /// <summary>
        /// Raise the event.
        /// </summary>
        protected virtual void OnDeleteGraphics()
        {
            // delete line from canvas
            Canvas canvas = (Canvas)Shape.Parent;
            canvas.Children.Remove(Shape);

            // delete viewmodel
            DeleteGraphic?.Invoke(this, EventArgs.Empty);
        }

        #endregion




    }
}
