using System;

namespace DrawingTool
{
    public interface IExplorerItem
    {
        string Name { get; }

        Type Type { get; }

        /// <summary>
        /// Event based on delete, can be subscribed to.
        /// </summary>

        event EventHandler Delete;
        void DeleteSelf();
    }

    public enum Type
    {
        Folder,
        StructureClass
    }
}
