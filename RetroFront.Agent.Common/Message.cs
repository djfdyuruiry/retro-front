using System;
using System.Collections.Generic;

using RetroFront.Agent.Common.Extensions;

namespace RetroFront.Agent.Common
{
    public class Message
    {
        public List<string> RawData { get; set; }

        public string MessageType
        {
            get
            {
                return RawData.GetOrDefault(0, string.Empty);
            }
        }

        public string MessageData
        {
            get
            {
                return RawData.GetOrDefault(1, string.Empty);
            }
        }

        public bool Is(string messageType)
        {
            if (messageType is null)
            {
                return false;
            }

            return MessageType.Equals(messageType, StringComparison.OrdinalIgnoreCase);
        }
    }
}
