using Azure;
using ComicManager.Common.DTO.Character;
using ComicManager.Common.DTO.Request;
using ComicManager.Common.DTO.Response;
using ComicManager.Common.Enum;
using ComicManager.UI.Common.Service.Contract;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ComicManager.UI.Client.Pages.Character
{
    public class CharacterListComponentBase : ComponentBase
    {
        [Inject]
        public ICharacterService CharacterService { get; set; }

        public MudTable<CharacterDTO> Table { get; set; }
        public int[] pageSizeOptions = new int[] { 5, 10, 15 };

        protected override Task OnParametersSetAsync()
        {
            // Get Character List


            return base.OnParametersSetAsync();
        }

        public async Task<TableData<CharacterDTO>> GetCharacterList(TableState state)
        {
            TaskResult<PageDTO<CharacterDTO>> result = await CharacterService.GetCharacterList(new GetCharacterListDTO()
            {
                Page = new PageDTO<CharacterDTO>() 
                {
                    Number = state.Page + 1,
                    Size = state.PageSize,
                    Sorting = state.SortDirection == SortDirection.Descending ? SortModeEnum.Descending : SortModeEnum.Descending,
                    Data = new List<CharacterDTO>(),
                    SortingColumn = string.IsNullOrEmpty(state.SortLabel) ? SortingFieldEnum.Name : Enum.Parse<SortingFieldEnum>(state.SortLabel)
                }
            });
            
            if (!result.Successfull)
            {
                // Handle error
            }

            PageDTO<CharacterDTO> data = result.Data;
            return new TableData<CharacterDTO>
            {
                TotalItems = (int)data.TotalRecords,
                Items = data.Data
            };
        }

        public void OnRowSelected(TableRowClickEventArgs<CharacterDTO> eventArgs)
        {
            var test = "";
        }
    }
}
