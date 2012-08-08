using System.Collections.Generic;
using SignalR;
using SignalR.Hubs;

namespace Core.Hubs
{
    public class ChatMessage
    {
        public string subject { get; set; }
    }

    public class ChatNotifier : INotifyClients<ChatMessage>
    {
        private IHubContext _context;

        public ChatNotifier()
        {
            _context = GlobalHost.ConnectionManager.GetHubContext<Chat>();
        }

        public void Notify(ChatMessage entity)
        {
            _context.Clients.taskAdded(entity.subject);
        }
    }

    public class Chat : Hub
    {
        private static IList<string> tasks = new List<string>();

        public void AddTask(string subject)
        {
            tasks.Add(subject);
            Clients.taskAdded(subject);

        }
    }
}