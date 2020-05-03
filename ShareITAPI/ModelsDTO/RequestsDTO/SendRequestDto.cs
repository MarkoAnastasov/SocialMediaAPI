using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.ModelsDTO.RequestsDTO
{
    public class SendRequestDto
    {
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
    }
}
