using Chat.Hubs;
using Chat.Repository;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Threading.Tasks;

namespace Chat.Tests.Integrations
{
    public class TestBase
    {
        public ChatDbContext Context { get; set; }
        public IHubContext<MessageHub> HubContext { get; set; }

        public TestBase()
        {
            Mock<IClientProxy> mockClientProxy = new Mock<IClientProxy>();
            Mock<IHubClients> mockClients = new Mock<IHubClients>();
            Mock<IHubContext<MessageHub>> mockHubContext = new Mock<IHubContext<MessageHub>>();
            Mock<IGroupManager> mockGroups = new Mock<IGroupManager>();
            mockHubContext.Setup(groups => groups.Clients).Returns(mockClients.Object);
            mockClients.Setup(clients => clients.Group(It.IsAny<string>())).Returns(mockClientProxy.Object);
            HubContext = mockHubContext.Object;

            BuildDataBase();
        }

        public void BuildDataBase()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<ChatDbContext>();

            builder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=chat_db_{Guid.NewGuid()};Trusted_Connection=True;MultipleActiveResultSets=true")
                    .UseInternalServiceProvider(serviceProvider);

            Context = new ChatDbContext(builder.Options);
            Context.Database.Migrate();
        }

        public Task DeleteDatabase()
        {
            return Context.Database.EnsureDeletedAsync();
        }
    }
}
