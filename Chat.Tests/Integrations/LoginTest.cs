using Chat.Business;
using Chat.Business.Interfaces;
using Chat.Contracts;
using Chat.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Chat.Tests.Integrations
{
    public class LoginTest : TestBase
    {
        private readonly IUserHandler _handler;

        public LoginTest()
        {
            _handler = new UserHandler(new UserRepository(Context), new RoomRepository(Context), HubContext);
        }

        [Fact]
        public async Task Login_HappyPath()
        {
            var dto = new LoginDTO { Nickname = "Test" };
            var user = await _handler.Login(dto, CancellationToken.None);
            Assert.IsNotNull(user);

            await DeleteDatabase();
        }
    }
}
