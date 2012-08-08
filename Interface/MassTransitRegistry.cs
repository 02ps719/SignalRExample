using MassTransit;
using StructureMap.Configuration.DSL;

namespace Interface
{
    public class MassTransitRegistry : Registry
    {
        public MassTransitRegistry()
        {

            For<IServiceBus>().Singleton().Use(x => ServiceBusFactory.New(sbc =>
                {
                    sbc.UseMsmq();
                    sbc.VerifyMsmqConfiguration();
                    sbc.UseMulticastSubscriptionClient();
                    sbc.ReceiveFrom("msmq://localhost/test_queue_interface");
                })
            );
        }
    }
}