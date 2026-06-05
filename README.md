# Wisej.NET Component Forge Extension

This repository contains a Visual Studio 2022 VSIX extension targeting .NET Framework 4.8 (`net48`). The extension adds a **Wisej.NET Component Forge** command to the Visual Studio **Tools** menu. Selecting the command opens a dockable tool window titled **Wisej.NET Component Forge**.

The tool window hosts a WPF `WebView2` control that fills the entire window and is ready to display the Component Forge web experience.

## Project layout

- `Wisej.ComponentForgeExtension.sln` - Visual Studio solution.
- `Wisej.ComponentForgeExtension/Wisej.ComponentForgeExtension.csproj` - net48 VSIX extension project.
- `Wisej.ComponentForgeExtension/ComponentForgePackage.cs` - async Visual Studio package registration.
- `Wisej.ComponentForgeExtension/Menus/CommandTable.vsct` - Tools menu command placement.
- `Wisej.ComponentForgeExtension/Commands/ShowComponentForgeCommand.cs` - command handler that opens the tool window.
- `Wisej.ComponentForgeExtension/ToolWindows/ComponentForgeToolWindow.cs` - Visual Studio tool window pane.
- `Wisej.ComponentForgeExtension/ToolWindows/ComponentForgeWindowControl.xaml` - full-window WebView2 host.

## Build and run

Open `Wisej.ComponentForgeExtension.sln` in Visual Studio 2022 with the Visual Studio extension development workload installed, restore NuGet packages, and press **F5** to launch the experimental instance.
