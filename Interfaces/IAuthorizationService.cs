using System.Collections.Generic;
using System.Threading.Tasks;

namespace FenixAlliance.SDK.Interfaces
{
    public interface IAuthorizationHelpers
    {
        Task AuthorizeClient();
        Task AuthorizeClient(List<string> RequestedScopes);
    }
}
