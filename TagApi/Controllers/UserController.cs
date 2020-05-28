using System;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using TagApi.Domain;

namespace TagApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILogger<UserController> _logger;

       
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;

        }
        
       
        
                public IActionResult InsertUser(User user)
                {
                    try
                    {
                        var factory = new ConnectionFactory() { HostName = "localhost" };
                        using (var connection = factory.CreateConnection())
                        using (var channel = connection.CreateModel())
                        {
                            channel.QueueDeclare(queue: "userQueue",
                                                 durable: false,
                                                 exclusive: false,
                                                 autoDelete: false,
                                                 arguments: null);

                            string message = JsonSerializer.Serialize(user);
                            var body = Encoding.UTF8.GetBytes(message);

                            channel.BasicPublish(exchange: "",
                                                 routingKey: "userQueue",
                                                 basicProperties: null,
                                                 body: body);

                        }

                        return Accepted(user);
                    }catch(Exception ex)
                    {
                        _logger.LogError("Erro", ex);

                        return new StatusCodeResult(500);
                    }



                }
    }
}