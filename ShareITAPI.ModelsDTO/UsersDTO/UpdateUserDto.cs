using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.ModelsDTO.UsersDTO
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public bool IsPrivate { get; set; }
        public string ProfilePicture { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfNewPass { get; set; }
    }
}
