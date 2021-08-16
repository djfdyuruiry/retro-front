using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace RetroFront.Agent
{
  public static class NetworkUtils
  {
    public static string GetLocalIPv4(NetworkInterfaceType type)
    {
      foreach (var netInterface in NetworkInterface.GetAllNetworkInterfaces())
      {
        if (netInterface.NetworkInterfaceType != type)
        {
          continue;
        }

        foreach (var ip in netInterface.GetIPProperties().UnicastAddresses)
        {
          if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
          {
            return ip.Address.ToString();
          }
        }
      }

      return string.Empty;
    }
  }
}
