using Chat.Business.Interfaces;
using Chat.Contracts;
using Chat.Contracts.SocketMessages;
using Chat.Data;
using Chat.Data.Repositories.Interfaces;
using Chat.Hubs;
using Chat.Mappers;
using Chat.Repository.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public async Task<UserDTO> Login(LoginDTO dto, CancellationToken cancel)
        {
            var user = await _repository.GetByNickName(dto.Nickname, cancel);
            if (user == null)
            {
                var publicRoom = await _roomRepository.Get(StaticData.PublicRoomId, cancel);
                user = await _repository.Create(dto.ToEntity(new List<Room> { publicRoom }), cancel);

                await _hubContext.Clients.Group(publicRoom.RoomId.ToString()).SendAsync("UserJoined", new UserJoinedDTO
                {
                    User = new UserDTO { Id = user.Id, NickName = user.NickName },
                    RoomId = publicRoom.RoomId
                });
            }

            return user.ToDTO(user.Rooms
                .Select(x => x.ToDTO(x.Users
                .Select(u => u.ToDTO(new List<RoomDTO>())).ToList())).ToList());
        }
    }
}
