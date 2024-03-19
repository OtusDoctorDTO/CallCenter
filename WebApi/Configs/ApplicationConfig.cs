namespace WebApi.Configs
{
    public class ApplicationConfig : IApplicationConfig
    {
        public RabbitMqConfig BusConfig { get; set; } = default!;
    }
}
