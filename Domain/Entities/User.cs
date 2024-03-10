using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public required string SteamID { get; set; }
        public required string UserName { get; set; }
        public required string Password {  get; set; }
        public string? Twitch { get; set; }
        public string? Hours { get; set; }
        public string? Discord { get; set; }
        public string? SteamPicture { get; set; }
        public int Reputation { get; set; }
    }
}
