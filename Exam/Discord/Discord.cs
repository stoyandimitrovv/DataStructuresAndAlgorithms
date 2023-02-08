using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Channels;
using System.Xml.Linq;

namespace DiscordStructure
{
    public class Discord : IDiscord
    {
        private readonly List<Message> messages;

        public Discord()
        {
            this.messages = new List<Message>();
        }

        public int Count => this.messages.Count;

        public bool Contains(Message message)
        {
            if (this.GetMessage(message.Id) != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void DeleteMessage(string messageId)
        {
            var message = this.messages.FirstOrDefault(m => m.Id == messageId);

            if (message == null)
            {
                throw new ArgumentException();
            }
            else
            {
                this.messages.Remove(this.GetMessage(messageId));
            }
        }

        public IEnumerable<Message> GetAllMessagesOrdered()
        {
            return this.messages
                .OrderByDescending(m => m.Reactions.Count)
                .ThenBy(m => m.Timestamp)
                .ThenBy(m => m.Content.Length)
                .ToList();
        }

        public Message GetMessage(string messageId)
        {
            var message = this.messages.FirstOrDefault(m => m.Id == messageId);

            if (message == null)
            {
                throw new ArgumentException(); 
            }
            else
            {
                return message;
            }
        }

        public IEnumerable<Message> GetMessageInTimeRange(int lowerBound, int upperBound)
        {
            return this.messages
                .Where(m => m.Timestamp >= lowerBound && m.Timestamp <= upperBound)
                .OrderByDescending(m => m.ChannelCount)
                .ToList();
        }

        public void ReactToMessage(string messageId, string reaction)
        {
            var message = this.messages.FirstOrDefault(m => m.Id == messageId);

            if (message == null)
            {
                throw new ArgumentException();
            }
            else
            {
                this.GetMessage(messageId).Reactions.Add(reaction);
            }
        }

        public void SendMessage(Message message)
        {
            this.messages.Add(message);
        }
    }
}
