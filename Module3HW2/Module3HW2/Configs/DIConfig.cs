using Autofac;

namespace Module3HW2
{
    public class DIConfig
    {
        public IContainer Build()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Starter>();
            builder.RegisterType<AlphabetConfigurationService>().As<IAlphabetConfigurationService>();

            var container = builder.Build();

            return container;
        }
    }
}
