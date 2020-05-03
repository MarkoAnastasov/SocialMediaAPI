﻿using Microsoft.EntityFrameworkCore;
using ShareITAPI.Interfaces.FriendRequest;
using ShareITAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace ShareITAPI.Repositories
{
    public class FriendRequestsRepository : BaseRepository<FriendRequests>, IFriendRequestsRepository
    {
        private readonly DB_A57889_shareITContext _context = new DB_A57889_shareITContext();

        public FriendRequestsRepository(DB_A57889_shareITContext context) : base(context)
        {

        }

        public List<FriendRequests> GetAllInclude()
        {
            return _context.FriendRequests
                             .Include(x => x.FromUser)
                             .ToList();
        }
    }
}