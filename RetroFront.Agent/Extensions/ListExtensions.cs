using System.Collections.Generic;

namespace RetroFront.Agent.Extensions
{
  public static class ListExtensions
  {
    public static T GetOrDefault<T>(this List<T> list, int index, T defaultValue)
    {
      return list.Count > index
        ? list[index]
        : defaultValue;
    }
  }
}
