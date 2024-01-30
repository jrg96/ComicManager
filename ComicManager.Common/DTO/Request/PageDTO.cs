using ComicManager.Common.Enum;

namespace ComicManager.Common.DTO.Request
{
    public class PageDTO<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }

        public int Number { get; set; }
        public int Size { get; set; }
        public long TotalRecords { get; set; }
        public SortModeEnum Sorting  { get; set; }
        public SortingFieldEnum SortingColumn { get; set; }
    }
}
