using ComicManager.Common.Enum;
using ComicManager.UI.Common.Service.Contract;

namespace ComicManager.UI.Common.Service
{
    public class MessageService : IMessageService
    {
        private List<(string, MessagePriorityEnum)> Messages { get; set; } = new List<(string, MessagePriorityEnum)>();

        public void AddMessage(string text, MessagePriorityEnum priority)
        {
            Messages.Add((text, priority));
        }

        public void ClearMessages()
        {
            Messages.Clear();
        }

        public List<(string, MessagePriorityEnum)> GetMessages()
        {
            return Messages;
        }

        public bool IsAnyMessage()
        {
            return Messages.Any();
        }
    }
}
