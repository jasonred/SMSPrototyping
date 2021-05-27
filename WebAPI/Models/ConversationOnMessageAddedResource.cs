using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ConversationOnMessageAddedResource
    {
        public string EventType { get; set; }
        public string ConversationSid { get; set; }
        public string MessageSid { get; set; }
        public int Index { get; set; }
        public string DateCreated { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public string ParticipantSid { get; set; }
        public string Attributes { get; set; }
        public string Media { get; set; }
    }
}