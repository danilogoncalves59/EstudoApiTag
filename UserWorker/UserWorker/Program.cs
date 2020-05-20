using System;
using System.Text;
using Dapper;
using Npgsql;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using UserWorker.Domain;

namespace UserWorker
{
    class Program
    {
        static void Main(string[] args)
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

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    try
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body.ToArray());
                        var user = System.Text.Json.JsonSerializer.Deserialize<User>(message);
                        
                        using (var connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=postgres;Database=tagrepository"))
                        {
                            connection.Open();
                            connection.Execute($"Insert into _User (firstname,lastname,cnpj,email,senha) values ('{user.firstName}','{user.lastName}','{user.cnpj}','{user.email}','{user.senha}')");
                           
                        }
                        
                        Console.WriteLine($"Usuario {user.firstName} foi cadastrado!");

                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex);
                        channel.BasicNack(ea.DeliveryTag, false, true);
                    }
                };


                channel.BasicConsume(queue: "userQueue",
                                     autoAck: false,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
