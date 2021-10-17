using System;

namespace DrawingTool
{
    public class StructureClassEventArgs : EventArgs
    {
        public StructureClassEventArgs(StructureClassViewModel structureClass)
        {
            StructureClass = structureClass;
        }

        public StructureClassViewModel StructureClass { get; set; }
    }
}
