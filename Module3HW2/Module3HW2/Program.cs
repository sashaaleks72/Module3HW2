using Autofac;

namespace Module3HW2
{
    public class Program
    {
        private static void Main()
        {
            var config = new DIConfig();
            var container = config.Build();
            var starter = container.Resolve<Starter>();

            starter.Run();
        }
    }
}
