using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace RetroFront.Agent
{
  public class NetworkUtils
  {
    public IPAddress GetLocalIPv4For(
      NetworkInterfaceType type,
      bool ignoreDownInterfaces,
      string preferredInterfaceName = ""
    )
    {
      var interfaces = NetworkInterface.GetAllNetworkInterfaces();

      foreach (var netInterface in interfaces)
      {
        if (
          netInterface.NetworkInterfaceType != type
          || (!ignoreDownInterfaces && netInterface.OperationalStatus != OperationalStatus.Up)
        )
        {
          continue;
        }

        if (netInterface.Name == preferredInterfaceName)
        {
          foreach (var ip in netInterface.GetIPProperties().UnicastAddresses)
          {
            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
            {
              return ip.Address;
            }
          }
        }
      }

      foreach (var netInterface in interfaces)
      {
        if (
          netInterface.NetworkInterfaceType != type
          || (!ignoreDownInterfaces && netInterface.OperationalStatus != OperationalStatus.Up)
        )
        {
          continue;
        }

        foreach (var ip in netInterface.GetIPProperties().UnicastAddresses)
        {
          if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
          {
            return ip.Address;
          }
        }
      }

      return IPAddress.Any;
    }

    public IPAddress GetLocalIPv4For(NetworkInterfaceType type)
    {
      return GetLocalIPv4For(type, false);
    }

    public IPAddress GetLocalEthernetIPv4Address()
    {
      var ip = GetLocalIPv4For(NetworkInterfaceType.Ethernet, false, "Ethernet");

      return ip == IPAddress.Any
        ? GetLocalIPv4For(NetworkInterfaceType.Ethernet, true, "Ethernet")
        : ip;
    }
  }
}
