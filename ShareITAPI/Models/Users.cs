using System;
using System.Collections.Generic;

namespace ShareITAPI.Models
{
    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comments>();
            FriendRequestsFromUser = new HashSet<FriendRequests>();
            FriendRequestsUser = new HashSet<FriendRequests>();
            FriendsFriend = new HashSet<Friends>();
            FriendsUser = new HashSet<Friends>();
            Likes = new HashSet<Likes>();
            MessagesFromUser = new HashSet<Messages>();
            MessagesToUser = new HashSet<Messages>();
            NotificationsFromUsed = new HashSet<Notifications>();
            NotificationsUser = new HashSet<Notifications>();
            Posts = new HashSet<Posts>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public bool IsPrivate { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string AccessToken { get; set; }
        public string Password { get; set; }
        public bool IsOnline { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<FriendRequests> FriendRequestsFromUser { get; set; }
        public virtual ICollection<FriendRequests> FriendRequestsUser { get; set; }
        public virtual ICollection<Friends> FriendsFriend { get; set; }
        public virtual ICollection<Friends> FriendsUser { get; set; }
        public virtual ICollection<Likes> Likes { get; set; }
        public virtual ICollection<Messages> MessagesFromUser { get; set; }
        public virtual ICollection<Messages> MessagesToUser { get; set; }
        public virtual ICollection<Notifications> NotificationsFromUsed { get; set; }
        public virtual ICollection<Notifications> NotificationsUser { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
    }
}
