using Chat.Contracts;
using Chat.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Mappers
{
    public static class UserMappers
    {
        public static UserDTO ToDTO(this User entity, List<RoomDTO> rooms)
        {
            return new UserDTO
            {
                Id = entity.Id,
                NickName = entity.NickName,
                Rooms = rooms,
            };
        }

        public static User ToEntity(this LoginDTO dto, List<Room> rooms)
        {
            return new User
            {
                NickName = dto.Nickname,
                Id = Guid.NewGuid(),
                Rooms = rooms,
            };
        }
    }
}
