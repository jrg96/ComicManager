using ComicManager.Common.Enum;
using ComicManager.UI.Common.Service.Contract;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ComicManager.UI.Client.Components.Common
{

    /// <summary>
    /// Class <c>BasePage</c> used to hold any middleware logic a component (that uses @page)
    /// needs to execute automatically
    /// </summary>
    public class BasePage : ComponentBase
    {
        [Inject]
        protected IMessageService MessageService { get; set; }

        protected List<(string, Severity)> Messages { get; set; } = new List<(string, Severity)>();


        protected override Task OnInitializedAsync()
        {
            /*
             * As part of the middleware logic, check if there is any pending message to
             * display
             */
            if (MessageService.IsAnyMessage())
            {
                foreach ((string msg, MessagePriorityEnum priority) in MessageService.GetMessages())
                {
                    Severity severity = Severity.Normal;
                    
                    switch(priority)
                    {
                        case MessagePriorityEnum.Info:
                        case MessagePriorityEnum.Debug:
                            severity = Severity.Info;
                            break;
                        case MessagePriorityEnum.Error:
                            severity = Severity.Error;
                            break;
                        case MessagePriorityEnum.Warning:
                            severity = Severity.Warning;
                            break;
                    }

                    Messages.Add((msg, severity));
                }

                MessageService.ClearMessages();
            }

            return base.OnInitializedAsync();
        }
    }
}
