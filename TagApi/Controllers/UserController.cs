using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using TagApi.Domain;
using TagApi.Repository;

namespace TagApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       // private ILogger<UserController> _logger;

        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
       
/*
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;

        }
        */
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userRepository.findAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var user = _userRepository.findById(id);
            if (user == null) { return NotFound(); }
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if (user == null) { return BadRequest(); }
            return new ObjectResult(_userRepository.Create(user));
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody]User user)
        {
            if (user == null) { return BadRequest(); }
            return new ObjectResult(_userRepository.Update(user));
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            _userRepository.Delete(id);
            return NoContent();
        }

        /*
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



                }*/
    }
}