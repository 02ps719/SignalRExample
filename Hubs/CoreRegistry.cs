using StructureMap.Configuration.DSL;

namespace Core
{
    public class CoreRegistry : Registry
    {
        public CoreRegistry()
        {
            Scan(x =>
            {
                x.TheCallingAssembly();
                x.ConnectImplementationsToTypesClosing(typeof (INotifyClients<>));
            });
        }
    }
}