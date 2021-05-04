using Chat.Business;
using Chat.Business.Interfaces;
using Chat.Contracts;
using Chat.Data;
using Chat.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Chat.Tests.Integrations
{
    public class MessageTests : TestBase
    {
        private readonly IMessageHandler _handler;

        public MessageTests()
        {
            _handler = new MessageHandler(new MessageRepository(Context), HubContext);
        }

        [Fact]
        public async Task MessageCreate_HappyPath()
        {
            var dto = new CreateMessageDTO
            {
                Content = "Hello",
                RoomId = StaticData.PublicRoomId,
                UserId = StaticData.TestUserId
            };
            var message = await _handler.Create(dto, CancellationToken.None);
            Assert.IsNotNull(message);
            var dataFromDb = await Context.Messages.SingleAsync(x => x.Id == message.Id);
            Assert.AreEqual(dataFromDb.Content, dto.Content);

            await DeleteDatabase();
        }

        [Fact]
        public async Task MessageDelete_HappyPath()
        {
            var dto = new CreateMessageDTO
            {
                Content = "Hello",
                RoomId = StaticData.PublicRoomId,
                UserId = StaticData.TestUserId
            };
            var message = await _handler.Create(dto, CancellationToken.None);
            await _handler.Delete(new Guid[] { message.Id }, false, CancellationToken.None);

            var dataFromDb = await Context.Messages.ToListAsync();
            Assert.AreEqual(dataFromDb.Count, 0);

            await DeleteDatabase();
        }

        [Fact]
        public async Task MessageUpdate_HappyPath()
        {
            var dto = new CreateMessageDTO
            {
                Content = "Hello",
                RoomId = StaticData.PublicRoomId,
                UserId = StaticData.TestUserId
            };
            var message = await _handler.Create(dto, CancellationToken.None);
            var updateDto = new UpdateMessageDTO
            {
                Id = message.Id,
                Content = "Hello world!",
            };

            await _handler.Update(updateDto, CancellationToken.None);

            var dataFromDb = await Context.Messages.SingleAsync(x => x.Id == message.Id);
            Assert.AreEqual(dataFromDb.Content, updateDto.Content);

            await DeleteDatabase();
        }

        [Fact]
        public async Task MessageGet()
        {
            var dto = new CreateMessageDTO
            {
                Content = "Hello",
                RoomId = StaticData.PublicRoomId,
                UserId = StaticData.TestUserId
            };
            var message = await _handler.Create(dto, CancellationToken.None);

            var messages = await _handler.GetAllByRoom(message.RoomId, CancellationToken.None);
            Assert.AreEqual(1, messages.Count);

            messages = await _handler.Get(message.RoomId, DateTime.Now, 20, CancellationToken.None);
            Assert.AreEqual(1, messages.Count);

            await DeleteDatabase();
        }
    }
}
