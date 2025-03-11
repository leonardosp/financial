using Financial.Cross.Message.Interface;
using Financial.Domain.Clientes.Events;

namespace Financial.ConsignadoHostedService
{
    public class Worker : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger, IMessageBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetSubscribers();
            return;
        }

        private void SetSubscribers()
        {
            _bus.Subscribe<ClienteAdicionadoSolicitaConsignadoEvent>("ClienteAdicionadoSolicitaConsignadoEvent", request =>
                LogAction());
        }

        private void LogAction()
        {
            _logger.LogInformation("Mensagem consumida, consignado solicitado");
        }
    }
}
