﻿using System;
using System.Net.Sockets;
using System.Threading;

namespace RetroFront.Agent.Server
{
  public class AgentServer
  {
    private readonly NetworkUtils _networkUtils;
    private readonly ClientHandler _clientHandler;
    private readonly uint _portToListenOn;

    private TcpListener _listener;
    private bool _serverUp;
    private Thread _loopThread;

    public AgentServer(
      NetworkUtils networkUtils,
      ClientHandler clientHandler,
      uint portToListenOn
    )
    {
      _networkUtils = networkUtils;
      _clientHandler = clientHandler;
      _portToListenOn = portToListenOn;
    }

    public void Start()
    {
      _listener = new TcpListener(
        _networkUtils.GetLocalEthernetIPv4Address(),
        (int)_portToListenOn
      );

      _listener.Start();
      _serverUp = true;

      _loopThread = new Thread(ServerLoop);
      _loopThread.Start();
    }

    public void Stop()
    {
      _serverUp = false;

      if (_loopThread is null)
      {
        return;
      }

      _loopThread.Join(TimeSpan.FromSeconds(5));
      _loopThread = null;
    }

    private void ServerLoop()
    {
      while (_serverUp)
      {
        try
        {
          _clientHandler.AcceptRequest(_listener);
        }
        catch (Exception ex)
        {
          Console.Error.WriteLine(
            string.Format("Error handling agent server request: {0}", ex.Message)
          );
        }
      }

      _listener.Stop();
      _listener = null;
    }
  }
}
