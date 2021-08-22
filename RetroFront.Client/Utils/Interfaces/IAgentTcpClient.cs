using System.Collections.Generic;
using System.Threading.Tasks;
using RetroFront.Agent.Common;

namespace RetroFront.Client.Utils.Interfaces
{
  public interface IAgentTcpClient
  {
    Task<bool> IsReachable();

    Task<Message> StartProgram(string path, IEnumerable<string> args = null);
  }
}
