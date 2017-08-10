using Grpc.Core;
using System;
using Test.Grpc.Messages;

namespace GrpcLib
{
    class Service : FunctionRpc.FunctionRpcBase
    {

    }

    public class GrpcServer
    {
        public GrpcServer()
        {
            var service = new Service();
            var x = new Server
            {
                Services = { FunctionRpc.BindService(service)},
                Ports = { new ServerPort("127.0.0.1", ServerPort.PickUnused, ServerCredentials.Insecure) }
            };

            x.Start();
        }
    }
}
