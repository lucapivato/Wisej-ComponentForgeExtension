using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using Wisej.ComponentForgeExtension.Commands;
using Wisej.ComponentForgeExtension.ToolWindows;

namespace Wisej.ComponentForgeExtension
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("Wisej.NET Component Forge", "Adds the Wisej.NET Component Forge tool window to Visual Studio.", "1.0")]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(ComponentForgeToolWindow), Style = VsDockStyle.Tabbed, Window = "{3AE79031-E1BC-11D0-8F78-00A0C9110057}")]
    [Guid(Guids.PackageString)]
    public sealed class ComponentForgePackage : AsyncPackage
    {
        protected override async System.Threading.Tasks.Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await base.InitializeAsync(cancellationToken, progress);
            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            await ShowComponentForgeCommand.InitializeAsync(this);
        }
    }
}
