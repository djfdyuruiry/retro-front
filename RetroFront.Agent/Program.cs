using System;
using System.Windows.Forms;

using RetroFront.Agent.Common;
using RetroFront.Agent.Screens;
using RetroFront.Agent.Server;

namespace RetroFront.Agent
{
  public static class Program
  {
    [STAThread]
    public static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      Application.Run(
        new AgentSplashScreen(
          new AgentServer(
            new NetworkUtils(),
            new ClientHandler(
              new MessageBuilder()
            ),
            7777
          ),
          new NetworkUtils()
        )
      );
    }
  }
}
