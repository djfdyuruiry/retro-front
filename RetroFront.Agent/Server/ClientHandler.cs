using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Threading;

using RetroFront.Agent.Common;
using RetroFront.Agent.Extensions;

namespace RetroFront.Agent.Server
{
  public class ClientHandler
  {
    private readonly MessageBuilder _messageBuilder;

    public ClientHandler(MessageBuilder messageBuilder)
    {
      _messageBuilder = messageBuilder;
    }

    public void AcceptRequest(TcpListener listener)
    {
      using (var client = listener.AcceptTcpClient())
      {
        using (var clientStream = client.GetStream())
        {
          using (var reader = new StreamReader(clientStream))
          {
            using (var writer = new StreamWriter(clientStream))
            {
              var response = HandleRequest(reader);

              response.RawData.ForEach(writer.WriteLine);
            }
          }
        }
      }
    }

    private Message HandleRequest(StreamReader reader)
    {
      var message = _messageBuilder.Parse(reader);

      if (message.Is(MessageTypes.StartProcess))
      {
        return HandleStartProcess(message);
      }

      return _messageBuilder.BuildError(
        string.Format("Command not recognised: {0}", message.MessageType)
      );
    }

    private Message HandleStartProcess(Message message)
    {
      var processPath = message.MessageData;

      if (string.IsNullOrEmpty(processPath))
      {
        return _messageBuilder.BuildError(
          string.Format("Process path was blank")
        );
      }

      if (!File.Exists(processPath))
      {
        return _messageBuilder.BuildError(
          string.Format("Process path does not exist: {0}", processPath)
        );
      }

      var args = message.RawData.GetOrDefault(2, string.Empty);

      return StartProcess(processPath, args);
    }

    private Message StartProcess(string processPath, string args)
    {
      try
      {
        var process = Process.Start(
          new ProcessStartInfo
          {
            FileName = processPath,
            Arguments = args
          }
        );

        Thread.Sleep(5000);

        if (process.HasExited)
        {
          return _messageBuilder.BuildError(
          string.Format(
            "Process @ path '{0}' exited shortly after it started, exit code: {1}",
            processPath,
            process.ExitCode
          )
          );
        }

        return _messageBuilder.Build(Responses.Ok);
      }
      catch (Exception ex)
      {
        return _messageBuilder.BuildError(
          string.Format(
            "Failed to start process @ path '{0}': {1}",
            processPath,
            ex.Message
          )
        );
      }
    }
  }
}
