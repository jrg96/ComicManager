using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace ComicManager.UI.Client.Components.Common
{
    public class YesNoDialogComponentBase : ComponentBase
    {
        [Parameter]
        public string Text { get; set; }

        [CascadingParameter] 
        MudDialogInstance MudDialog { get; set; }


        /*
         * UI Event Handlers
         */
        protected void OnCancelBtnClick(MouseEventArgs args)
        {
            MudDialog.Cancel();
        }

        protected void OnOkBtnClick(MouseEventArgs args)
        {
            MudDialog.Close(DialogResult.Ok(true));
        }
    }
}
