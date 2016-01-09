using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using vsgerrit.Features.ChangeBrowser.Resources;

namespace vsgerrit.Features.ChangeBrowser
{
    [Guid("adfe3bef-6eef-408c-a7d7-7a780a1fed96")]
    public class ChangeBrowserWindow : ToolWindowPane
    {
        public ChangeBrowserWindow() : base(null)
        {
            Caption = ChangeBrowserStrings.Title;
            Content = new ChangeBrowserControl();
        }
    }
}
