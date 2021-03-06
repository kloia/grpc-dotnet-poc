using Grpc.Net.Client;
using GrpcService;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new Greeter.GreeterClient(channel);
            HelloReply response = new HelloReply();
            response = await client.SayHelloAsync(
                  new HelloRequest
                  {
                      Name = ".NET 5 - grpcClient "
                  });
            Console.WriteLine("From Server: " + response.Message);
            Console.ReadKey();
        }
    }
}
