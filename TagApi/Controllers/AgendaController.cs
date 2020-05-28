using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using TagApi.Domain;

namespace TagApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private ILogger<AgendaController> _logger;

        public AgendaController(ILogger<AgendaController> logger)
        {
            _logger = logger;

        }

        public IActionResult InsertAgenda(Agenda agenda)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "agendaQueue",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    string message = JsonSerializer.Serialize(agenda);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "agendaQueue",
                                         basicProperties: null,
                                         body: body);

                }

                return Accepted(agenda);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro", ex);

                return new StatusCodeResult(500);
            }



        }



    }
}