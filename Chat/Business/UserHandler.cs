using Chat.Business.Interfaces;
using Chat.Contracts;
using Chat.Contracts.SocketMessages;
using Chat.Data.Repositories.Interfaces;
using Chat.Hubs;
using Chat.Repository.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.Business
{
    public class UserHandler : IUserHandler
    {
        private readonly IUserRepository _repository;
        private readonly IRoomRepository _roomRepository;
        private readonly IHubContext<MessageHub> _hubContext;

        public UserHandler(IUserRepository repository, IRoomRepository roomRepository, IHubContext<MessageHub> hubContext)
        {
            _repository = repository;
            _roomRepository = roomRepository;
            _hubContext = hubContext;
        }

        public async Task<User> Login(LoginDTO dto)
        {
            var user = await _repository.GetByNickName(dto.Nickname);
            if (user == null)
            {
                var publicRoom = await _roomRepository.Get(new Guid("B7C83C21-09F2-46C2-9CB1-461AEA2565D4"));
                user = await _repository.Create(new User
                {
                    NickName = dto.Nickname,
                    Id = Guid.NewGuid(),
                    Rooms = new List<Room> { publicRoom } 
                });

                await _hubContext.Clients.Group(publicRoom.RoomId.ToString()).SendAsync("UserJoined", new UserJoinedDTO
                {
                    User = new User { Id = user.Id, NickName = user.NickName },
                    RoomId = publicRoom.RoomId
                });
            }

            return user;
        }
    }
}
