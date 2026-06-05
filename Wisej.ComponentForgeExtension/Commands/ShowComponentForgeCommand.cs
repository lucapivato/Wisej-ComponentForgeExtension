using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Wisej.ComponentForgeExtension.ToolWindows;
using Task = System.Threading.Tasks.Task;

namespace Wisej.ComponentForgeExtension.Commands
{
    internal sealed class ShowComponentForgeCommand
    {
        private readonly AsyncPackage package;

        private ShowComponentForgeCommand(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));

            CommandID menuCommandId = new CommandID(new Guid(Guids.CommandSetString), PackageIds.ComponentForgeCommand);
            MenuCommand menuItem = new MenuCommand(this.Execute, menuCommandId);
            commandService.AddCommand(menuItem);
        }

        public static async Task InitializeAsync(AsyncPackage package)
        {
            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService
                ?? throw new InvalidOperationException("Unable to acquire the Visual Studio command service.");

            _ = new ShowComponentForgeCommand(package, commandService);
        }

        private void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            this.package.JoinableTaskFactory.Run(async () =>
            {
                ToolWindowPane window = await this.package.ShowToolWindowAsync(typeof(ComponentForgeToolWindow), 0, true, this.package.DisposalToken);
                if (window?.Frame == null)
                {
                    throw new NotSupportedException("Cannot create the Wisej.NET Component Forge tool window.");
                }

                IVsWindowFrame windowFrame = (IVsWindowFrame)window.Frame;
                Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(windowFrame.Show());
            });
        }
    }
}
