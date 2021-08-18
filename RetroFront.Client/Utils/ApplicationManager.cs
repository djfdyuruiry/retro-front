using System.Windows;

using RetroFront.Client.Utils.Interfaces;

namespace RetroFront.Client.Utils
{
  public class ApplicationManager : IApplicationManager
  {
    public void Shutdown() =>
      Application.Current.Shutdown();
  }
}
