using RetroFront.Client.Utils.Interfaces;
using RetroFront.Client.ViewModels.Interfaces;

using System.Net;

namespace RetroFront.Client.ViewModels.Screens
{
  public class FirstLaunchScreenViewModel : IFirstLaunchScreenViewModel
  {
    private readonly IApplicationManager _appManager;
    private readonly IAgentEndpointProvider _agentEndpointProvider;
    private readonly IAgentTcpClient _agentClient;

    public FirstLaunchScreenViewModel(
      IApplicationManager appManager,
      IAgentEndpointProvider agentEndpointProvider,
      IAgentTcpClient agentClient
    )
    {
      _appManager = appManager;
      _agentEndpointProvider = agentEndpointProvider;
      _agentClient = agentClient;

      _agentEndpointProvider.AgentEndpoint = new IPEndPoint(
        IPAddress.Parse("192.168.0.20"),
        7777
      );

      _agentClient.StartProgram(@"C:\Windows\system32\notepad.exe").Wait();
    }
  }
}
