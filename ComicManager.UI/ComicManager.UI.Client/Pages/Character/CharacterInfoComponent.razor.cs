using ComicManager.UI.Common.Service.Contract;
using Microsoft.AspNetCore.Components;

namespace ComicManager.UI.Client.Pages.Character
{
    public class CharacterInfoComponentBase : ComponentBase
    {
        [Inject]
        protected ICharacterService CharacterService { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        protected override Task OnParametersSetAsync()
        {
            var tets = "A simple example here";
            return base.OnParametersSetAsync();
        }
    }
}
