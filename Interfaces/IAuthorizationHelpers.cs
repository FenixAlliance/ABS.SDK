using System.Collections.Generic;
using System.Threading.Tasks;

namespace FenixAlliance.Tools.Interfaces
{
    public interface IAuthorizationHelpers
    {
        Task AuthorizeClient();
        Task AuthorizeClient(List<string> RequestedScopes);
    }
}
