using Chat.Business;
using Chat.Business.Interfaces;
using Chat.Contracts;
using Chat.Data;
using Chat.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Chat.Tests.Integrations
{
    public class RoomTests : TestBase
    {
        private readonly IRoomHandler _handler;

        public RoomTests()
        {
            _handler = new RoomHandler(new RoomRepository(Context), new UserRepository(Context), HubContext);
        }

        [Fact]
        public async Task CreateRoom_HappyPath()
        {
            var dto = new CreateRoomDTO
            {
                UserIds = new System.Guid[] { StaticData.TestUserId }
            };
            var room = await _handler.Create(dto, CancellationToken.None);

            var dataFromDb = await Context.Rooms.ToListAsync();
            Assert.AreEqual(2, dataFromDb.Count);

            await DeleteDatabase();
        }
    }
}
