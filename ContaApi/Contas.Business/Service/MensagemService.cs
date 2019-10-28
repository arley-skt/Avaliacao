using Contas.Business.Dto;
using Contas.Business.Interface;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contas.Business.Service
{
    public class MensagemService: IMensagemService
    {

        public void Enviar(string Msg)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "ContasService",

                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                        );

                    var Body = Encoding.UTF8.GetBytes(Msg);

                    channel.BasicPublish(
                        exchange:"",
                        routingKey:"ContasService",
                        basicProperties: null,
                        body: Body
                        );

                }
            }
        }

        public List<LancamentoDto> ConsumirMensagem()
        {
            var body="";
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "ContasService",

                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                        );

                    var consome = new EventingBasicConsumer(channel);

                    consome.Received += (model, ea) =>
                    {
                        var msg = ea.Body;
                        body = Encoding.UTF8.GetString(msg);
                        
                    };

                    channel.BasicConsume(                        
                        queue: "ContasService",
                        autoAck:true,
                        consumer: consome
                        );

                }
            }

            var lista = JsonConvert.DeserializeObject<List<LancamentoDto>>(body);

            return lista;
        }
    }
}
