using System.Drawing;

namespace RetroFront.Agent.Extensions
{
  public static class FontExtensions
  {
    public static Font CloneWithNewSize(this Font font, float newSize)
    {
      return new Font(font.FontFamily, (float)newSize, font.Style);
    }

    public static Font CloneWithNewSize(this Font font, double newSize)
    {
      return CloneWithNewSize(font, (float)newSize);
    }
  }
}
