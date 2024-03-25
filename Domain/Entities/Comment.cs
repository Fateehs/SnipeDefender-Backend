using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comment : BaseEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Reputation { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
        public int PlayerId { get; set; }

        public string? UserName { get; set; }
        public string? UserSteamPicture {  get; set; }  
    }
}
