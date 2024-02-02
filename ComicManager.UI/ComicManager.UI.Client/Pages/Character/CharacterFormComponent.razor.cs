using ComicManager.Common.DTO.Character;
using ComicManager.Common.Enum;
using ComicManager.UI.Common.Service.Contract;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace ComicManager.UI.Client.Pages.Character
{
    public class CharacterFormComponentBase : ComponentBase
    {
        [Inject]
        ICharacterService CharacterService { get; set; }

        [Parameter]
        public CharacterDTO Character { get; set; }

        [Parameter]
        public FormActionEnum Action { get; set; } = FormActionEnum.View;

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
        protected void OnEditBtnClick(MouseEventArgs args)
        {
            Action = FormActionEnum.Edit;
        }
    }
}
