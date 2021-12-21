using Grpc.Net.Client;
using GrpcServer;
using Xunit;

namespace RemoteProxy
{
    public class RemoteProxyTest
    {
        [Fact]
        public async Task GreetReturnsResponseAsync()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7212");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });

            Assert.Equal("Hello GreeterClient", reply.Message);
        }
    }
}