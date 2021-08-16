using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace RetroFront.Agent
{
  public partial class AgentSplashScreen : Form
  {
    public AgentSplashScreen()
    {
      InitializeComponent();
    }

    private void AgentSplashScreen_Load(object sender, EventArgs e)
    {
      GoFullscreen();

      InitHeader();
      InitBody();
    }

    private void GoFullscreen()
    {
      WindowState = FormWindowState.Normal;
      FormBorderStyle = FormBorderStyle.None;
      WindowState = FormWindowState.Maximized;
    }

    private void InitHeader()
    {
      _banner.Location = new Point(_banner.Location.X, Height / 5);
      _banner.Width = Width;
      _banner.Height = Height / 7;

      var headerFontSize = Width * 0.05;

      _header.Font = new Font(_header.Font.FontFamily, (float)headerFontSize, _header.Font.Style);
    }

    private void InitBody()
    {
      _ipAddress.Location = new Point(_ipAddress.Location.X, (int)(Height * 0.4));
      _prompt.Location = new Point(_prompt.Location.X, (int)(Height * 0.65));

      var paragraphFontSize = Width * 0.03;

      _ipAddress.Font = new Font(_ipAddress.Font.FontFamily, (float)paragraphFontSize, _ipAddress.Font.Style);
      _prompt.Font = new Font(_header.Font.FontFamily, (float)paragraphFontSize, _prompt.Font.Style);

      SetIpAddress();
    }

    private void SetIpAddress()
    {
      _ipAddress.Text = string.Format(
        "{0} {1}",
        _ipAddress.Text,
        NetworkUtils.GetLocalIPv4(NetworkInterfaceType.Ethernet)
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
