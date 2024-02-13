using ComicManager.Common.Enum;

namespace ComicManager.UI.Common.Service.Contract
{
    public interface IMessageService
    {
        public bool IsAnyMessage();
        public void AddMessage(string text, MessagePriorityEnum priority);
        public List<(string, MessagePriorityEnum)> GetMessages();
        public void ClearMessages();
    }
}
