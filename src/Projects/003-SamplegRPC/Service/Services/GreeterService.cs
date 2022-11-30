using Grpc.Core;
using CSD.gRPC.Greeting.Service;

namespace Service.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> m_logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            m_logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {                
                Message = "Hello " + request.Name
            });
        }

        public override Task GenerateNumbers(Info request, IServerStreamWriter<Result> responseStream, ServerCallContext context)
        {
            return base.GenerateNumbers(request, responseStream, context);
        }
    }
}