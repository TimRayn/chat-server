using Chat.Contracts;
using Chat.Repository.Models;
using System.Collections.Generic;

namespace Chat.Mappers
{
    public static class RoomMappers
    {
        public static RoomDTO ToDTO(this Room entity, List<UserDTO> users)
        {
            return new RoomDTO
            {
                Name = entity.Name,
                RoomId = entity.RoomId,
                Users = users,
            };
        }
    }
}
