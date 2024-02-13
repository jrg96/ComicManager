using ComicManager.Common.DTO.Character;
using ComicManager.Common.DTO.Response;
using ComicManager.Common.Enum;
using ComicManager.UI.Client.Components.Common;
using ComicManager.UI.Common.Service.Contract;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace ComicManager.UI.Client.Components.Character
{
    public class CharacterFormComponentBase : ComponentBase
    {
        [Inject]
        ICharacterService CharacterService { get; set; }

        [Inject]
        IDialogService DialogService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Inject]
        IMessageService MessageService { get; set; }

        [Parameter]
        public CharacterDTO Character { get; set; }

        [Parameter]
        public FormActionEnum Action { get; set; } = FormActionEnum.View;

        /*
         * Private variables
         */
        protected CharacterDTO _character;

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        protected override Task OnParametersSetAsync()
        {
            return base.OnParametersSetAsync();
        }

        /*
         * UI Events
         */
        protected async Task OnSaveBtnClick(MouseEventArgs args)
        {
            TaskResult<CharacterDTO> result = null;

            if (Action == FormActionEnum.Edit)
            {
                result = await CharacterService.UpdateCharacter(Character);
            }

            if (result != null && !result.Successfull)
            {
                MessageService.AddMessage(string.Join(",", result.ErroList), MessagePriorityEnum.Error);
            }
            else
            {
                MessageService.AddMessage("Character Added/Updated successfully", MessagePriorityEnum.Info);
            }

            NavigationManager.NavigateTo("/characters");
        }

        protected void OnEditBtnClick(MouseEventArgs args)
        {
            _character = (CharacterDTO)Character.Clone();
            Action = FormActionEnum.Edit;
        }

        protected async Task OnCancelBtnClick(MouseEventArgs args)
        {
            DialogParameters dialogParams = new DialogParameters()
            {
                ["Text"] = "Are you sure you want to cancel changes?"
            };

            DialogOptions options = new DialogOptions()
            {
                CloseOnEscapeKey = false,
                Position = DialogPosition.Center,
                FullWidth = true,
            };

            var result = await DialogService.Show<YesNoDialogComponent>("Cancel changes", dialogParams, options).Result;
            if (!result.Cancelled && bool.TryParse(result.Data.ToString(), out bool resultbool))
            {
                Action = FormActionEnum.View;
                Character = _character;
            }
        }
    }
}
