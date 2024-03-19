namespace WebApi.Configs
{
    public interface IApplicationConfig
    {
        RabbitMqConfig BusConfig { get; set; }
    }
}
