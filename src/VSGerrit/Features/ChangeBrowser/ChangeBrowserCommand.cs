using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using vsgerrit.Features.ChangeBrowser.Resources;

namespace vsgerrit.Features.ChangeBrowser
{
    internal sealed class ChangeBrowserCommand
    {
        public const int CommandId = 0x0100;

        public static readonly Guid CommandSet = new Guid("7e8d4b4f-450f-406f-916a-51fa03188d73");

        private readonly Package _package;

        private IServiceProvider ServiceProvider => _package;

        private ChangeBrowserCommand(Package package)
        {
            if (package == null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            _package = package;

            var commandService = ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService == null)
                return;

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(ShowToolWindow, menuCommandID);
            commandService.AddCommand(menuItem);
        }

        public static ChangeBrowserCommand Instance
        {
            get;
            private set;
        }

        public static void Initialize(Package package)
        {
            Instance = new ChangeBrowserCommand(package);
        }

        private void ShowToolWindow(object sender, EventArgs e)
        {
            var window = _package.FindToolWindow(typeof(ChangeBrowserWindow), 0, true);
            if (window?.Frame == null)
            {
                throw new NotSupportedException(ChangeBrowserStrings.InitializeError);
            }

            var windowFrame = (IVsWindowFrame)window.Frame;
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }
    }
}
