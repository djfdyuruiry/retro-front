using System.Collections.Generic;
using System.IO;

namespace RetroFront.Agent.Common.Extensions
{
  public static class StreamReaderExtensions
  {
    public static List<string> ReadAllAvailableLines(this StreamReader reader)
    {
      var lines = new List<string>();

      while (reader.Peek() > 0)
      {
        var data = reader.ReadLine();

        if (data != null)
        {
          lines.Add(data);
        }
      }

      return lines;
    }
  }
}
