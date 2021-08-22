using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace RetroFront.Client.Utils.Interfaces
{
  public interface IAgentEndpointProvider
  {
    IPEndPoint AgentEndpoint { get; set; }

    Task WithEndpointClient(Func<TcpClient, Task> action);

    Task<T> WithEndpointClient<T>(Func<TcpClient, Task<T>> func);
  }
}
