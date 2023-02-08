﻿using System.Collections.Generic;

namespace DiscordStructure  
{
    public class Message
    {
        public Message(string id, string content, int timestamp, string channel)
        {
            this.Id = id;
            this.Content = content;
            this.Timestamp = timestamp;
            this.Channel = channel;

            this.Reactions = new List<string>();
        }

        public string Id { get; set; }

        public string Content { get;set; }

        public int Timestamp { get; set; }

        public int ChannelCount { get; set; }

        public string Channel { get; set; }

        public List<string> Reactions { get; set; }
    }
}
