using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

using Caliburn.Micro;

using RetroFront.Client.Utils.Interfaces;
using RetroFront.Client.ViewModels.Interfaces;

namespace RetroFront.Client.ViewModels.Screens
{
  public class FirstLaunchScreenViewModel : PropertyChangedBase, IFirstLaunchScreenViewModel
  {
    private const uint MAX_TCP_PORT = 65535;

    private readonly IApplicationManager _appManager;
    private readonly IAgentEndpointProvider _agentEndpointProvider;
    private readonly IAgentTcpClient _agentClient;

    private string _agentIp;
    private uint _agentPort;
    private string _programPath;

    public string AgentIp
    {
      get => _agentIp;
      set
      {
        _agentIp = value;
        NotifyOfPropertyChange(nameof(AgentIp));
      }
    }

    public uint AgentPort
    {
      get => _agentPort;
      set
      {
        _agentPort = value;
        NotifyOfPropertyChange(nameof(AgentPort));
      }
    }

    public string ProgramPath
    {
      get => _programPath;
      set
      {
        _programPath = value;
        NotifyOfPropertyChange(nameof(ProgramPath));
      }
    }

    public FirstLaunchScreenViewModel(
      IApplicationManager appManager,
      IAgentEndpointProvider agentEndpointProvider,
      IAgentTcpClient agentClient
    )
    {
      _appManager = appManager;
      _agentEndpointProvider = agentEndpointProvider;
      _agentClient = agentClient;

      AgentIp = "127.0.0.1";
      AgentPort = 7777;
      ProgramPath = @"C:\Windows\system32\notepad.exe";
    }

    public async Task OpenNotepad(DependencyObject view)
    {
      if (!AgentEndpointIsValid())
      {
        MessageBox.Show(
          Window.GetWindow(view), 
          "Agent endpoint entered is invalid, check IP and port are correct",
          "RetroFront",
          MessageBoxButton.OK, 
          MessageBoxImage.Error
        );

        return;
      }

      if (string.IsNullOrEmpty(ProgramPath))
      {
        MessageBox.Show(
          Window.GetWindow(view),
          "Program path entered is blank",
          "RetroFront",
          MessageBoxButton.OK,
          MessageBoxImage.Error
        );

        return;
      }

      _agentEndpointProvider.AgentEndpoint = new IPEndPoint(
        IPAddress.Parse(AgentIp),
        (int)AgentPort
      );

      await _agentClient.StartProgram(ProgramPath);
    }

    private bool AgentEndpointIsValid() => 
      IPAddress.TryParse(AgentIp, out var _)
      && AgentPort > 0 && AgentPort < MAX_TCP_PORT;
  }
}
