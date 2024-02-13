using ComicManager.Common.DTO.Character;
using ComicManager.Common.DTO.Response;
using ComicManager.UI.Client.Components.Common;
using ComicManager.UI.Common.Service.Contract;
using Microsoft.AspNetCore.Components;

namespace ComicManager.UI.Client.Pages.Character
{
    public class CharacterInfoComponentBase : BasePage
    {
        [Inject]
        protected ICharacterService CharacterService { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        public CharacterDTO Character { get; set; }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            // Call API to get character
            TaskResult<CharacterDTO> result = await CharacterService.GetCharacter(Id);
            Character = result.Data;

            await base.OnParametersSetAsync();
        }
    }
}
