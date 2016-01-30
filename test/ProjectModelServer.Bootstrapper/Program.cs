using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.DotNet.ProjectModel.Server.Tests;
using Microsoft.Extensions.Logging;

namespace ProjectModelServer.Bootstrapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var projectPath = @"C:\code\cli\testapp\DthTestProjects\src\DemoWebApplication";

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddConsole();

            using (var server = new DthTestServer(loggerFactory))
            using (var client = new DthTestClient(server))
            {
                client.Initialize(projectPath);

                var messages = client.DrainAllMessages(TimeSpan.FromHours(1));
            }
        }
    }
}
