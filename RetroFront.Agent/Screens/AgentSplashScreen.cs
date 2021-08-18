using System;
using System.Windows.Forms;

using RetroFront.Agent.Extensions;
using RetroFront.Agent.Server;

namespace RetroFront.Agent.Screens
{
  public partial class AgentSplashScreen : Form
  {
    private readonly AgentServer _agentServer;
    private readonly NetworkUtils _networkUtils;

    public AgentSplashScreen(AgentServer agentServer, NetworkUtils networkUtils)
    {
      InitializeComponent();

      _agentServer = agentServer;
      _networkUtils = networkUtils;
    }

    private void AgentSplashScreen_Load(object sender, EventArgs e)
    {
      GoFullscreen();

      InitHeader();
      InitBody();

      _agentServer.Start();
    }

    private void GoFullscreen()
    {
      WindowState = FormWindowState.Normal;
      FormBorderStyle = FormBorderStyle.None;
      WindowState = FormWindowState.Maximized;
    }

    private void InitHeader()
    {
      _banner.Location = _banner.Location.CloneWithNewY(Height / 5);
      _banner.Width = Width;
      _banner.Height = Height / 7;

      var headerFontSize = Width * 0.05;

      _header.Font = _header.Font.CloneWithNewSize(headerFontSize);
    }

    private void InitBody()
    {
      _ipAddress.Location = _ipAddress.Location.CloneWithNewY(Height * 0.4);
      _prompt.Location = _prompt.Location.CloneWithNewY(Height * 0.65);

      var paragraphFontSize = Width * 0.03;

      _ipAddress.Font = _ipAddress.Font.CloneWithNewSize(paragraphFontSize);
      _prompt.Font = _prompt.Font.CloneWithNewSize(paragraphFontSize);

      SetIpAddress();
    }

    private void SetIpAddress()
    {
      _ipAddress.Text = string.Format(
        "{0} {1}",
        _ipAddress.Text,
        _networkUtils.GetLocalEthernetIPv4Address()
      );
    }

    private void AgentSplashScreen_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Escape)
      {
        Close();
      }
    }
  }
}
