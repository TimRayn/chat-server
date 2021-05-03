﻿using Chat.Contracts.SocketMessages;
using Chat.Repository.Models;
using System.Linq;

namespace Chat.Mappers
{
    public static class SocketMessageMappers
    {
        public static RoomCreatedDTO ToDTO(this Room model)
        {
            return new RoomCreatedDTO
            {
                Name = model.Name,
                RoomId = model.RoomId,
                Users = model.Users.Select(x => new User { Id = x.Id, NickName = x.NickName }).ToList()
            };
        }
    }
}
