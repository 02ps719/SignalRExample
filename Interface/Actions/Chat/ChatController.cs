using Core;
using Core.Hubs;
using FubuMVC.WebForms;

namespace Interface.Actions.Chat
{
    public class ChatController
    {
        private readonly INotifyClients<ChatMessage> _notifyService;

        public ChatController(INotifyClients<ChatMessage> notifyService)
        {
            _notifyService = notifyService;
        }

        public ChatMessage GET()
        {
            return new ChatMessage();
        }

        public void POST(ChatMessage model)
        {
            _notifyService.Notify(model);
        }
    }
    
    public class Chat : FubuPage<ChatMessage> { }
}