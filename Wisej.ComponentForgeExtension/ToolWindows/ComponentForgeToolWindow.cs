using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace Wisej.ComponentForgeExtension.ToolWindows
{
    [Guid(Guids.ComponentForgeWindowString)]
    public sealed class ComponentForgeToolWindow : ToolWindowPane
    {
        public ComponentForgeToolWindow() : base(null)
        {
            this.Caption = "Wisej.NET Component Forge";
            this.Content = new ComponentForgeWindowControl();
        }
    }
}
