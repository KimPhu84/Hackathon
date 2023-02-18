using BodyBuilderApp.Models;
using System.Threading.Tasks;

namespace BodyBuilderApp.Modules.CustomerModule.Interface
{
    public interface ITokenHandler
    {
      Task<string>  CreateTokenAsync(Customer customer);
    }
}
