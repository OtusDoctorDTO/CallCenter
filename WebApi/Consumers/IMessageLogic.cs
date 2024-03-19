using System.Threading.Tasks;

namespace WebApi.Consumers
{
    public interface IMessageLogic
    {
        Task SomeMethod(string message);
    }
}
