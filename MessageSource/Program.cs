using System;
using MassTransit;
using Messages;
using Topshelf;

namespace MessageSource
{
    public class ChatService
    {
        public void Start()
        {
            Console.WriteLine("Starting messages source.");
            Bus.Initialize(sbc =>
            {
                sbc.UseMsmq();
                sbc.VerifyMsmqConfiguration();
                sbc.UseMulticastSubscriptionClient();
                sbc.ReceiveFrom("msmq://localhost/test_queue");
                sbc.Subscribe(subs => subs.Handler<ChatMessage>(msg => Console.WriteLine(msg.subject)));
            });
            Console.WriteLine("Message Source Started.");
        }

        public void Stop()
        {
            Console.WriteLine("Message Source Exiting.");
            Bus.Instance.Dispose();
        }
    }
    
    public class Program
    {
        public static void Main()
        {
            HostFactory.Run(x =>                                 
            {
                x.Service<ChatService>(s =>                        
                {
                    s.SetServiceName("tc");                      
                    s.ConstructUsing(c => new ChatService());   
                    s.WhenStarted(tc => tc.Start());             
                    s.WhenStopped(tc => tc.Stop());              
                });
                x.RunAsLocalSystem();                            

                x.SetDescription("Sample Topshelf Host");        
                x.SetDisplayName("Stuff");                       
                x.SetServiceName("stuff");                       
            });   
        }
    }
}
