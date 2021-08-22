using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using RetroFront.Agent.Common;
using RetroFront.Client.Utils.Interfaces;

namespace RetroFront.Client.Utils
{
  public class AgentTcpClient : IAgentTcpClient
  {
    private readonly IAgentEndpointProvider _endpointProvider;
    private readonly MessageBuilder _messageBuilder;

    public AgentTcpClient(
      IAgentEndpointProvider endpointProvider,
      MessageBuilder messageBuilder
    )
    {
      _endpointProvider = endpointProvider;
      _messageBuilder = messageBuilder;
    }

    public async Task<bool> IsReachable() =>
      await _endpointProvider.WithEndpointClient(async c =>
        c.Connected
      );

    public async Task<Message> StartProgram(string path, IEnumerable<string> args = null) =>
      await SendMessage(
        MessageTypes.StartProcess,
        path,
        string.Join(" ", args ?? Enumerable.Empty<string>())
      );

    private async Task<Message> SendMessage(string messageType, params string[] data) =>
      await _endpointProvider.WithEndpointClient(async c =>
      {
        using var stream = c.GetStream();
        using var writer = new StreamWriter(stream);

        var message = data is null || data.Length < 1
          ? _messageBuilder.Build(messageType)
          : _messageBuilder.Build(messageType, data);

        await writer.WriteAsync(
          string.Join("\n", message.RawData)
        );

        await writer.FlushAsync();

        using var reader = new StreamReader(stream);

        return _messageBuilder.Parse(reader);
      });
  }
}
