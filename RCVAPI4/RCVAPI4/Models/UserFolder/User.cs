using System.Diagnostics.CodeAnalysis;

namespace RCVAPI4.Models.UserFolder
{
    public class User
    {
        public Guid Id { get; set; }
        [MaybeNull]
        public string user_name { get; set; }
        [MaybeNull]
        public string user_surname { get; set; }
        [MaybeNull]
        public string user_nickname { get; set; }
        [MaybeNull]
        public string user_email { get; set; }
        [MaybeNull]
        public string user_phone { get; set; }
        [MaybeNull]
        public string user_password { get; set; }
        [MaybeNull]
        public string user_city { get; set; }
        
    }
}
