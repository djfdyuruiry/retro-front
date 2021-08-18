using RetroFront.Client.Utils.Interfaces;
using RetroFront.Client.ViewModels.Interfaces;

namespace RetroFront.Client.ViewModels.Screens
{
  public class FirstLaunchScreenViewModel : IFirstLaunchScreenViewModel
  {
    private readonly IApplicationManager _appManager;

    public FirstLaunchScreenViewModel(IApplicationManager appManager) => 
      _appManager = appManager;
  }
}
