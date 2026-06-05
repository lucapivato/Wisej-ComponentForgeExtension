using System.Windows;
using System.Windows.Controls;

namespace Wisej.ComponentForgeExtension.ToolWindows
{
    public partial class ComponentForgeWindowControl : UserControl
    {
        public ComponentForgeWindowControl()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            Loaded -= OnLoaded;

            await Browser.EnsureCoreWebView2Async();
            Browser.NavigateToString(@"<!doctype html>
<html lang=""en"">
<head>
  <meta charset=""utf-8"" />
  <meta name=""viewport"" content=""width=device-width, initial-scale=1"" />
  <title>Wisej.NET Component Forge</title>
  <style>
    html, body { height: 100%; margin: 0; }
    body { display: grid; place-items: center; font-family: 'Segoe UI', Arial, sans-serif; color: #1f2937; background: #f8fafc; }
    main { text-align: center; padding: 2rem; }
    h1 { margin: 0 0 .5rem; font-size: 1.75rem; }
    p { margin: 0; color: #4b5563; }
  </style>
</head>
<body>
  <main>
    <h1>Wisej.NET Component Forge</h1>
    <p>WebView2 is ready for the Component Forge experience.</p>
  </main>
</body>
</html>");
        }
    }
}
