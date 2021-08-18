using System.Drawing;

namespace RetroFront.Agent.Extensions
{
  public static class PointExtensions
  {
    public static Point CloneWithNewY(this Point point, int newY)
    {
      return new Point(point.X, newY);
    }

    public static Point CloneWithNewY(this Point point, double newY)
    {
      return CloneWithNewY(point, (int)newY);
    }
  }
}
