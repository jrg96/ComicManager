namespace ComicManager.Common.DTO.Response
{
    public class TaskResult<T> where T : class
    {
        public bool Successfull { get; set; }
        public IEnumerable<string> ErroList { get; set; } = new List<string>();
        public T Data { get; set; }
    }
}
