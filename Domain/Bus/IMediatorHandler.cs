using System.Threading.Tasks;
using Domain.Commands;
using Domain.Events;
using Domain.Notifications;

namespace Domain.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
        //Task Notification<T>(T notification) where T : DomainNotification;
    }
}
