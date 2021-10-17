using System;

namespace DrawingTool
{
    public interface IExplorerItem
    {
        ExplorerItemType Type { get; }

        event EventHandler Delete;
        void DeleteSelf();
    }

    public enum ExplorerItemType
    {
        Folder,
        StructureClass
    }
}
