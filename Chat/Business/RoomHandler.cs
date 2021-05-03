using Chat.Business.Interfaces;
using Chat.Contracts;
using Chat.Data.Repositories.Interfaces;
using Chat.Hubs;
using Chat.Mappers;
using Chat.Repository.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Business
{
    public class RoomHandler : IRoomHandler
    {
        private readonly IRoomRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IHubContext<MessageHub> _hubContext;

        public RoomHandler(IRoomRepository repository, IUserRepository userRepository, IHubContext<MessageHub> hubContext)
        {
            _repository = repository;
            _userRepository = userRepository;
            _hubContext = hubContext;
        }

        public async Task<Room> Create(CreateRoomDTO dto)
        {
            var users = new List<User>();

            foreach (var userId in dto.UserIds)
            {
                var user = await _userRepository.Get(userId);
                if (user == null)
                    throw new Exception("User not found!");
                users.Add(user);
            }

            var model = new Room
            {
                RoomId = Guid.NewGuid(),
                Users = users.ToList()
            };

            await _repository.Create(model);

            foreach (var userId in dto.UserIds)
            {
                await _hubContext.Clients.Group(userId.ToString()).SendAsync("RoomCreated", model.ToDTO());
            }

            return model;
        }
    }
}
