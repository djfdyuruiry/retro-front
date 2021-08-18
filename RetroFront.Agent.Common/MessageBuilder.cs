using System.Collections.Generic;
using System.IO;

using RetroFront.Agent.Common.Extensions;

namespace RetroFront.Agent.Common
{
  public class MessageBuilder
  {
    public Message Parse(StreamReader reader)
    {
      return new Message
      {
        RawData = reader.ReadAllAvailableLines()
      };
    }

    public Message BuildError(string message)
    {
      return new Message
      {
        RawData = new List<string>
        {
          Responses.Error,
          message
        }
      };
    }

    public Message Build(string messageType)
    {
      return Build(new string[] { messageType });
    }

    public Message Build(string messageType, string[] extraLines)
    {
      var list = new List<string>
      {
        messageType
      };
      list.AddRange(extraLines);

      return Build(list.ToArray());
    }

    public Message Build(string messageType, string messageData)
    {
      return Build(new string[] { messageType, messageData });
    }

    public Message Build(string messageType, string messageData, string[] extraLines)
    {
      var list = new List<string>
        {
          messageType,
          messageData
        };
      list.AddRange(extraLines);

      return Build(list.ToArray());
    }

    public Message Build(params string[] lines)
    {
      return new Message
      {
        RawData = new List<string>(lines)
      };
    }
  }
}
