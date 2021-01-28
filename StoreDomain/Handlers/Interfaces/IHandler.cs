using StoreDomain.Commands.Interfaces;

namespace StoreDomain.Handlers.Interfaces
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}