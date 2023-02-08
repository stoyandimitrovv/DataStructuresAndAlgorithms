using System.Collections.Generic;

namespace DiscordStructure
{
    public interface IDiscord
    {
        void SendMessage(Message message);

        bool Contains(Message message);

        int Count { get; }

        Message GetMessage(string messageId);

        void DeleteMessage(string messageId);

        void ReactToMessage(string messageId, string reaction);

        IEnumerable<Message> GetMessageInTimeRange(int lowerBound, int upperBound);

        IEnumerable<Message> GetAllMessagesOrdered();
    }
}
