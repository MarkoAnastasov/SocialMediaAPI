using System;

namespace ShareITAPI.ModelsDTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public bool IsPrivate { get; set; }
        public byte[] ProfilePicture { get; set; }
        public bool IsOnline { get; set; }
    }
}
