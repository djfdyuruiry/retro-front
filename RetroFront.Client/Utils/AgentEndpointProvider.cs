using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using RetroFront.Client.Utils.Interfaces;

namespace RetroFront.Client.Utils
{
  public class AgentEndpointProvider : IAgentEndpointProvider
  {
    public IPEndPoint AgentEndpoint { get; set; }

    public async Task WithEndpointClient(Func<TcpClient, Task> func)
    {
      using var client = await BuildClient();

      try
      {
        await func.Invoke(client);
      }
      finally
      {
        client.Close();
      }
    }

    public async Task<T> WithEndpointClient<T>(Func<TcpClient, Task<T>> func)
    {
      if (func is null)
      {
        throw new ArgumentNullException(nameof(func));
      }

      using var client = await BuildClient();
      T result;

      try
      {
        result = await func.Invoke(client);
      }
      finally
      {
        client.Close();
      }

      return result;
    }

    private async Task<TcpClient> BuildClient()
    {
      if (AgentEndpoint is null)
      {
        throw new InvalidOperationException("AgentEndpoint must be set to connect to an agent");
      }

      var client = new TcpClient();

      await client.ConnectAsync(AgentEndpoint.Address, AgentEndpoint.Port);

      return client;
    }
  }
}
